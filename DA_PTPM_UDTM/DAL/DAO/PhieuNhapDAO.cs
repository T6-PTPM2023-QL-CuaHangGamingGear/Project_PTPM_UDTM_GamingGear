using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PhieuNhapDAO : DBDataContext
    {
        public static List<PhieuNhap> GetListPhieuNhap()
        {
            return db.PhieuNhaps.ToList();
        }
        public static List<PhieuNhap> SearchPhieuNhap(String data)
        {
            return db.PhieuNhaps.Where(nv => nv.MaPN.ToString().Contains(data.ToString()) || nv.MaNV.ToString().Contains(data.ToString())).ToList();
        }

    }
}
