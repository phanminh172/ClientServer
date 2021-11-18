using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class WorkInDiaryDAO
    {
        private ClientServerDbContext context = null;

        public WorkInDiaryDAO()
        {
            context = new ClientServerDbContext();
        }

        public int Insert(DanhMucCongViecDaLam work)
        {
            context.DanhMucCongViecDaLams.Add(work);
            context.SaveChanges();
            return work.MaDanhMucCongViecDaLam;
        }

        public DanhMucCongViecDaLam GetById(int id)
        {
            return context.DanhMucCongViecDaLams.SingleOrDefault(x => x.MaDanhMucCongViecDaLam == id);
        }
        public bool Update(DanhMucCongViecDaLam entity)
        {
            try
            {
                var employee = context.DanhMucCongViecDaLams.Find(entity.MaDanhMucCongViecDaLam);
                employee.MaNhatKi = entity.MaNhatKi;
                employee.MaCongViec = entity.MaCongViec;
                employee.MaSanPham = entity.MaSanPham;
                employee.SanLuongThucTe = entity.SanLuongThucTe;
                employee.SoLoSanPham = entity.SoLoSanPham;
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
                var employee = context.DanhMucCongViecDaLams.Find(id);
                context.DanhMucCongViecDaLams.Remove(employee);
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