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
    public partial class FrmHome : Form
    {
        
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            int countNV = HomeDAO.CountListNV();
            lblUser.Text = Convert.ToString(countNV);

            int countKH = HomeDAO.CountListKH();
            lblClient.Text = Convert.ToString(countKH);

            int countSP = HomeDAO.CountListSP();
            lblProduct.Text = Convert.ToString(countSP);

            int countPN = HomeDAO.CountListPN();
            lblOrder.Text = Convert.ToString(countPN);

        }
    }
}
