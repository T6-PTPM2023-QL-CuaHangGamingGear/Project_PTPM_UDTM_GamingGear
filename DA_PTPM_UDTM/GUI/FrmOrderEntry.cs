using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
namespace GUI
{
    public partial class FrmOrderEntry : Form
    {

        List<PhieuNhap> list = new List<PhieuNhap>();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        public PhieuNhap phieunhap = new PhieuNhap();
        string title = "CRUD";
        public FrmOrderEntry()
        {
            InitializeComponent();
        }

        private void FrmOrderEntry_Load(object sender, EventArgs e)
        {
            list = PhieuNhapBLL.LoadListPN();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListOrder.Rows.Add(list[i].MaPN, list[i].MaNCC, list[i].MaNV, list[i].NgayNhap, list[i].TongTienPN, list[i].GhiChu);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_ListOrder.Rows.Clear();
            list = PhieuNhapBLL.SearchPN(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListOrder.Rows.Add(list[i].MaPN, list[i].MaNCC, list[i].MaNV, list[i].NgayNhap, list[i].TongTienPN, list[i].GhiChu);
            }
        }

        private void GNbtn_Add_Click(object sender, EventArgs e)
        {
            FrmOrderEntry_CURD curd = new FrmOrderEntry_CURD(this);
            curd.txtID.Enabled = false;

            curd.btnUpdate.Enabled = false;
            curd.btnUpdate.Visible = false;
            curd.btnSave.Enabled = true;
            curd.btnSave.Visible = true;
            curd.txtDateImport.Enabled = false;

            curd.ShowDialog();
            dgv_ListOrder.Rows.Clear();
            list = PhieuNhapBLL.LoadListPN();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListOrder.Rows.Add(list[i].MaPN, list[i].MaNCC, list[i].MaNV, list[i].NgayNhap, list[i].TongTienPN, list[i].GhiChu);
            }
        }

        private void dgv_ListOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv_ListOrder.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                FrmOrderEntry_CURD curd1 = new FrmOrderEntry_CURD(this);
                curd1.txtID.Enabled = false;
                curd1.btnSave.Visible = false;
                curd1.btnSave.Enabled = false;
                curd1.btnUpdate.Enabled = true;
                curd1.btnUpdate.Visible = true;

                curd1.txtID.Text = dgv_ListOrder.Rows[e.RowIndex].Cells[0].Value.ToString();
                curd1.cbbSupplier.SelectedText = dgv_ListOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                curd1.cbbUser.SelectedText = dgv_ListOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                curd1.txtDateImport.Text = dgv_ListOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                curd1.txtTotal.Text = dgv_ListOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                curd1.txtNote.Text = dgv_ListOrder.Rows[e.RowIndex].Cells[5].Value.ToString();

                curd1.btnSave.Enabled = true;

                curd1.ShowDialog();
                dgv_ListOrder.Rows.Clear();
                list = PhieuNhapBLL.LoadListPN();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListOrder.Rows.Add(list[i].MaPN, list[i].MaNCC, list[i].MaNV, list[i].NgayNhap, list[i].TongTienPN, list[i].GhiChu);
                }
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this client?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhieuNhapBLL.DeletePN(phieunhap.MaPN.ToString());
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListOrder.Rows.Clear();
                list = PhieuNhapBLL.LoadListPN();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListOrder.Rows.Add(list[i].MaPN, list[i].MaNCC, list[i].MaNV, list[i].NgayNhap, list[i].TongTienPN, list[i].GhiChu);
                }
            }
        }

        private void dgv_ListOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            phieunhap.MaPN = int.Parse(dgv_ListOrder.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
