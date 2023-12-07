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
        public static List<KhachHang> SearchKhachHang(int data)
        {
            return db.KhachHangs.Where(nv => nv.MaKH.ToString().Contains(data.ToString()) || nv.TenKH.Contains(data.ToString())).ToList();
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
                KHUpdate.DiaChi = data.DiaChi;
                KHUpdate.DienThoai = data.DienThoai;
                KHUpdate.Email = data.Email;
                KHUpdate.MatKhau = data.MatKhau;
                KHUpdate.GhiChu = data.GhiChu;
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
                KhachHang KHDelete = db.KhachHangs.First(nv => nv.MaKH.ToString() == key);
                db.KhachHangs.DeleteOnSubmit(KHDelete);
                db.SubmitChanges();
            }
            catch { }

        }
    }
}
