using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class HomeDAO : DBDataContext
    {

        public static int CountListNV()
        {
            int count = db.GetTable<NhanVien>().Count();
            return count;
        }

        public static int CountListKH()
        {
            int count = db.GetTable<KhachHang>().Count();
            return count;
        }
        public static int CountListSP()
        {
            int count = db.GetTable<SanPham>().Count();
            return count;
        }
        public static int CountListPN()
        {
            int count = db.GetTable<PhieuNhap>().Count();
            return count;
        }
    }
}
