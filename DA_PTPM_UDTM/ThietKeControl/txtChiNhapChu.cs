using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThietKeControl
{
    public class txtChiNhapChu:Guna2TextBox
    {
        ErrorProvider er = new ErrorProvider();

        public txtChiNhapChu()
        {
            this.KeyPress += TxtChiNhapMoiChu_KeyPress;

        }

        public void TxtChiNhapMoiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                er.SetError(this, "Enter only each letter !!");
                e.Handled = true;
            }
            else
                er.SetError(this, "");


        }
    }
}
