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

        public static void InsertCTPN(int data, int? data1, int? data2, string data3)
        {
            ChiTietPhieuNhapDAO.insertCTPhieuNhap(data, data1, data2, data3);
        }
    }
}
