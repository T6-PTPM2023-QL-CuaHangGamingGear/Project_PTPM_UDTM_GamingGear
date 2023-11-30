using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;

using System.Data;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAO nvdao = new NhanVienDAO();
        public void AddNV(NhanVien NV)
        {
            nvdao.AddNhanVien(NV);
        }
        public void UpdateNV(string text, NhanVien NV)
        {
            nvdao.UpdateNhanVien(text, NV);
        }
        public static void DeleteNV(string text)
        {
            //nvdao.DeleteNhanVien(text);
            NhanVienDAO.DeleteNVTest(text);
        }
        public static List<NhanVien> LoadListNV()
        {
            return NhanVienDAO.GetListNhanVien();
        }
        public static List<NhanVien> SearchNV(string text)
        {
            return NhanVienDAO.SearchNhanVien(text);
        }

    }
}
