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
        ChiTietPhieuNhapBLL ctpn = new ChiTietPhieuNhapBLL();
        FrmOrderEntry orderform;
        List<ChiTietPhieuNhap> list = new List<ChiTietPhieuNhap>();

        bool check = false;
        string title = "CRUD";
        public FrmOrderEntry_DETAIL(FrmOrderEntry order)
        {
            InitializeComponent();
            orderform = order;
        }

        //public void LoadCBBIDPr()
        //{
        //    using (var db = new GEARSHOP_DBDataContext())
        //    {
        //        var data = from sp in db.SanPhams
        //                   select sp.MaSP;
        //        cbbIDProduct.Items.AddRange(data.Cast<object>().ToArray());
        //    }
        //}


        public void LoadCBBIDPr()
        {
            using (var db = new GEARSHOP_DBDataContext())
            {
                var data = from sp in db.SanPhams
                           select sp;
                cbbProduct.DisplayMember = "TenSP";
                cbbProduct.ValueMember = "MaSP";
                cbbProduct.DataSource = data.ToList();
                cbbProduct.SelectedIndexChanged += new EventHandler(cbbIDProduct_SelectedIndexChanged);
            }
        }

        private void cbbIDProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSanPham = cbbProduct.SelectedItem as SanPham;
            if (selectedSanPham != null)
            {
                txtIDProduct.Text = selectedSanPham.MaSP.ToString();
                cbbProduct.Text = selectedSanPham.TenSP;
            }
        }



        private void FrmOrderEntry_DETAIL_Load(object sender, EventArgs e)
        {
            list = ChiTietPhieuNhapBLL.LoadListCTPN(int.Parse(lbIDPN.Text)).Cast<ChiTietPhieuNhap>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListDetail.Rows.Add(list[i].MaSP, list[i].SoLuongSP, list[i].GiaNhapSP, list[i].TongTienNhapSP);
            }
            LoadCBBIDPr();
        }

        private void dgv_ListDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv_ListDetail.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuNhapBLL.DeleteCTPN(Convert.ToInt32(lbIDPN.Text), Convert.ToInt32(dgv_ListDetail.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()));
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListDetail.Rows.Clear();
                list = ChiTietPhieuNhapBLL.LoadListCTPN(int.Parse(lbIDPN.Text)).Cast<ChiTietPhieuNhap>().ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListDetail.Rows.Add(list[i].MaSP, list[i].SoLuongSP, list[i].GiaNhapSP, list[i].TongTienNhapSP); 

                }
            }
        }

        public void CheckField()
        {
            if (cbbProduct.Text.Length == 0 | txtQuantity.TextLength == 0 | txtCosts.TextLength == 0)
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
                if (MessageBox.Show("Are you sure you want to add this product? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuNhap data = new ChiTietPhieuNhap();
                    data.MaPN = Convert.ToInt32(lbIDPN.Text);
                    data.MaSP = Convert.ToInt32(txtIDProduct.Text);
                    data.SoLuongSP = Convert.ToInt32(txtQuantity.Text);
                    data.GiaNhapSP = Convert.ToDecimal(txtCosts.Text);
                    //ctpn.InsertCTPN(data.MaPN,data.MaSP, data.SoLuongSP, data.GiaNhapSP.ToString());

                    ChiTietPhieuNhapBLL.InsertCTPN(data.MaPN, data.MaSP, data.SoLuongSP, data.GiaNhapSP.ToString());
                    MessageBox.Show("Add success", title);
                    dgv_ListDetail.Rows.Clear();

                    list = ChiTietPhieuNhapBLL.LoadListCTPN(int.Parse(lbIDPN.Text)).Cast<ChiTietPhieuNhap>().ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        dgv_ListDetail.Rows.Add(list[i].MaSP, list[i].SoLuongSP, list[i].GiaNhapSP, list[i].TongTienNhapSP);
                    }
                }
                else
                {
                    MessageBox.Show("Add failed", title);
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


    }
}
