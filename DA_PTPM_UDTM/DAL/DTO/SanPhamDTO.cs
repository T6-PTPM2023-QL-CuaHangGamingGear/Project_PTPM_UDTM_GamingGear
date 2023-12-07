using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaLoaiSP { get; set; }
        public int MaHangSX { get; set; }
        public string HinhAnh { get; set; }
        public double GiaSP { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
    }
}
