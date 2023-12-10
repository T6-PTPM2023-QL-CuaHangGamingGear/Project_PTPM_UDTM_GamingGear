using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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

        public bool AddPhieuNhap(PhieuNhap data)
        {
            try
            {
                db.PhieuNhaps.InsertOnSubmit(data);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
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


        public bool UpdatePhieuNhap(String key, PhieuNhap data)
        {
            try
            {
                PhieuNhap PNUpdate = db.PhieuNhaps.FirstOrDefault(nv => nv.MaPN.Equals(key));
                PNUpdate.MaNCC = data.MaNCC;
                PNUpdate.MaNV = data.MaNV;
                PNUpdate.NgayNhap = data.NgayNhap;
                PNUpdate.TongTienPN = data.TongTienPN;
                PNUpdate.GhiChu = data.GhiChu;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeletePhieuNhap(String key)
        {
            try
            {
                PhieuNhap phieuNhap = db.PhieuNhaps.First(nv => nv.MaPN.ToString() == key);
                db.PhieuNhaps.DeleteOnSubmit(phieuNhap);
                db.SubmitChanges();
            }
            catch { }
        }






        //cbb NCC vs USER
        static List<NhanVienDTO> listNhanVien = new List<NhanVienDTO>();
        static List<NhaCungCapDTO> listNhaCungCap = new List<NhaCungCapDTO>();
        static NhanVienDTO valueCbNhanVien = new NhanVienDTO();
        static NhaCungCapDTO valueCbNhaCungCap = new NhaCungCapDTO();

        public List<NhanVienDTO> tenNhanVien()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            var query = from tnv in db.NhanViens
                        select tnv;
            foreach (var tnv in query)
            {
                NhanVienDTO tnvDTO = new NhanVienDTO();
                tnvDTO.MaNV = tnv.MaNV;
                tnvDTO.TenNV = tnv.TenNV;
                listNhanVien.Add(tnvDTO);
                list.Add(tnvDTO);
            }
            return list;
        }

        public List<NhaCungCapDTO> tenNhaCungCap()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            var query = from tncc in db.NhaCungCaps
                        select tncc;
            foreach (var tncc in query)
            {
                NhaCungCapDTO tnccDTO = new NhaCungCapDTO();
                tnccDTO.MaNhaCungCap = tncc.MaNCC;
                tnccDTO.TenNhaCungCap = tncc.TenNCC;
                listNhaCungCap.Add(tnccDTO);
                list.Add(tnccDTO);
            }
            return list;
        }

        public int? GetValueTenNV(string tennv)
        {
            listNhanVien.Clear();
            listNhanVien = tenNhanVien();
            var valueCbNhanVien = listNhanVien.Find(x => x.TenNV == tennv);
            return valueCbNhanVien?.MaNV;
        }

        public int? GetValueTenNCC(string tenncc)
        {
            listNhaCungCap.Clear();
            listNhaCungCap = tenNhaCungCap();
            var valueCbNhaCungCap = listNhaCungCap.Find(x => x.TenNhaCungCap == tenncc);
            return valueCbNhaCungCap?.MaNhaCungCap;
        }

        public NhanVienDTO returnValueTenNV()
        {
            return valueCbNhanVien;
        }
        public NhaCungCapDTO returnValueNhaCungCap()
        {
            return valueCbNhaCungCap;
        }

    }
}
