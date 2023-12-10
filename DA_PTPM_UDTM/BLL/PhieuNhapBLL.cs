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
    public class PhieuNhapBLL
    {
        PhieuNhapDAO pndao = new PhieuNhapDAO();
        public void AddPN(PhieuNhap PN)
        {
            pndao.AddPhieuNhap(PN);
        }
        public void UpdatePn(string text, PhieuNhap PN)
        {
            pndao.UpdatePhieuNhap(text, PN);
        }
        public static void DeletePN(string text)
        {
            PhieuNhapDAO.DeletePhieuNhap(text);
        }
        public static List<PhieuNhap> LoadListPN()
        {
            return PhieuNhapDAO.GetListPhieuNhap();
        }

        public static List<ChiTietPhieuNhap> LoadListCTPN(int data)
        {
            return PhieuNhapDAO.GetListCTPhieuNhap(data);
        }


        public static List<PhieuNhap> SearchPN(string text)
        {
            return PhieuNhapDAO.SearchPhieuNhap(text);
        }
    }
}
