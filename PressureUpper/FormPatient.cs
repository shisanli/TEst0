using NPOI.POIFS.Properties;
using NPOI.SS.Formula.Functions;
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
using System.Xml.Linq;

namespace PressureUpper
{
    public partial class FormPatient : Form
    {

        private PatientLogic? patientLogic;
        private PatientQueryCondition? condition;
        private DataTable? CurrentData;
        private Patient? patient;
        private int recordCount = 0;
        private int pageCount = 0;
        private int pageSize = 10;
        private int currentPage = 0;

        public FormPatient()
        {
            InitializeComponent();
        }

        public FormPatient(Patient? patient)
        {
            InitializeComponent();
            this.patient = patient;
            this.btnSelect.Visible = true;//如果是选定医生则显示选定按钮
        }
        private void FormPatient_Load(object sender, EventArgs e)
        {
            dataView.AutoGenerateColumns = false;//禁止显示没有设置为显示的列
            LoadPatient();
        }

        private void LoadPatient()
        {
            condition ??= new PatientQueryCondition();
            patientLogic ??= new PatientLogic();
            recordCount = patientLogic.GetRecordCount(condition);
            var t = (float)recordCount / (float)pageSize;
            pageCount = (int)(Math.Ceiling(t));
            lblPageCount.Text = @"共" + recordCount.ToString() + @"条，共" + pageCount.ToString() + @"页";
            txtPageNum.Text = (currentPage + 1).ToString();
            CurrentData = patientLogic.GetListByPage(condition, currentPage * pageSize, currentPage * pageSize + pageSize);
            dataView.DataSource = CurrentData;
            dataView.RowsDefaultCellStyle.BackColor = Color.FromArgb(241, 238, 255);// Color.White;
            dataView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(206, 197, 255);// Color.WhiteSmoke;
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnSelect.Visible == true)
            {

                SelectPatient();
            }
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
                condition ??= new PatientQueryCondition();
                FormPatientQuery frm = new(condition);
                frm.ShowDialog();
                if (condition.IsSetCondition)
                {
                    LoadPatient();
                }
            }
            else
                MessageBox.Show(@"没有患者信息，无法进行查询！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FormPatientEdit frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPatient();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count <= 0)
            {
                MessageBox.Show(@"没有患者信息，无法进行编辑！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormPatientEdit frm = new();
            frm.IsNew = false;
            frm.patient = new Patient
            {
                ID = int.Parse(dataView.CurrentRow.Cells[0].Value.ToString()),
                Name = dataView.CurrentRow.Cells[1].Value.ToString(),
                MedicalRecordNum = dataView.CurrentRow.Cells[2].Value.ToString(),
                Sex = dataView.CurrentRow.Cells[3].Value.ToString().Equals("1") ? "1" : "0",
                Weight = int.Parse(dataView.CurrentRow.Cells[4].Value.ToString()),
                Height = int.Parse(dataView.CurrentRow.Cells[5].Value.ToString()),
                Age = int.Parse(dataView.CurrentRow.Cells[6].Value.ToString()),
                DoctorID = int.Parse(dataView.CurrentRow.Cells[7].Value.ToString()),
                Doctor = dataView.CurrentRow.Cells[8].Value.ToString(),
                AnesthesiologistID = int.Parse(dataView.CurrentRow.Cells[9].Value.ToString()),
                Anesthesiologist = dataView.CurrentRow.Cells[10].Value.ToString(),
                EnterTime = DateTime.Parse(dataView.CurrentRow.Cells[11].Value.ToString()),
                Score = decimal.Parse(dataView.CurrentRow.Cells[12].Value.ToString()),
                MedicalHistory = dataView.CurrentRow.Cells[13].Value.ToString(),
                DrugAllergy = dataView.CurrentRow.Cells[14].Value.ToString(),
                DiagnosticResult = dataView.CurrentRow.Cells[15].Value.ToString(),
                OtherInformation = dataView.CurrentRow.Cells[16].Value.ToString(),
                Mark = "",
                IsDeleted = false,
                IsSetContent = true
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPatient();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            condition = null;
            LoadPatient();

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadPatient();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage < 0) currentPage = 0;
            LoadPatient();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage > pageCount - 1) currentPage = pageCount - 1;
            LoadPatient();

        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            currentPage = pageCount - 1;
            LoadPatient();
        }

        private void BtnJump_Click(object sender, EventArgs e)
        {
            if (ValidateHelper.IsNumber(txtPageNum.Text) == false)
            {
                MessageBox.Show(@"跳转页数必须是数字,请重新输入！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPageNum.Text = "";
                txtPageNum.Focus();
                return;
            }
            var num = int.Parse(txtPageNum.Text);
            if (num < 1 || num > pageCount)
            {
                return;
            }
            currentPage = num - 1;
            LoadPatient();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectPatient();
        }

        private void SelectPatient()
        {
            if (dataView.Rows.Count <= 0)
            {
                MessageBox.Show(@"数据为空无法进行选择！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            patient.ID = int.Parse(dataView.CurrentRow.Cells[0].Value.ToString());
            patient.Name = dataView.CurrentRow.Cells[1].Value.ToString();
            patient.MedicalRecordNum = dataView.CurrentRow.Cells[2].Value.ToString();
            patient.Sex = dataView.CurrentRow.Cells[3].Value.ToString();
            patient.Weight = int.Parse(dataView.CurrentRow.Cells[4].Value.ToString());
            patient.Height = int.Parse(dataView.CurrentRow.Cells[5].Value.ToString());
            patient.Age = int.Parse(dataView.CurrentRow.Cells[6].Value.ToString());
            patient.EnterTime = DateTime.Parse(dataView.CurrentRow.Cells[11].Value.ToString());
            this.DialogResult = DialogResult.OK;
        }
    }
}
