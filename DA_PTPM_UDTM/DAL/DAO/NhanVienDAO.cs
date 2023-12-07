using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class NhanVienDAO : DBDataContext
    {

        public static List<NhanVien> GetListNhanVien()
        {
            return db.NhanViens.ToList();
        }

        public static List<NhanVien> SearchNhanVien(String data)
        {
            return db.NhanViens.Where(nv => nv.MaNV.ToString().Contains(data.ToString()) || nv.TenNV.Contains(data.ToString())).ToList();
        }
        public bool AddNhanVien(NhanVien data)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(data);
                db.SubmitChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool UpdateNhanVien(String key, NhanVien data)
        {
            try
            {
                NhanVien NVUpdate = db.NhanViens.FirstOrDefault(nv => nv.MaNV.Equals(key));
                NVUpdate.TenNV = data.TenNV;
                NVUpdate.CCCD = data.CCCD;
                NVUpdate.DiaChi = data.DiaChi;
                NVUpdate.DienThoai = data.DienThoai;
                NVUpdate.MatKhau = data.MatKhau;
                NVUpdate.ChucVu = data.ChucVu;
                NVUpdate.GhiChu = data.GhiChu;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNhanVien(String key)
        {
            try
            {
                db.NhanViens.DeleteOnSubmit(db.NhanViens.FirstOrDefault(nv => nv.MaNV.Equals(key)));
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteNVTest(int key)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.First(nv => nv.MaNV == key);
                db.NhanViens.DeleteOnSubmit(nhanVien);
                db.SubmitChanges();
            }
            catch { }
               
        }

        public bool CheckDataTonTai(String key)
        {
            try
            {
                return db.NhanViens.FirstOrDefault(nv => nv.MaNV.Equals(key)) == null ? true : false;
            }
            catch
            {
                return false;
            }
        }


    }
}
