using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
namespace BLL
{
    internal class HomeBLL
    {
        HomeDAO profitDAO = new HomeDAO();
        public static int CountNV()
        {
            return HomeDAO.CountListNV();
        }
    }
}
