using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using PagedList;

namespace ClientServer.Models.DAO
{
    public class DiaryDAO
    {
        private ClientServerDbContext context = null;
        public DiaryDAO()
        {
            context = new ClientServerDbContext();
        }

        public IEnumerable<NhatKiSanLuongKhoan> ListAll(int page, int pageSize)
        {
            return (context.NhatKiSanLuongKhoans.OrderByDescending(x => x.NgayThucHien).ToPagedList(page, pageSize));
        }

        public IEnumerable<NhatKiSanLuongKhoan> ListByDate(DateTime search, int page, int pageSize)
        {
            List<NhatKiSanLuongKhoan> listKQ = context.NhatKiSanLuongKhoans.Where(n => DateTime.Compare(search, n.NgayThucHien) == 0).ToList();
            return listKQ.OrderByDescending(x => x.NgayThucHien).ToPagedList(page, pageSize);
        }

        public int Insert(NhatKiSanLuongKhoan diary)
        {
            context.NhatKiSanLuongKhoans.Add(diary);
            context.SaveChanges();
            return diary.MaNhatKi;
        }

        public ExpandoObject GetById(int id)
        {
            dynamic mymodel = new ExpandoObject();
            // lấy ra nhật ký theo id
            mymodel.Diary = context.NhatKiSanLuongKhoans.SingleOrDefault(x => x.MaNhatKi == id);

            // danh sách công nhân của nhật ký
            List<DanhMucCongNhanThucHienKhoan> employeeList =
                context.DanhMucCongNhanThucHienKhoans.Where(n => n.MaNhatKi == id).ToList();

            // danh sách công việc của nhật ký
            List<DanhMucCongViecDaLam> workList = 
                context.DanhMucCongViecDaLams.Where(x => x.MaNhatKi == id).ToList();

            mymodel.EmployeeList = employeeList;
            mymodel.WorkList = workList;
            return mymodel;
        }

        public NhatKiSanLuongKhoan FindById(int id)
        {
            return context.NhatKiSanLuongKhoans.SingleOrDefault(x => x.MaNhatKi == id);
        }

        public bool Update(NhatKiSanLuongKhoan entity)
        {
            try
            {
                var diary = context.NhatKiSanLuongKhoans.Find(entity.MaNhatKi);
                diary.NgayThucHien = entity.NgayThucHien;
                diary.GioBatDau = entity.GioBatDau;
                diary.GioKetThuc = entity.GioKetThuc;
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
                var diary = context.NhatKiSanLuongKhoans.Find(id);
                context.NhatKiSanLuongKhoans.Remove(diary);
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