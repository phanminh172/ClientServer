using ClientServer.Areas.Admin.Models;
using ClientServer.Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class StatisticDAO
    {
        ClientServerDbContext context;
        public StatisticDAO()
        {
            context = new ClientServerDbContext();
        }
        public IEnumerable<SalaryModel> ListSalary(string startDate, string endDate, int pageIndex = 1, int pageSize = 2)
        {
            var model = from nksl in context.NhatKiSanLuongKhoans
                        join dmcvdl in context.DanhMucCongViecDaLams on nksl.MaNhatKi equals dmcvdl.MaNhatKi into nksldmcvdl
                        from dmcvdl in nksldmcvdl.DefaultIfEmpty()
                        //from dmcvdl in context.DanhMucCongViecDaLams
                        join dmcv in context.DanhMucCongViecs on dmcvdl.MaCongViec equals dmcv.MaCongViec into dmcvdldmcv
                        from dmcv in dmcvdldmcv.DefaultIfEmpty()
                        join dmcnk in context.DanhMucCongNhanThucHienKhoans on nksl.MaNhatKi equals dmcnk.MaNhatKi into nksldmcnk
                        from dmcnk in nksldmcnk.DefaultIfEmpty()
                        join dmcn in context.ThongTinCongNhans on dmcnk.MaCongNhan equals dmcn.MaCongNhan into dmcnkdmcn
                        from dmcn in dmcnkdmcn.DefaultIfEmpty()
                        orderby dmcnk.MaNhatKi
                        select new
                        {
                            MaCongNhan = dmcn.MaCongNhan,
                            NgayThucHien = nksl.NgayThucHien,
                            MaCongViec = dmcv.MaCongViec,
                            HoTen=dmcn.Hoten,
                            PhongBan=dmcn.PhongBan,
                            ChucVu=dmcn.ChucVu,
                            GioiTinh=dmcn.GioiTinh,
                            DonGia=dmcv.DonGia,
                            SanLuongThucTe=dmcvdl.SanLuongThucTe,
                            LuongHopDong=dmcn.LuongHopDong
                        };
            //model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.OrderBy(x => x.MaCongViec).ToPagedList(pageIndex, pageSize); 
        }
    }
}