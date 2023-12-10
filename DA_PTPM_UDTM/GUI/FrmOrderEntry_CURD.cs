using BLL;
using DAL;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class FrmOrderEntry_CURD : Form
    {
        PhieuNhapDAO pndao = new PhieuNhapDAO();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        FrmOrderEntry orderform;
        bool check = false;
        string title = "CRUD";

        public FrmOrderEntry_CURD(FrmOrderEntry order)
        {
            InitializeComponent();
            orderform = order;
        }


        public void CheckField()
        {
            if (cbbSupplier.Text == "" | cbbUser.Text == "" )
            {
                MessageBox.Show("No information entered", "Error");
                return;
            }
            check = true;
        }




        private void FrmOrderEntry_CURD_Load(object sender, EventArgs e)
        {
            foreach (var item in pndao.tenNhanVien()) //Load CBB  lấy mã và xuất ra tên 
            {
                cbbUser.Items.Add(item.TenNV);
                if (item.MaNV.Equals(pndao.returnValueTenNV().MaNV))
                {
                    cbbUser.SelectedItem = item.TenNV;
                }
            }

            foreach (var item in pndao.tenNhaCungCap())
            {
                cbbSupplier.Items.Add(item.TenNhaCungCap);
                if (item.MaNhaCungCap.Equals(pndao.returnValueNhaCungCap().MaNhaCungCap))
                {
                    cbbSupplier.SelectedItem = item.TenNhaCungCap;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to update this product ? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhieuNhap data = new PhieuNhap();

                    data.MaNCC = pndao.GetValueTenNCC(cbbSupplier.Text);
                    data.MaNV = pndao.GetValueTenNV(cbbUser.Text);
                    data.NgayNhap = DateTime.Parse(dtpDateImport.Text);
                    data.TongTienPN = Convert.ToDecimal(txtTotal.Text);
                    data.GhiChu = txtNote.Text;
                    pn.UpdatePn(txtID.Text, data);
                    MessageBox.Show("Update success", title);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Update failed", title);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to add this order? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhieuNhap data = new PhieuNhap();

                    data.MaNCC = pndao.GetValueTenNCC(cbbSupplier.Text);
                    data.MaNV = pndao.GetValueTenNV(cbbUser.Text);
                    data.NgayNhap = DateTime.Parse(dtpDateImport.Text);
                    data.TongTienPN = Convert.ToDecimal(txtTotal.Text);
                    data.GhiChu = txtNote.Text;
                    pn.AddPN(data);
                    MessageBox.Show("Add success", title);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Add failed", title);
                }
            }
        }
    }
}
