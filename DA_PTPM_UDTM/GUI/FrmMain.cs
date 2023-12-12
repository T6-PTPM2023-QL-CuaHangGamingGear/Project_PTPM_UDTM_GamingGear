using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnDoanhSo.PerformClick();
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 118, b.Location.Y - 30);
            imgSlide.SendToBack();
        }
        private void btnDoanhSo_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }


        private void btnDoanhSo_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHome());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmUser());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmClient());

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProduct());

        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {

        }

        #region Method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //lblTitle.Text = childForm.Text;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion Method

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();
                this.Dispose();
                login.ShowDialog();
            }
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmOrderEntry());

        }
    }
}
