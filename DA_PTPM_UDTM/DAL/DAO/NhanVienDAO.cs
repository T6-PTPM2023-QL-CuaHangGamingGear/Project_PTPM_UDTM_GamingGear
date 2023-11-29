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

        public List<NhanVien> GetListNhanVien()
        {
            return db.NhanViens.ToList();
        }

        public List<NhanVien> SearchNhanVien(string data)
        {
            return db.NhanViens.Where(nv => nv.MaNV.Contains(data)|| nv.TenNV.Contains(data)).ToList();
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
                NVUpdate.GioiTinh = data.GioiTinh;
                NVUpdate.SDT = data.SDT;
                NVUpdate.NgaySinh = data.NgaySinh;
                NVUpdate.MatKhau = data.MatKhau;
                NVUpdate.ChucVu = data.ChucVu;
                NVUpdate.TinhTrang = data.TinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
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
