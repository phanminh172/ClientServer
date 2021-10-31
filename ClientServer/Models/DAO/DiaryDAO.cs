using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class DiaryDAO
    {
        private ClientServerDbContext context = null;
        public DiaryDAO()
        {
            context = new ClientServerDbContext();
        }
        public List<NhatKiSanLuongKhoan> ListAll()
        {
            var list = context.NhatKiSanLuongKhoans.ToList();
            return list;
        }
    }
}