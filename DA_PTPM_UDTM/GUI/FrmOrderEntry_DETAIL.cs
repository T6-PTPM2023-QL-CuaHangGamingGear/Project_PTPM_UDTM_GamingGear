using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
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
    public partial class FrmOrderEntry_DETAIL : Form
    {
        PhieuNhapDAO pndao = new PhieuNhapDAO();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        FrmOrderEntry orderform;
        List<ChiTietPhieuNhap> list = new List<ChiTietPhieuNhap>();

        bool check = false;
        string title = "CRUD";
        public FrmOrderEntry_DETAIL(FrmOrderEntry order)
        {
            InitializeComponent();
            orderform = order;
        }

        private void FrmOrderEntry_DETAIL_Load(object sender, EventArgs e)
        {
            list = ChiTietPhieuNhapBLL.LoadListCTPN(int.Parse(lbIDPN.Text)).Cast<ChiTietPhieuNhap>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListDetail.Rows.Add(list[i].MaPN, list[i].MaSP, list[i].SoLuongSP, list[i].GiaNhapSP, list[i].TongTienNhapSP);
            }
        }

        private void dgv_ListDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv_ListDetail.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuNhapBLL.DeleteCTPN(Convert.ToInt32(lbIDPN.Text), Convert.ToInt32(dgv_ListDetail.Rows[e.RowIndex].Cells[1].Value.ToString().Trim()));
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListDetail.Rows.Clear();
                list = ChiTietPhieuNhapBLL.LoadListCTPN(int.Parse(lbIDPN.Text)).Cast<ChiTietPhieuNhap>().ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListDetail.Rows.Add(list[i].MaPN, list[i].MaSP, list[i].SoLuongSP, list[i].GiaNhapSP, list[i].TongTienNhapSP);
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
