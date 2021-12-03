using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
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
        public IEnumerable<ThongTinCongNhan> ListAll(String searchString, int page, int pageSize)
        {
            if (searchString != null)
            {
                List<ThongTinCongNhan> listKQ = context.ThongTinCongNhans.Where(n => n.Hoten.Contains(searchString)).ToList();
                return listKQ.OrderBy(x => x.MaCongNhan).ToPagedList(page, pageSize);
            }
            return (context.ThongTinCongNhans.OrderBy(x => x.MaCongNhan).ToPagedList(page, pageSize));
        }

        public int Insert(ThongTinCongNhan employee)
        {
            context.ThongTinCongNhans.Add(employee);
            context.SaveChanges();
            return employee.MaCongNhan;
        }
        public ThongTinCongNhan GetById(int id)
        {
            return context.ThongTinCongNhans.SingleOrDefault(x => x.MaCongNhan == id);
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