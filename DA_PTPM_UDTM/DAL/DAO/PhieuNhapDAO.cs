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
            return db.KhachHangs.ToList();
        }
    }
}
