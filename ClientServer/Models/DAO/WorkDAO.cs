using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class WorkDAO
    {
        private ClientServerDbContext context = null;
        public WorkDAO()
        {
            context = new ClientServerDbContext();
        }
        public List<DanhMucCongViec> ListAll()
        {
            var list = context.DanhMucCongViecs.ToList();
            return list;
        }
    }
}