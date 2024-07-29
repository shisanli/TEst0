using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbInfoTools;

namespace PressureUpper
{
    public class UsbItem
    {


        /// <summary>
        /// 节点名称
        /// </summary>
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// 节点数据
        /// </summary>
        public Object? Data { get; set; }

        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<UsbItem>? Children { get; set; }






        /// <summary>
        /// 连接的外部Hub数目
        /// </summary>
        public static Int32 ConnectedHubs = 0;

        /// <summary>
        /// 连接的USB设备数目
        /// </summary>
        public static Int32 ConnectedDevices = 0;

        /// <summary>
        /// 静态根节点
        /// </summary>
        public static List<UsbItem> AllUsbDevices
        {
            get
            {
                // 初始化
                ConnectedHubs = 0;      // 连接的外部Hub数目
                ConnectedDevices = 0;   // 连接的USB设备数目

                // 创建根节点
                UsbItem Root = new();
                Root.Name = "Computer";
                Root.Data = "Machine Name:" + System.Environment.MachineName;

                // 子节点列表
                // 深度遍历主控制器
                HostControllerInfo[] HostControllersCollection = USB.AllHostControllers;
                if (HostControllersCollection != null)
                {
                    List<UsbItem> HCNodeCollection = new List<UsbItem>(HostControllersCollection.Length);
                    foreach (HostControllerInfo item in HostControllersCollection)
                    {   // 创建主控制器节点
                        UsbItem HCNode = new UsbItem();
                        HCNode.Name = item.Name;
                        HCNode.Data = item;

                        // 创建根集线器节点
                        String RootHubPath = USB.GetUsbRootHubPath(item.PNPDeviceID);
                        HCNode.Children = AddHubNode(RootHubPath, "RootHub");

                        HCNodeCollection.Add(HCNode);
                    }

                    Root.Children = HCNodeCollection;
                }

                return new List<UsbItem>(1) { Root };
            }
        }

        /// <summary>
        /// Hub节点
        /// </summary>
        /// <param name="HubPath">Hub路径</param>
        /// <param name="HubNodeName">节点显示名称</param>
        /// <returns>Hub节点集合</returns>
        private static List<UsbItem> AddHubNode(String HubPath, String HubNodeName)
        {
            UsbNodeInformation[] NodeInfoCollection = USB.GetUsbNodeInformation(HubPath);
            if (NodeInfoCollection != null)
            {
                UsbItem HubNode = new UsbItem();
                if (String.IsNullOrEmpty(NodeInfoCollection[0].Name))
                {
                    HubNode.Name = HubNodeName;
                }
                else
                {
                    HubNode.Name = NodeInfoCollection[0].Name;
                }
                HubNode.Data = NodeInfoCollection[0];

                if (NodeInfoCollection[0].NodeType == USB_HUB_NODE.UsbHub)
                {
                    HubNode.Children = AddPortNode(HubPath, NodeInfoCollection[0].NumberOfPorts);
                }
                else
                {
                    HubNode.Children = null;
                }

                return new List<UsbItem>(1) { HubNode };
            }

            return null;
        }

        /// <summary>
        /// Port节点
        /// </summary>
        /// <param name="HubPath">Hub路径</param>
        /// <param name="NumberOfPorts">端口数</param>
        /// <returns>Port节点集合</returns>
        private static List<UsbItem> AddPortNode(String HubPath, Int32 NumberOfPorts)
        {
            // 深度遍历端口
            UsbNodeConnectionInformation[] NodeConnectionInfoCollection = USB.GetUsbNodeConnectionInformation(HubPath, NumberOfPorts);
            if (NodeConnectionInfoCollection != null)
            {
                List<UsbItem> PortNodeCollection = new List<UsbItem>(NumberOfPorts);
                foreach (UsbNodeConnectionInformation NodeConnectionInfo in NodeConnectionInfoCollection)
                {   // 增加端口节点
                    UsbItem PortNode = new UsbItem();

                    PortNode.Name = "[Port" + NodeConnectionInfo.ConnectionIndex + "]" + NodeConnectionInfo.ConnectionStatus;
                    PortNode.Data = NodeConnectionInfo;
                    PortNode.Children = null;
                    if (NodeConnectionInfo.ConnectionStatus == USB_CONNECTION_STATUS.DeviceConnected)
                    {
                        // 设备连接
                        ConnectedDevices++; // 连接的USB设备数目
                        if (!String.IsNullOrEmpty(NodeConnectionInfo.DeviceDescriptor.Product))
                        {   // 产品名称
                            PortNode.Name = String.Concat(PortNode.Name, ": ", NodeConnectionInfo.DeviceDescriptor.Product);
                        }

                        if (NodeConnectionInfo.DeviceIsHub)
                        {
                            // 获取外部Hub设备路径
                            String ExternalHubPath = USB.GetExternalHubPath(NodeConnectionInfo.DevicePath, NodeConnectionInfo.ConnectionIndex);
                            UsbNodeInformation[] NodeInfoCollection = USB.GetUsbNodeInformation(HubPath);
                            if (NodeInfoCollection != null)
                            {

                                PortNode.Data = new ExternalHubInfo { NodeInfo = NodeInfoCollection[0], NodeConnectionInfo = NodeConnectionInfo };
                                if (NodeInfoCollection[0].NodeType == USB_HUB_NODE.UsbHub)
                                {
                                    PortNode.Children = AddPortNode(ExternalHubPath, NodeInfoCollection[0].NumberOfPorts);
                                }

                                if (String.IsNullOrEmpty(NodeConnectionInfo.DeviceDescriptor.Product))
                                {
                                    if (!String.IsNullOrEmpty(NodeInfoCollection[0].Name))
                                    {   // 产品名称
                                        PortNode.Name = String.Concat(PortNode.Name, ": ", NodeInfoCollection[0].Name);
                                    }
                                }
                            }

                            ConnectedHubs++;    // 连接的外部Hub数目
                        }
                    }

                    PortNodeCollection.Add(PortNode);
                }

                return PortNodeCollection;
            }

            return null;
        }
    }
}
