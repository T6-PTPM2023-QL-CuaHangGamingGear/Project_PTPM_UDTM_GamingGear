using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SanPhamDAO : DBDataContext
    {
 
        static LoaiSP_DTO valueCbLoai = new LoaiSP_DTO();
        static HangSX_DTO valueCbHang = new HangSX_DTO();
        static List<LoaiSP_DTO> listLoaiSP = new List<LoaiSP_DTO>();
        static List<HangSX_DTO> listHangSX = new List<HangSX_DTO>();

        public static List<SanPham> GetListSanPham()
        {
            return db.SanPhams.ToList();
        }

        public static List<SanPham> SearchSanPham(String data)
        {
            return db.SanPhams.Where(sp => sp.MaSP.ToString().Contains(data.ToString()) || sp.TenSP.Contains(data.ToString())).ToList();
        }

        public bool AddSanPham(SanPham data)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(data);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSanPham(String key, SanPham data)
        {
            try
            {
                SanPham SPUpdate = db.SanPhams.FirstOrDefault(nv => nv.MaSP.Equals(key));
                SPUpdate.TenSP = data.TenSP;
                SPUpdate.MaLoaiSP = data.MaLoaiSP;
                SPUpdate.MaHangSX = data.MaHangSX;
                SPUpdate.HinhAnh = data.HinhAnh;
                SPUpdate.GiaSP = data.GiaSP;
                SPUpdate.SoLuong = data.SoLuong;
                SPUpdate.MoTa = data.MoTa;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteSanPham(String key)
        {
            try
            {
                SanPham sanPham = db.SanPhams.First(nv => nv.MaSP.ToString() == key);
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
            }
            catch { }

        }


        //CBB Loại SP vs Hãng SX

        public List<LoaiSP_DTO> tenLoaiSP()
        {
            List<LoaiSP_DTO> list = new List<LoaiSP_DTO>();
            var query = from lsp in db.LoaiSPs
                        select lsp;
            foreach (var lsp in query)
            {
                LoaiSP_DTO lspDTO = new LoaiSP_DTO();
                lspDTO.MaLoaiSP = lsp.MaLoaiSP;
                lspDTO.TenLoaiSP = lsp.TenLoaiSP;
                listLoaiSP.Add(lspDTO);
                list.Add(lspDTO);
            }
            return list;
        }

        public List<HangSX_DTO> tenHangSX()
        {
            List<HangSX_DTO> list = new List<HangSX_DTO>();
            var query = from lsp in db.HangSXes
                        select lsp;
            foreach (var lsp in query)
            {
                HangSX_DTO hspDTO = new HangSX_DTO();
                hspDTO.MaHangSX = lsp.MaHangSX;
                hspDTO.TenHangSX = lsp.TenHangSX;
                listHangSX.Add(hspDTO);
                list.Add(hspDTO);
            }
            return list;
        }

        //public void getValue(string loaisp, string hangsx)
        //{
        //    listHangSX.Clear();
        //    listLoaiSP.Clear();
        //    listHangSX = tenHangSX();
        //    listLoaiSP = tenLoaiSP();
        //    valueCbHang = listHangSX.Find(x => x.TenHangSX == hangsx);
        //    valueCbLoai = listLoaiSP.Find(x => x.TenLoaiSP == loaisp);
        //}


        //public void getValueLoaiSP(string loaisp)
        //{
        //    listLoaiSP.Clear();
        //    listLoaiSP = tenLoaiSP();
        //    valueCbLoai = listLoaiSP.Find(x => x.TenLoaiSP == loaisp);
        //}



        public int? GetValueLoaiSP(string loaisp)
        {
            listLoaiSP.Clear();
            listLoaiSP = tenLoaiSP();
            var valueCbLoai = listLoaiSP.Find(x => x.TenLoaiSP == loaisp);
            return valueCbLoai?.MaLoaiSP;
        }


        public int? GetValueHangSX(string hangsx)
        {
            listHangSX.Clear();
            listHangSX = tenHangSX();
            var valueCbHang = listHangSX.Find(x => x.TenHangSX == hangsx);
            return valueCbHang?.MaHangSX;
        }

        public HangSX_DTO returnValueHang()
        {
            return valueCbHang;
        }
        public LoaiSP_DTO returnValueLoai()
        {
            return valueCbLoai;
        }
    }
}
