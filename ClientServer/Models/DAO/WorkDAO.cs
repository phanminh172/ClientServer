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
        public int Insert(DanhMucCongViec work)
        {
            context.DanhMucCongViecs.Add(work);
            context.SaveChanges();
            return work.MaCongViec;
        }
        public DanhMucCongViec GetById(int id)
        {
            return context.DanhMucCongViecs.SingleOrDefault(x => x.MaCongViec == id);
        }
        public bool Update(DanhMucCongViec entity)
        {
            try
            {
                var work = context.DanhMucCongViecs.Find(entity.MaCongViec);
                work.TenCongViec = entity.TenCongViec;
                work.HeSoKhoan = entity.HeSoKhoan;
                work.DonViKhoan = entity.DonViKhoan;
                work.DinhMucLaoDong = entity.DinhMucLaoDong;
                work.DinhMucKhoan = entity.DinhMucKhoan;
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
                var work = context.DanhMucCongViecs.Find(id);
                context.DanhMucCongViecs.Remove(work);
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