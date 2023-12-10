using DAL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuNhapBLL
    {
        public static List<ChiTietPhieuNhap> LoadListCTPN(int data)
        {
            return ChiTietPhieuNhapDAO.GetListCTPhieuNhap(data);
        }

        public static void DeleteCTPN(int data, int data1)
        {
            ChiTietPhieuNhapDAO.deleteCTPhieuNhap(data, data1);
        }
    }
}
