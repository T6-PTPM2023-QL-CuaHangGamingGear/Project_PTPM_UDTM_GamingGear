using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DAL.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }
        public string TinhTrang { get; set; }

    }
}
