using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace ClientServer.Models.DAO
{
    public class WorkDAO
    {
        private ClientServerDbContext context = null;
        public WorkDAO()
        {
            context = new ClientServerDbContext();
        }
        public IEnumerable<DanhMucCongViec> ListAll(int? sortOrder, String searchString, int page, int pageSize)
        {
            if (searchString != null)
            {
                List<DanhMucCongViec> listKQ = context.DanhMucCongViecs.Where(n => n.TenCongViec.Contains(searchString)).ToList();
                if (sortOrder != null)
                {

                    switch (sortOrder)
                    {
                        case 1:
                            return context.Database
                                .SqlQuery<DanhMucCongViec>("exec Sp_MaxDiary")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 2:
                            return context.Database
                                .SqlQuery<DanhMucCongViec>("exec Sp_MaxValue")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 3:
                            return context.Database
                                .SqlQuery<DanhMucCongViec>("exec Sp_MinValue")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 4:
                            return context.Database
                                .SqlQuery<DanhMucCongViec>("exec Sp_higherAvg")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 5:
                            return context.Database
                                .SqlQuery<DanhMucCongViec>("exec Sp_lowerAvg")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        default:
                            return listKQ.OrderBy(x => x.MaCongViec).ToPagedList(page, pageSize);
                    }
                }
                return listKQ.OrderBy(x => x.MaCongViec).ToPagedList(page, pageSize);
            }
            return (context.DanhMucCongViecs.OrderBy(x => x.MaCongViec).ToPagedList(page, pageSize));
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

        public List<DanhMucCongViec> DropDownList()
        {
            return context.DanhMucCongViecs.ToList();
        }
    }
}