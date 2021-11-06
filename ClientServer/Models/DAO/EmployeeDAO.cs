using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class EmployeeDAO
    {
        private ClientServerDbContext context = null;
        public EmployeeDAO()
        {
            context = new ClientServerDbContext();
        }
        public List<ThongTinCongNhan> ListAll()
        {
            var list = context.ThongTinCongNhans.ToList();
            return list;
        }
    }
}