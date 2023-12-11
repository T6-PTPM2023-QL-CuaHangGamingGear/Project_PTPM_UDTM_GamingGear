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

        public static void insertCTPhieuNhap(int MaPN, int? MaSP, int? soluongSP, string gianhapSP)
        {
            using (var db = new GEARSHOP_DBDataContext())
            {
                string query = "INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongSP, GiaNhapSP) VALUES (" + MaPN + ", " + MaSP + ", " + soluongSP + ", " + gianhapSP + ");";
                db.ExecuteCommand(query);

                string triggerQuery = "UPDATE ChiTietPhieuNhap SET MaSP = MaSP WHERE MaPN = " + MaPN + ";";
                db.ExecuteCommand(triggerQuery);
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
