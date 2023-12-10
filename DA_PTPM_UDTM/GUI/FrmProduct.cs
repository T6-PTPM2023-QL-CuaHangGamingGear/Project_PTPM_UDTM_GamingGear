using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DAO;

namespace GUI
{
    public partial class FrmProduct : Form
    {

        //thiết lập hình ảnh
        String selectedPath;
        public string OpenFile()
        {
            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho hộp thoại chọn file
            openFileDialog.Title = "Chọn file";  // Tiêu đề của hộp thoại
            openFileDialog.Filter = "Tất cả các file (*.*)|*.*";  // Bộ lọc file (ở đây là tất cả các file)
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Thư mục mặc định để mở

            DialogResult result = openFileDialog.ShowDialog();

            // Kiểm tra kết quả trả về từ hộp thoại
            if (result == DialogResult.OK)
            {
                filePath = openFileDialog.FileName; // Lấy đường dẫn đến file đã chọn
                return filePath;
            }
            return null;
        }


        List<SanPham> list = new List<SanPham>();
        SanPhamBLL sp = new SanPhamBLL();
        public SanPham sanpham = new SanPham();
        string title = "CRUD";
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            list = SanPhamBLL.LoadListSP();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListPD.Rows.Add(list[i].MaSP, list[i].TenSP, list[i].MaLoaiSP, list[i].MaHangSX, list[i].HinhAnh, list[i].GiaSP, list[i].SoLuong, list[i].MoTa);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_ListPD.Rows.Clear();
            list = SanPhamBLL.SearchSP(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListPD.Rows.Add(list[i].MaSP, list[i].TenSP, list[i].MaLoaiSP, list[i].MaHangSX, list[i].HinhAnh, list[i].GiaSP, list[i].SoLuong, list[i].MoTa);
            }
        }

        private void GNbtn_Add_Click(object sender, EventArgs e)
        {
            FrmProduct_CURD curd = new FrmProduct_CURD(this);
            curd.txtID.Enabled = false;
            curd.btnUpdate.Visible = false;
            curd.btnSave.Visible = true;
            curd.ShowDialog();
            dgv_ListPD.Rows.Clear();
            list = SanPhamBLL.LoadListSP();
            for (int i = 0; i < list.Count; i++)
            {
                dgv_ListPD.Rows.Add(list[i].MaSP, list[i].TenSP, list[i].MaLoaiSP, list[i].MaHangSX, list[i].HinhAnh, list[i].GiaSP, list[i].SoLuong, list[i].MoTa);
            }
        }

        private void dgv_ListPD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPhamDAO spdao = new SanPhamDAO();

            string colName = dgv_ListPD.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                FrmProduct_CURD curd1 = new FrmProduct_CURD(this);
                curd1.txtID.Text = dgv_ListPD.Rows[e.RowIndex].Cells[0].Value.ToString();
                curd1.txtName.Text = dgv_ListPD.Rows[e.RowIndex].Cells[1].Value.ToString();

                //load hình ảnh

                if (File.Exists(dgv_ListPD.Rows[e.RowIndex].Cells[4].Value.ToString()))
                {
                    curd1.GN_Images.Image = Image.FromFile(dgv_ListPD.Rows[e.RowIndex].Cells[4].Value.ToString());
                    selectedPath = dgv_ListPD.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                else
                {
                    curd1.GN_Images.Image = Image.FromFile("../../../../img/error.png");
                    selectedPath = "../../../../img/error.png";
                    

                }

                spdao.getValue(dgv_ListPD.Rows[e.RowIndex].Cells[3].Value.ToString(), dgv_ListPD.Rows[e.RowIndex].Cells[2].Value.ToString());

                curd1.txtPrice.Text = dgv_ListPD.Rows[e.RowIndex].Cells[5].Value.ToString();
                curd1.txtQuantity.Text = dgv_ListPD.Rows[e.RowIndex].Cells[6].Value.ToString();
                curd1.txtNote.Text = dgv_ListPD.Rows[e.RowIndex].Cells[7].Value.ToString();
                

                curd1.txtID.Enabled = false;
                curd1.btnSave.Visible = false;
                curd1.btnUpdate.Visible = true;
                curd1.btnUpdate.Enabled = true;
                curd1.ShowDialog();
                dgv_ListPD.Rows.Clear();
                list = SanPhamBLL.LoadListSP();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListPD.Rows.Add(list[i].MaSP, list[i].TenSP, list[i].MaLoaiSP, list[i].MaHangSX, list[i].HinhAnh, list[i].GiaSP, list[i].SoLuong, list[i].MoTa);
                }
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SanPhamBLL.DeleteSP(sanpham.MaSP.ToString());
                    MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                dgv_ListPD.Rows.Clear();
                list = SanPhamBLL.LoadListSP();
                for (int i = 0; i < list.Count; i++)
                {
                    dgv_ListPD.Rows.Add(list[i].MaSP, list[i].TenSP, list[i].MaLoaiSP, list[i].MaHangSX, list[i].HinhAnh, list[i].GiaSP, list[i].SoLuong, list[i].MoTa);
                }
            }


        }

        private void dgv_ListPD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            sanpham.MaSP = int.Parse(dgv_ListPD.Rows[e.RowIndex].Cells[0].Value.ToString());

        }
    }
}
