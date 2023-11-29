using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DTO;
using DAL.DAO;
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
        public void DeleteNV(string text)
        {
            nvdao.DeleteNhanVien(text);
        }

    }
}
