using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
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
        public IEnumerable<ThongTinSanPham> ListAll(String searchString,int page, int pageSize)
        {
            if (searchString != null)
            {
                List<ThongTinSanPham> listKQ = context.ThongTinSanPhams.Where(n => n.TenSanPham.Contains(searchString)).ToList();
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
    }
}