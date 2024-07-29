using PressureUpper.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormRecord : Form
    {
        private TestRecordLogic? recordLogic;
        private TestRecord record;
        private RecordQueryCondition? condition;
        private DataTable CurrentData;
        private int recordCount = 0;
        private int pageCount = 0;
        private int pageSize = 10;
        private int currentPage = 0;
        public FormRecord()
        {
            InitializeComponent();
        }



        private void FormRecord_Load(object sender, EventArgs e)
        {
            dataView.AutoGenerateColumns = false;//禁止显示没有设置为显示的列
            GlobalVariable.CloudPlaybackOrReportView = string.Empty;//将云图回放和报告查看置空
            LoadTestRecord();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {

            if (dataView.RowCount > 0)
            {
                condition ??= new RecordQueryCondition();
                FormRecordQuery frm = new(condition);
                frm.ShowDialog();
                if (condition.IsSetCondition)
                {
                    LoadTestRecord();
                }
            }
            else
                MessageBox.Show("没有测试记录，无法进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void LoadTestRecord()
        {
            condition ??= new RecordQueryCondition();
            recordLogic ??= new TestRecordLogic();
            recordCount = recordLogic.GetRecordCount(condition);
            float t = (float)recordCount / (float)pageSize;
            pageCount = (int)(Math.Ceiling(t));
            lblPageCount.Text = "共" + recordCount.ToString() + "条，共" + pageCount.ToString() + "页";
            txtPageNum.Text = (currentPage + 1).ToString();
            CurrentData = recordLogic.GetListByPage(condition, currentPage * pageSize, currentPage * pageSize + pageSize);
            dataView.DataSource = CurrentData;
            dataView.RowsDefaultCellStyle.BackColor = Color.FromArgb(241, 238, 255);// Color.White;
            dataView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(206, 197, 255);// Color.WhiteSmoke;
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormSetting frm = Owner as FormSetting;

            //frm.label3.Text = dataView.CurrentRow.Cells[0].Value.ToString();
            //frm.txtnombre.Text = dataView.CurrentRow.Cells[1].Value.ToString();
            //frm.txtapellido.Text = dataView.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }



        private void DataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            DataGridView dgv = (DataGridView)sender;
            object originalValue = e.Value;

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "操作类型")
            {
                e.Value = ((int)originalValue == 0) ? "缴费" : "退费";
            }

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "EnterTime")   //格式化日期
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                }
            }
            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "OperationDate")   //格式化日期
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                }
            }

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "BegainTime")   //格式化日期
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("hh:mm:ss");
                }
            }
            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "EndTime")   //格式化日期
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("hh:mm:ss");
                }
            }

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            condition = null;
            LoadTestRecord();

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadTestRecord();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage < 0) currentPage = 0;
            LoadTestRecord();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage > pageCount - 1) currentPage = pageCount - 1;
            LoadTestRecord();

        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            currentPage = pageCount - 1;
            LoadTestRecord();
        }

        private void BtnJump_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txtPageNum.Text);
            if (num < 1 || num > pageCount)
            {
                return;
            }
            currentPage = num - 1;
            LoadTestRecord();
        }

        private void BtnPlayback_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                //取出选中项的主键值
                SetCurrentRowToRecord(dataView.CurrentRow);
                GlobalVariable.CloudPlaybackOrReportView = "Cloud";
                this.Close();
            }
            else
            {
                MessageBox.Show("请点击列表选中一条记录后，再进行回放！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                //取出选中项的主键值
                SetCurrentRowToRecord(dataView.CurrentRow);
                GlobalVariable.CloudPlaybackOrReportView = "Report";
                this.Close();
            }
            else
            {
                MessageBox.Show("请点击列表选中一条记录后，再查看报告！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetCurrentRowToRecord(DataGridViewRow CurrentRow)
        {

            GlobalVariable.testRecord ??= new TestRecord();
            GlobalVariable.testRecord.ID = int.Parse(CurrentData.Rows[CurrentRow.Index]["ID"].ToString());
            GlobalVariable.testRecord.Name = CurrentData.Rows[CurrentRow.Index]["Name"].ToString();
            GlobalVariable.testRecord.Weight = decimal.Parse(CurrentData.Rows[CurrentRow.Index]["Weight"].ToString());
            GlobalVariable.testRecord.Height = decimal.Parse(CurrentData.Rows[CurrentRow.Index]["Height"].ToString());
            GlobalVariable.testRecord.Age = int.Parse(CurrentData.Rows[CurrentRow.Index]["Age"].ToString());
            GlobalVariable.testRecord.OnePath = CurrentData.Rows[CurrentRow.Index]["OnePath"].ToString();
            GlobalVariable.testRecord.TwoPath = CurrentData.Rows[CurrentRow.Index]["TwoPath"].ToString();
            GlobalVariable.testRecord.ReportPath = CurrentData.Rows[CurrentRow.Index]["ReportPath"].ToString();
            GlobalVariable.testRecord.Sex = CurrentData.Rows[CurrentRow.Index]["Sex"].ToString();
            GlobalVariable.testRecord.MedicalRecordNum = CurrentData.Rows[CurrentRow.Index]["MedicalRecordNum"].ToString();
            GlobalVariable.testRecord.Left = CurrentData.Rows[CurrentRow.Index]["Left"].ToString().Equals("1");
            GlobalVariable.testRecord.Right = CurrentData.Rows[CurrentRow.Index]["Left"].ToString().Equals("1");
            GlobalVariable.testRecord.EnterTime = DateTime.Parse(CurrentData.Rows[CurrentRow.Index]["EnterTime"].ToString());
            GlobalVariable.testRecord.OperationDate = DateTime.Parse(CurrentData.Rows[CurrentRow.Index]["OperationDate"].ToString());

        }
    }
}
