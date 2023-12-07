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
    public partial class FrmClient : Form
    {
        List<KhachHang> list = new List<KhachHang>();
        KhachHangBLL nv = new KhachHangBLL();
        public KhachHang khachhang = new KhachHang();
        string title = "CRUD";

        public FrmClient()
        {
            InitializeComponent();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            list = KhachHangBLL.LoadListKH();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListKH.Rows.Add(list[i].MaKH, list[i].TenKH, list[i].DiaChi, list[i].DienThoai, list[i].Email, list[i].MatKhau, list[i].GhiChu);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_ListKH.Rows.Clear();
            list = KhachHangBLL.SearchKH(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListKH.Rows.Add(list[i].MaKH, list[i].TenKH, list[i].DiaChi, list[i].DienThoai, list[i].Email, list[i].MatKhau, list[i].GhiChu);
            }

        }

        private void GNbtn_Add_Click(object sender, EventArgs e)
        {
            FrmClient_CURD curd = new FrmClient_CURD(this);
            curd.txtID.Enabled = false;
            curd.btnUpdate.Visible = false;
            curd.btnSave.Visible = true;
            curd.ShowDialog();
            dgv_ListKH.Rows.Clear();
            list = KhachHangBLL.LoadListKH();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListKH.Rows.Add(list[i].MaKH, list[i].TenKH, list[i].DiaChi, list[i].DienThoai, list[i].Email, list[i].MatKhau, list[i].GhiChu);
            }
        }

        private void dgv_ListKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv_ListKH.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                FrmClient_CURD curd1 = new FrmClient_CURD(this);
                curd1.txtID.Text = dgv_ListKH.Rows[e.RowIndex].Cells[0].Value.ToString();
                curd1.txtName.Text = dgv_ListKH.Rows[e.RowIndex].Cells[1].Value.ToString();
                curd1.txtAddress.Text = dgv_ListKH.Rows[e.RowIndex].Cells[2].Value.ToString();
                curd1.txtPhone.Text = dgv_ListKH.Rows[e.RowIndex].Cells[3].Value.ToString();
                curd1.txtEmail.Text = dgv_ListKH.Rows[e.RowIndex].Cells[4].Value.ToString();
                curd1.txtPasswrod.Text = dgv_ListKH.Rows[e.RowIndex].Cells[5].Value.ToString();
                curd1.txtNote.Text = dgv_ListKH.Rows[e.RowIndex].Cells[6].Value.ToString();

                curd1.txtID.Enabled = false;
                curd1.btnSave.Visible = false;
                curd1.btnUpdate.Visible = true;
                curd1.btnUpdate.Enabled = true;
                curd1.ShowDialog();
                dgv_ListKH.Rows.Clear();
                list = KhachHangBLL.LoadListKH();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListKH.Rows.Add(list[i].MaKH, list[i].TenKH, list[i].DiaChi, list[i].DienThoai, list[i].Email, list[i].MatKhau, list[i].GhiChu);
                }
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this client?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhachHangBLL.DeleteKH(khachhang.MaKH.ToString());
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListKH.Rows.Clear();
                list = KhachHangBLL.LoadListKH();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListKH.Rows.Add(list[i].MaKH, list[i].TenKH, list[i].DiaChi, list[i].DienThoai, list[i].Email, list[i].MatKhau, list[i].GhiChu);
                }
            }
        }

        private void dgv_ListKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            khachhang.MaKH =int.Parse(dgv_ListKH.Rows[e.RowIndex].Cells[0].Value.ToString());

        }
    }
}
