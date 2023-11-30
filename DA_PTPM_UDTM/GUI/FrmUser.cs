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
    public partial class FrmUser : Form
    {
        List<NhanVien> list = new List<NhanVien>();
        NhanVienBLL nv = new NhanVienBLL();
        public NhanVien nhanvien = new NhanVien();
        string title = "CRUD";

        public FrmUser()
        {
            InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            list = NhanVienBLL.LoadListNV();
            //Show 1 dòng hiển thị tất cả thông tin 1 nhân viên
            //dgv_ListNV.DataSource = list;
            //dgv_ListNV.Columns[0].HeaderText = "ID User";
            //dgv_ListNV.Columns[1].HeaderText = "Name";
            //dgv_ListNV.Columns[2].HeaderText = "Gender";
            //dgv_ListNV.Columns[3].HeaderText = "Phone";
            //dgv_ListNV.Columns[4].HeaderText = "DOB";
            //dgv_ListNV.Columns[5].HeaderText = "Password";
            //dgv_ListNV.Columns[6].HeaderText = "Position";
            //dgv_ListNV.Columns[7].HeaderText = "Note";



            //Show một cột là một thông tin của 1 thuộc tính trong bảng nhân viên, tất nhiên phải design lại cái datagridview
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListNV.Rows.Add(list[i].MaNV, list[i].TenNV, list[i].GioiTinh, list[i].SDT, list[i].NgaySinh, list[i].MatKhau, list[i].ChucVu, list[i].TinhTrang);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_ListNV.Rows.Clear();
            list = NhanVienBLL.SearchNV(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListNV.Rows.Add(list[i].MaNV, list[i].TenNV, list[i].GioiTinh, list[i].SDT, list[i].NgaySinh, list[i].MatKhau, list[i].ChucVu, list[i].TinhTrang);
            }
        }

        private void GNbtn_Add_Click(object sender, EventArgs e)
        {
            FrmUser_CURD curd = new FrmUser_CURD(this);
            curd.btnUpdate.Visible = false;
            curd.btnSave.Visible = true;
            curd.ShowDialog();
            dgv_ListNV.Rows.Clear();
            list = NhanVienBLL.LoadListNV();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListNV.Rows.Add(list[i].MaNV, list[i].TenNV, list[i].GioiTinh, list[i].SDT, list[i].NgaySinh, list[i].MatKhau, list[i].ChucVu, list[i].TinhTrang);
            }
        }

        private void dgv_ListNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv_ListNV.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                FrmUser_CURD curd1 = new FrmUser_CURD(this);
                curd1.txtID.Text = dgv_ListNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                curd1.txtName.Text = dgv_ListNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                curd1.txtGender.Text = dgv_ListNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                curd1.txtPhone.Text = dgv_ListNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                //curd1.dtDob.Text = dgv_ListNV.Rows[e.RowIndex].Cells[4].Value.ToString(); bug do csdl để kiểu dữ liệu là smalldatetime
                curd1.txtPasswrod.Text = dgv_ListNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                curd1.txtPosition.Text = dgv_ListNV.Rows[e.RowIndex].Cells[6].Value.ToString();
                curd1.txtNote.Text = dgv_ListNV.Rows[e.RowIndex].Cells[7].Value.ToString();

                curd1.txtID.Enabled = false;
                curd1.btnSave.Visible = false;
                curd1.btnUpdate.Visible = true;
                curd1.btnUpdate.Enabled = true;
                curd1.ShowDialog();
                dgv_ListNV.Rows.Clear();
                list = NhanVienBLL.LoadListNV();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListNV.Rows.Add(list[i].MaNV, list[i].TenNV, list[i].GioiTinh, list[i].SDT, list[i].NgaySinh, list[i].MatKhau, list[i].ChucVu, list[i].TinhTrang);
                }
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVienBLL.DeleteNV(nhanvien.MaNV);
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListNV.Rows.Clear();
                list = NhanVienBLL.LoadListNV();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListNV.Rows.Add(list[i].MaNV, list[i].TenNV, list[i].GioiTinh, list[i].SDT, list[i].NgaySinh, list[i].MatKhau, list[i].ChucVu, list[i].TinhTrang);
                }
            }
        }

        private void dgv_ListNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            nhanvien.MaNV = dgv_ListNV.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
