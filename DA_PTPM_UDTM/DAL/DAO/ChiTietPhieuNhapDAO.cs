using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class ChiTietPhieuNhapDAO : DBDataContext
    {
        public static List<ChiTietPhieuNhap> GetListCTPhieuNhap(int data)
        {
            List<ChiTietPhieuNhap> list = new List<ChiTietPhieuNhap>();
            list = db.ChiTietPhieuNhaps.Where(x => x.MaPN == data).ToList();
            return list;
        }

        public bool insertCTPhieuNhap(int MaPN, int MaSP, string soluongSP, string gianhapSP)
        {
            try
            {
                using (var db = new GEARSHOP_DBDataContext())
                {
                    string query = "Exec Insert_ChiTietPhieuNhap '" + MaPN + "','" + MaSP + "' ,'" + soluongSP + "', '" + gianhapSP + "'";
                    db.ExecuteCommand(query);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void deleteCTPhieuNhap(int MaPN, int MaSP)
        {
            using (var db = new GEARSHOP_DBDataContext())
            {
                string query = "DELETE FROM ChiTietPhieuNhap WHERE MaPN = " + MaPN + " AND MaSP = " + MaSP;
                db.ExecuteCommand(query);
            }


        }

    }
}
