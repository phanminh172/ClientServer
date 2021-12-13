using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;

namespace ClientServer.Models.DAO
{
    
    public class EmployeeDAO
    {
        private ClientServerDbContext context = null;
        public EmployeeDAO()
        {
            context = new ClientServerDbContext();
        }
        public IEnumerable<ThongTinCongNhan> ListAll(string searchPhongBan, string searchChucVu,
            string fromAge, string toAge, String searchString, int page = 1, int pageSize = 5)
        {
            object[] parameters =
                {
                new SqlParameter("@PhongBan", searchPhongBan),
                new SqlParameter("@ChucVu", searchChucVu),
                new SqlParameter("@fromAge", fromAge),
                new SqlParameter("@toAge", toAge),
                new SqlParameter("@name", searchString),
                };
            if (searchString != null)
            {
                if (fromAge != "" && toAge != "")
                {
                    return context.Database
                  .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListFilter @name,@PhongBan,@ChucVu,@fromAge,@toAge", parameters)
                  .ToList()
                  .ToPagedList(page, pageSize);
                }
                if (fromAge != "" && toAge == "")
                {
                    return context.Database
                  .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListFilterLeft @name,@PhongBan,@ChucVu,@fromAge", parameters)
                  .ToList()
                  .ToPagedList(page, pageSize);
                }
                if (fromAge == "" && toAge != "")
                {
                    return context.Database
                  .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListFilterRight @name,@PhongBan,@ChucVu,@toAge", parameters)
                  .ToList()
                  .ToPagedList(page, pageSize);
                }
                return context.Database
                  .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListAll @name,@PhongBan,@ChucVu", parameters)
                  .ToList()
                  .ToPagedList(page, pageSize);
            }
            return context.Database
              .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListAllNonParam")
              .ToList()
              .ToPagedList(page, pageSize);
        }

        public int Insert(ThongTinCongNhan employee)
        {
            context.ThongTinCongNhans.Add(employee);
            context.SaveChanges();
            return employee.MaCongNhan;
        }
        public ThongTinCongNhan GetById(int id)
        {
            return context.ThongTinCongNhans.FirstOrDefault(x => x.MaCongNhan == id);
        }
        public bool Update(ThongTinCongNhan entity)
        {
            try
            {
                var employee = context.ThongTinCongNhans.Find(entity.MaCongNhan);
                employee.Hoten = entity.Hoten;
                employee.GioiTinh = entity.GioiTinh;
                employee.NgaySinh = entity.NgaySinh;
                employee.QueQuan = entity.QueQuan;
                employee.LuongBaoHiem = entity.LuongBaoHiem;
                employee.LuongHopDong = entity.LuongHopDong;
                employee.PhongBan = entity.PhongBan;
                employee.ChucVu = entity.ChucVu;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var employee = context.ThongTinCongNhans.Find(id);
                context.ThongTinCongNhans.Remove(employee);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public List<ThongTinCongNhan> DropDownList()
        {
            return context.ThongTinCongNhans.ToList();
        }
    }
}