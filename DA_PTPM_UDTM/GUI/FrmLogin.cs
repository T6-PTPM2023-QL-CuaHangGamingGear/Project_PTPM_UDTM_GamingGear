using DAL;
using DAL.DAO;
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

namespace GUI
{
    public partial class FrmLogin : Form
    {
        DB_GearShopDataContext db = new DB_GearShopDataContext();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên và mật khẩu!");
            }
            else
            {
                var NhanVien = (from nv in db.NhanViens where nv.MaNV == txtMaNV.Text select nv).First();
                if (NhanVien.MatKhau == txtMatKhau.Text)
                {
                    MessageBox.Show("Welcome back " + txtMaNV.Text);
                    FrmMain frm = new FrmMain();
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!\nHãy kiểm tra lại thông tin của bạn.");
                }


            }


        }



    }
}
