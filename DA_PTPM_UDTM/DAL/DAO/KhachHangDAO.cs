using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class KhachHangDAO : DBDataContext
    {
        public static List<KhachHang> GetListKhachHang()
        {
            return db.KhachHangs.ToList();
        }
        public static List<KhachHang> SearchKhachHang(string data)
        {
            return db.KhachHangs.Where(nv => nv.MaKH.Contains(data) || nv.TenKH.Contains(data)).ToList();
        }
        public bool AddKhachHang(KhachHang data)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(data);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateKhachHang(String key, KhachHang data)
        {
            try
            {
                KhachHang KHUpdate = db.KhachHangs.FirstOrDefault(nv => nv.MaKH.Equals(key));
                KHUpdate.TenKH = data.TenKH;
                KHUpdate.SDT = data.SDT;
                KHUpdate.Email = data.Email;
                KHUpdate.NgaySinh = data.NgaySinh;
                KHUpdate.MatKhau = data.MatKhau;
                KHUpdate.DiaChi = data.DiaChi;
                KHUpdate.TinhTrang = data.TinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteKhachHang(String key)
        {
            try
            {
                KhachHang KHDelete = db.KhachHangs.First(nv => nv.MaKH == key);
                db.KhachHangs.DeleteOnSubmit(KHDelete);
                db.SubmitChanges();
            }
            catch { }

        }
    }
}
