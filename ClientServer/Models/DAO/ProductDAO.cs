using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;

namespace ClientServer.Models.DAO
{
    public class ProductDAO
    {
        private ClientServerDbContext context = null;
        public ProductDAO()
        {
            context = new ClientServerDbContext();
        }
        public IEnumerable<ThongTinSanPham> ListAll(int? sortOrder, DateTime? searchDate, String searchString, int page, int pageSize)
        {
                if (searchString != null)
            {
                List<ThongTinSanPham> listKQ = context.ThongTinSanPhams.Where(n => n.TenSanPham.Contains(searchString)).ToList();
                if (sortOrder != null)
                {
                    object[] parameters =
                    {
                        new SqlParameter("@name", searchString),
                        new SqlParameter("@date", searchDate.ToString())
                    };
                    switch (sortOrder)
                    {
                        case 1:
                            return context.Database
                                .SqlQuery<ThongTinSanPham>("exec Sp_searchNgayDangKi @date,@name", parameters)
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 2:
                            return context.Database
                                .SqlQuery<ThongTinSanPham>("exec Sp_searchHSD @name",parameters)
                                .ToList()
                                .ToPagedList(page, pageSize);
                        default:
                            return listKQ.OrderBy(x => x.MaSanPham).ToPagedList(page, pageSize);
                    }
                }

                return listKQ.OrderBy(x => x.MaSanPham).ToPagedList(page, pageSize);
            }

            return (context.ThongTinSanPhams.OrderBy(x => x.MaSanPham).ToPagedList(page, pageSize));

        }
        public int Insert(ThongTinSanPham product)
        {
            context.ThongTinSanPhams.Add(product);
            context.SaveChanges();
            return product.MaSanPham;
        }
        public ThongTinSanPham GetById(int id)
        {
            return context.ThongTinSanPhams.SingleOrDefault(x => x.MaSanPham == id);
        }
        public bool Update(ThongTinSanPham entity)
        {
            try
            {
                var product = context.ThongTinSanPhams.Find(entity.MaSanPham);
                product.TenSanPham = entity.TenSanPham;
                product.SoDangKy = entity.SoDangKy;
                product.HanSuDung = entity.HanSuDung;
                product.QuyCach = entity.QuyCach;
                product.NgayDangKy = entity.NgayDangKy;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var product = context.ThongTinSanPhams.Find(id);
                context.ThongTinSanPhams.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ThongTinSanPham> DropDownList()
        {
            return context.ThongTinSanPhams.ToList();
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
        //public ThongTinSanPham GetById(int productId)
        //{
        //    return context.ThongTinSanPhams.SingleOrDefault(x => x.MaSanPham == productId);
        //}
        public ThongTinSanPham ViewDetail(int id)
        {
            return context.ThongTinSanPhams.Find(id);
        }

    }

}