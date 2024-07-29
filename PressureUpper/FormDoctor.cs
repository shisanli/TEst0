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
    public partial class FormDoctor : Form
    {
        private DoctorLogic? doctorLogic;
        private DoctorQueryCondition? condition;
        private Doctor? doctor;
        private DataTable? CurrentData;
        private int recordCount = 0;
        private int pageCount = 0;
        private int pageSize = 10;
        private int currentPage = 0;
        public FormDoctor()
        {
            InitializeComponent();
            this.btnSelect.Visible = false;
        }
        public FormDoctor(Doctor? doctor)
        {
            this.doctor = doctor;
            InitializeComponent();
            this.btnSelect.Visible = true;//如果是选定医生则显示选定按钮
        }
        private void FormDoctor_Load(object sender, EventArgs e)
        {
            dataView.AutoGenerateColumns = false;//禁止显示没有设置为显示的列
            LoadDoctor();
            if (!GlobalVariable.doctor.AccountNum.ToLower().Equals("admin"))
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void LoadDoctor()
        {
            condition ??= new DoctorQueryCondition();
            doctorLogic ??= new DoctorLogic();
            recordCount = doctorLogic.GetRecordCount(condition);
            float t = (float)recordCount / (float)pageSize;
            pageCount = (int)(Math.Ceiling(t));
            lblPageCount.Text = "共" + recordCount.ToString() + "条，共" + pageCount.ToString() + "页";
            txtPageNum.Text = (currentPage + 1).ToString();
            CurrentData = doctorLogic.GetListByPage(condition, currentPage * pageSize, currentPage * pageSize + pageSize);
            dataView.DataSource = CurrentData;
            dataView.RowsDefaultCellStyle.BackColor = Color.FromArgb(241, 238, 255);// Color.White;
            dataView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(206, 197, 255);// Color.WhiteSmoke;
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnSelect.Visible == true)
            {
                SelectDoctor();
            }
        }



        private void DataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "IsAdmin")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().Trim().Equals("0") ? "否" : "是";
                }
            }

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "IsDeleted")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().Trim().Equals("0") ? "否" : "是";
                }
            }

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "CreateTime")   //格式化日期
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

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                condition ??= new DoctorQueryCondition();
                FormDoctorQuery frm = new(condition);
                frm.ShowDialog();
                if (condition.IsSetCondition)
                {
                    LoadDoctor();
                }
            }
            else
                MessageBox.Show("没有医生信息，无法进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FormDoctorEdit frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDoctor();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count <= 0)
            {
                MessageBox.Show("没有医生信息，无法进行编辑！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormDoctorEdit frm = new();
            frm.doctor = new Doctor
            {
                ID = int.Parse(dataView.CurrentRow.Cells[0].Value.ToString()),
                Password = dataView.CurrentRow.Cells[2].Value.ToString(),
            };
            frm.txtAccountNum.Text = dataView.CurrentRow.Cells[1].Value.ToString();
            frm.txtPassword.Text = dataView.CurrentRow.Cells[2].Value.ToString();
            frm.txtPasswordAgain.Text = dataView.CurrentRow.Cells[2].Value.ToString();
            frm.txtName.Text = dataView.CurrentRow.Cells[3].Value.ToString();
            frm.rdbMan.Checked = dataView.CurrentRow.Cells[4].Value.ToString().Equals("男");
            frm.rdbWoman.Checked = dataView.CurrentRow.Cells[4].Value.ToString().Equals("女");
            frm.txtDepartment.Text = dataView.CurrentRow.Cells[5].Value.ToString();
            frm.dtpCreateTime.Text = dataView.CurrentRow.Cells[6].Value.ToString();
            frm.cmbBoxAdmin.Text = dataView.CurrentRow.Cells[8].Value.ToString().Equals("1") ? "是" : "否";
            frm.IsNew = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDoctor();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            condition = null;
            LoadDoctor();

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadDoctor();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage < 0) currentPage = 0;
            LoadDoctor();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage > pageCount - 1) currentPage = pageCount - 1;
            LoadDoctor();

        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            currentPage = pageCount - 1;
            LoadDoctor();
        }

        private void BtnJump_Click(object sender, EventArgs e)
        {
            if (ValidateHelper.IsNumber(txtPageNum.Text) == false)
            {
                MessageBox.Show("跳转页数必须是数字,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPageNum.Text = "";
                txtPageNum.Focus();
                return;
            }
            int num = int.Parse(txtPageNum.Text);
            if (num < 1 || num > pageCount)
            {
                return;
            }
            currentPage = num - 1;
            LoadDoctor();
        }

        //选定
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectDoctor();
        }

        private void SelectDoctor()
        {
            if (dataView.Rows.Count <= 0)
            {
                MessageBox.Show("数据为空无法进行选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            doctor.ID = int.Parse(dataView.CurrentRow.Cells[0].Value.ToString());
            doctor.Name = dataView.CurrentRow.Cells[3].Value.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
