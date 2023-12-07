using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class FrmClient_CURD : Form
    {
        KhachHangBLL kh = new KhachHangBLL();
        FrmClient clientform;
        bool check = false;
        string title = "CRUD";
        public FrmClient_CURD(FrmClient client)
        {
            InitializeComponent();
            clientform = client;   
        }

        public void CheckField()
        {
            if (txtName.Text == "" | txtEmail.Text == "" | txtPhone.Text == "" | txtPasswrod.Text == "" | txtAddress.Text == "")
            {
                MessageBox.Show("No information entered", "Error");
                return;
            }

            check = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to add this client? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhachHang data = new KhachHang();
                    data.TenKH = txtName.Text;
                    data.DiaChi = txtAddress.Text;
                    data.DienThoai = txtPhone.Text;
                    data.Email = txtEmail.Text;
                    data.MatKhau = txtPasswrod.Text;
                    data.GhiChu = txtNote.Text;
                    kh.AddKH(data);
                    MessageBox.Show("Add success", title);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Add failed", title);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to update this client ? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhachHang data = new KhachHang();
                    data.TenKH = txtName.Text;
                    data.DiaChi = txtAddress.Text;
                    data.DienThoai = txtPhone.Text;
                    data.Email = txtEmail.Text;
                    data.MatKhau = txtPasswrod.Text;
                    data.DiaChi = txtAddress.Text;
                    data.GhiChu = txtNote.Text;
                    kh.UpdateKH(txtID.Text, data);
                    MessageBox.Show("Update success", title);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Update failed", title);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
