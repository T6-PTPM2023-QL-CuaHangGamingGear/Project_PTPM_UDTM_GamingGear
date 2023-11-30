﻿using BLL;
using DAL;
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
    public partial class FrmUser_CURD : Form
    {
        NhanVienBLL nv = new NhanVienBLL(); 
        FrmUser userform;
        bool check = false;
        string title = "CRUD";

        public FrmUser_CURD(FrmUser user)
        {
            InitializeComponent();
            userform = user;
        }

        private void FrmUser_CURD_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to add this user? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVien data = new NhanVien();
                    data.TenNV = txtName.Text;
                    data.GioiTinh = txtGender.Text;
                    data.SDT = dtDob.Text;
                    data.MatKhau = txtPasswrod.Text;
                    data.ChucVu = txtPosition.Text;
                    data.TinhTrang = txtNote.Text;
                    nv.AddNV(data);
                    MessageBox.Show("Add success", title);
                }
                else
                {
                    MessageBox.Show("Add failed", title);
                }
            }
        }


        public void CheckField()
        {
            if (txtName.Text == "" | txtGender.Text == "" | txtPhone.Text == "" | txtPasswrod.Text == "" | txtPosition.Text == "" | txtNote.Text == "")
            {
                MessageBox.Show("No information entered", "Error");
                return;
            }

            check = true;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Are you sure you want to update this user? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVien data = new NhanVien();
                    data.TenNV = txtName.Text;
                    data.GioiTinh = txtGender.Text;
                    data.SDT = dtDob.Text;
                    data.MatKhau = txtPasswrod.Text;
                    data.ChucVu = txtPosition.Text;
                    data.TinhTrang = txtNote.Text;
                    nv.UpdateNV(txtID.Text,data);
                    MessageBox.Show("Update success", title);
                }
                else
                {
                    MessageBox.Show("Update failed", title);
                }
            }
        }
    }
}
