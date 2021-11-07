using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //var list = context.ThongTinSanPhams.ToList();
            var list = context.Database.SqlQuery<ThongTinSanPham>("Sp_Product_ListAll").ToList();
            return list;
        }

        public int Create(string TenSanPham, string SoDangKy, DateTime? HanSuDung, string QuyCach, DateTime? NgayDangKy)
        {
            object[] parameters =
            {
                new SqlParameter("@TenSanPham",TenSanPham),
                new SqlParameter("@SoDangKy",SoDangKy),
                new SqlParameter("@HanSuDung",HanSuDung),
                new SqlParameter("@QuyCach",QuyCach),
                new SqlParameter("@NgayDangKy",NgayDangKy),
            };
            int res = context.Database.ExecuteSqlCommand("Sp_Product_Insert @TenSanPham, @SoDangKy, @HanSuDung, @QuyCach, @NgayDangKy", parameters);
            return res;
        }
    }
}