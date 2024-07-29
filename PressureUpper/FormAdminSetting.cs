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
    public partial class FormAdminSetting : Form
    {
        private DoctorQueryCondition? condition;
        public FormAdminSetting()
        {
            InitializeComponent();
        }
        private void FormAdminSetting_Load(object sender, EventArgs e)
        {
            dataView.AutoGenerateColumns = false;//禁止显示没有设置为显示的列
            LoadAdmin();
        }

        private void LoadAdmin()
        {
            dataView.Rows.Insert(0, "1", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(1, "2", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(2, "3", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(3, "4", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(4, "5", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(5, "6", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(6, "7", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(7, "8", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(8, "9", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(9, "10", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(10, "11", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(11, "12", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(12, "13", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(13, "14", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(14, "15", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(15, "16", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(16, "17", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(17, "18", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(18, "19", "Rafael", "Fernandez", "AV. Melgar", "56465");
            dataView.Rows.Insert(19, "20", "Rafael", "Fernandez", "AV. Melgar", "56465");

            //dataView.DataSource = CurrentDate;
            dataView.RowsDefaultCellStyle.BackColor = Color.FromArgb(241, 238, 255);// Color.White;
            dataView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(206, 197, 255);// Color.WhiteSmoke;
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormSetting frm = Owner as FormSetting;
            //FormMembresia frm = new FormMembresia();

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

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "TestDate")   //格式化日期
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
                    LoadAdmin();
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
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormDoctorEdit frm = new();
            frm.IsNew = false;
            frm.ShowDialog();
        }
    }
}
