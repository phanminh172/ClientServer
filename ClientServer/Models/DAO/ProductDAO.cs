using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class ProductDAO
    {
        private ClientServerDbContext context = null;
        public ProductDAO()
        {
            context = new ClientServerDbContext();
        }
        public List<ThongTinSanPham> ListAll()
        {
            var list = context.Database.SqlQuery<ThongTinSanPham>("Sp_Product_ListAll").ToList();
            return list;
        }
    }
}