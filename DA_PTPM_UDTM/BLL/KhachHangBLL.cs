using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAO khdao = new KhachHangDAO();
        public void AddKH(KhachHang KH)
        {
            khdao.AddKhachHang(KH);
        }
        public void UpdateKH(string text, KhachHang KH)
        {
            khdao.UpdateKhachHang(text, KH);
        }
        public static void DeleteKH(string text)
        {
            KhachHangDAO.DeleteKhachHang(text);
        }
        public static List<KhachHang> LoadListKH()
        {
            return KhachHangDAO.GetListKhachHang();
        }
        public static List<KhachHang> SearchKH(string text)
        {
            return KhachHangDAO.SearchKhachHang(text);
        }
    }
}
