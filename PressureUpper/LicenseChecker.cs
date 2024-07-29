﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    /// <summary>
    /// 授权文件校验
    /// </summary>
    public class LicenseChecker
    {


        /// <summary>
        /// 版本识别码（来自授权文件制作工具，这个很重要，比如和版本对应）
        /// </summary>
        public string VersionNo
        {
            get
            {
                return "d3a366";
            }
        }
        private string usbResultString=string.Empty;

        /// <summary>
        /// 机器识别码
        /// </summary>
        /// <returns></returns>
        public string GetMachineCode()
        {
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            //String strHardDiskID = null;//存储磁盘序列号
            //foreach (ManagementObject mo in searcher.Get())
            //{
            //    strHardDiskID = mo["SerialNumber"].ToString().Trim();//记录获得的磁盘序列号
            //    break;
            //}
            var usbs = UsbItem.AllUsbDevices;
            usbResultString = string.Empty;
            ExpandSubItems(usbs);

            //return MD5Helper.GetMD5HashString(usbResultString, 8);
            return usbResultString;
        }

        private  void ExpandSubItems(List<UsbItem> items)
        {
           
            if (items == null) return;
            foreach (UsbItem item in items)
            {
                string[] temp = item.Name.Split(':');
                if (temp.Length >= 2)
                    usbResultString += temp[1] + ",";
                var treeItem = item.Children;
                if (treeItem != null)
                {
                    ExpandSubItems(treeItem);
                }
            }
        }


        /// <summary>
        /// 校验授权文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool Check(string filePath, out string message)
        {
            bool result = false;
            message = string.Empty;

            string content = System.IO.File.ReadAllText(filePath);
            string[] items = content.Split(new string[] { "+++++=====+++++" }, StringSplitOptions.RemoveEmptyEntries);

            if (items.Length != 3)
            {
                message = "授权文件格式无法识别";
                return false;
            }

            string json = items[0];
            string sign = items[1];
            string publicKeyXml = items[2];

            var fileVersionNo = MD5Helper.GetMD5HashString(publicKeyXml).Substring(0, 6);
            if (fileVersionNo.Equals(this.VersionNo) == false)
            {
                message = "版本识别号有误";
                return false;
            }

            var isVerify = Verify(json, sign, publicKeyXml);

            if (isVerify == false)
            {
                message = "授权文件格式校验未通过";
                return false;
            }

            AuthorizeFile af = AuthorizeFile.FromJson(json);

            if (af.Check(this.GetMachineCode()) == false)
            {
                message = "应用授权失败，当前授权类型为：" + af.AuthorizeType;

                System.IO.File.Delete(filePath);

                return false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        bool Verify(byte[] data, byte[] Signature, string PublicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //导入公钥，准备验证签名
            rsa.FromXmlString(PublicKey);
            //返回数据验证结果
            return rsa.VerifyData(data, "MD5", Signature);
        }

        public bool Verify(String Text, string SignatureBase64, string PublicKey)
        {
            var data = System.Text.Encoding.UTF8.GetBytes(Text);
            byte[] Signature = Convert.FromBase64String(SignatureBase64);

            return Verify(data, Signature, PublicKey);

        }


    }

    /// <summary>
    /// 授权文件数据格式
    /// </summary>
    class AuthorizeFile
    {

        public string Version { get; set; } = string.Empty;

        public string AuthorizeType { get; set; } = string.Empty;

        public string AuthorizeContent { get; set; } = string.Empty;


        public DateTime SignDate { get; set; }

        public bool Check(string machineCode)
        {
            string[] splits = new string[] { ",", "\r\n" };
            string[] items = this.AuthorizeContent.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            string[] machineItems= machineCode.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            foreach (string mItem in machineItems)
            {
                foreach (string item in items)
                {
                    if (item.Trim().Equals(mItem.Trim()))
                        return true;
                }
            }

            return false;
        }

        public string ToJson()
        {
            this.SignDate = DateTime.Now;

            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static AuthorizeFile? FromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizeFile>(json);
        }


    }
}
