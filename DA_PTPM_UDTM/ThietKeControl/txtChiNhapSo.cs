using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2;
using Guna.UI2.WinForms;

namespace ThietKeControl
{
    public class txtChiNhapSo:Guna2TextBox
    {
        ErrorProvider er = new ErrorProvider();

        public txtChiNhapSo() 
        {
            this.KeyPress += TxtChiNhapSo_KeyPress;
        }

        public void TxtChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                er.SetError(this, "Enter only each number !!");
                e.Handled = true;
            }
            else
                er.SetError(this, "");
        }



    }
}
