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
using DAL.DAO;

namespace GUI
{
    public partial class FrmProduct_CURD : Form
    {

        SanPhamBLL sp = new SanPhamBLL();
        FrmProduct productform;
        bool check = false;
        string title = "CRUD";
        public FrmProduct_CURD(FrmProduct product)
        {
            InitializeComponent();
            productform = product;
        }

        private void FrmProduct_CURD_Load(object sender, EventArgs e)
        {
            SanPhamDAO spdao = new SanPhamDAO();
            foreach (var item in spdao.tenLoaiSP()) //Load CBB thay vì lấy mã thì xuất ra tên loại SP
            {
                cbbType.Items.Add(item.TenLoaiSP);
                if (item.MaLoaiSP.Equals(spdao.returnValueLoai().MaLoaiSP))
                {
                    cbbType.SelectedItem = item.TenLoaiSP;
                }
            }

            foreach (var item in spdao.tenHangSX())
            {
                cbbBrand.Items.Add(item.TenHangSX);
                if (item.MaHangSX.Equals(spdao.returnValueHang().MaHangSX))
                {
                    cbbBrand.SelectedItem = item.TenHangSX;
                }
            }
        }
        public void CheckField()
        {
            if (txtName.Text == "" | txtName.Text == "" | txtPrice.Text == "" | txtQuantity.Text == "")
            {
                MessageBox.Show("No information entered", "Error");
                return;
            }

            check = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //CheckField();
            //if (check)
            //{
            //    if (MessageBox.Show("Are you sure you want to add this product? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SanPham data = new SanPham();
            //        data.TenSP = txtName.Text;
            //        data.MaLoaiSP = cbbType.Text ;
            //        data.MaHangSX = cbbBrand.Text;
            //        data.HinhAnh = GN_Images.Text;
            //        data.GiaSP = txtPrice.Text;
            //        data.SoLuong = Convert.ToInt32(txtQuantity.Text);
            //        data.MoTa = txtNote.Text;
            //        sp.AddSP(data);
            //        MessageBox.Show("Add success", title);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Add failed", title);
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //CheckField();
            //if (check)
            //{
            //    if (MessageBox.Show("Are you sure you want to update this product ? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SanPham data = new SanPham();
            //        data.TenSP = txtName.Text;
            //        data.MaLoaiSP = cbbType.Text;
            //        data.MaHangSX = cbbBrand.Text;
            //        data.HinhAnh = GN_Images.Text;
            //        data.GiaSP = txtPrice.Text;
            //        data.SoLuong = Convert.ToInt32(txtQuantity.Text);
            //        data.MoTa = txtNote.Text;
            //        sp.UpdateSP(txtID.Text, data);
            //        MessageBox.Show("Update success", title);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Update failed", title);
            //    }
            //}
        }
    }
}
