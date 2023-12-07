using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.DTO;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAO spdao = new SanPhamDAO();

        public void AddSP(SanPham SP)
        {
            spdao.AddSanPham(SP);
        }
        public void UpdateSP(string text, SanPham SP)
        {
            spdao.UpdateSanPham(text, SP);
        }
        public static void DeleteSP(string text)
        {
            SanPhamDAO.DeleteSanPham(text);
        }
        public static List<SanPham> LoadListSP()
        {
            return SanPhamDAO.GetListSanPham();
        }
        public static List<SanPham> SearchSP(string text)
        {
            return SanPhamDAO.SearchSanPham(text);
        }
       
    }
}
