using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class EmployeeInDiaryDAO
    {
        private ClientServerDbContext context = null;

        public EmployeeInDiaryDAO()
        {
            context = new ClientServerDbContext();
        }

        public int Insert(DanhMucCongNhanThucHienKhoan employee)
        {
            context.DanhMucCongNhanThucHienKhoans.Add(employee);
            context.SaveChanges();
            return employee.MaDanhMucCongNhanThucHienKhoan;
        }

        public DanhMucCongNhanThucHienKhoan GetById(int id)
        {
            return context.DanhMucCongNhanThucHienKhoans.SingleOrDefault(x => x.MaDanhMucCongNhanThucHienKhoan == id);
        }
        public bool Update(DanhMucCongNhanThucHienKhoan entity)
        {
            try
            {
                var employee = context.DanhMucCongNhanThucHienKhoans.Find(entity.MaDanhMucCongNhanThucHienKhoan);
                employee.MaNhatKi = entity.MaNhatKi;
                employee.MaCongNhan = entity.MaCongNhan;
                employee.ThoiGianBatDauCongViec = entity.ThoiGianBatDauCongViec;
                employee.ThoiGianKetThucCongViec = entity.ThoiGianKetThucCongViec;
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
                var employee = context.DanhMucCongNhanThucHienKhoans.Find(id);
                context.DanhMucCongNhanThucHienKhoans.Remove(employee);
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