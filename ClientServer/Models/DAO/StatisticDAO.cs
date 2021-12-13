using ClientServer.Areas.Admin.Models;
using ClientServer.Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public IEnumerable<DiaryModel> WeekDiary(int? sortOrder, string searchString, DateTime? date, int page, int pageSize)
        {
            if (searchString != null && sortOrder != null)
            {
                object[] parameters =
                {
                new SqlParameter("@maCN", searchString),
                new SqlParameter("@date", date.ToString())
                };
                if (searchString == "")
                {
                    switch (sortOrder)
                    {
                        case 1:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_MonthDiaryAll")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 2:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_WeekDiaryAll @date", parameters)
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 3:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_nkslkC3")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        default:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
                                .ToList()
                                .ToPagedList(page, pageSize);
                    }
                }
                switch (sortOrder)
                {
                    case 1:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_MonthDiary @maCN", parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 2:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_WeekDiary @maCN, @date", parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    default:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
                            .ToList()
                            .ToPagedList(page, pageSize);
                }
            }
            return context.Database
              .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
              .ToList()
              .ToPagedList(page, pageSize);

        }

        public IEnumerable<ThongTinCongNhan> StatisticEmployee(int page, int pageSize)
        {
            //if (searchString != null && sortOrder != null)
            //{
            //    object[] parameters =
            //    {
            //    new SqlParameter("@maCN", searchString),
            //    new SqlParameter("@date", date.ToString())
            //    };
            //    if (searchString == "")
            //    {
            //        switch (sortOrder)
            //        {
            //            case 1:
            //                return context.Database
            //                    .SqlQuery<DiaryModel>("exec Sp_MonthDiaryAll")
            //                    .ToList()
            //                    .ToPagedList(page, pageSize);
            //            case 2:
            //                return context.Database
            //                    .SqlQuery<DiaryModel>("exec Sp_WeekDiaryAll @date", parameters)
            //                    .ToList()
            //                    .ToPagedList(page, pageSize);
            //            case 3:
            //                return context.Database
            //                    .SqlQuery<DiaryModel>("exec Sp_nkslkC3")
            //                    .ToList()
            //                    .ToPagedList(page, pageSize);
            //            default:
            //                return context.Database
            //                    .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
            //                    .ToList()
            //                    .ToPagedList(page, pageSize);
            //        }
            //    }
            //    switch (sortOrder)
            //    {
            //        case 1:
            //            return context.Database
            //                .SqlQuery<DiaryModel>("exec Sp_MonthDiary @maCN", parameters)
            //                .ToList()
            //                .ToPagedList(page, pageSize);
            //        case 2:
            //            return context.Database
            //                .SqlQuery<DiaryModel>("exec Sp_WeekDiary @maCN, @date", parameters)
            //                .ToList()
            //                .ToPagedList(page, pageSize);
            //        default:
            //            return context.Database
            //                .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
            //                .ToList()
            //                .ToPagedList(page, pageSize);
            //    }
            //}
            return context.Database
              .SqlQuery<ThongTinCongNhan>("exec Sp_Employee_ListAll")
              .ToList()
              .ToPagedList(page, pageSize);

        }
        //public IEnumerable<SalaryModel> ListSalaryMonth(string startDate, string endDate, int pageIndex = 1, int pageSize = 2)
        //{
        //    var model = from nksl in context.NhatKiSanLuongKhoans
        //                join dmcvdl in context.DanhMucCongViecDaLams on nksl.MaNhatKi equals dmcvdl.MaNhatKi into nksldmcvdl
        //                from dmcvdl in nksldmcvdl.DefaultIfEmpty()
        //                //from dmcvdl in context.DanhMucCongViecDaLams
        //                join dmcv in context.DanhMucCongViecs on dmcvdl.MaCongViec equals dmcv.MaCongViec into dmcvdldmcv
        //                from dmcv in dmcvdldmcv.DefaultIfEmpty()
        //                join dmcnk in context.DanhMucCongNhanThucHienKhoans on nksl.MaNhatKi equals dmcnk.MaNhatKi into nksldmcnk
        //                from dmcnk in nksldmcnk.DefaultIfEmpty()
        //                join dmcn in context.ThongTinCongNhans on dmcnk.MaCongNhan equals dmcn.MaCongNhan into dmcnkdmcn
        //                from dmcn in dmcnkdmcn.DefaultIfEmpty()
        //                orderby dmcnk.MaNhatKi
        //                select new
        //                {
        //                    MaCongNhan = dmcn.MaCongNhan,
        //                    NgayThucHien = nksl.NgayThucHien,
        //                    MaCongViec = dmcv.MaCongViec,
        //                    HoTen=dmcn.Hoten,
        //                    PhongBan=dmcn.PhongBan,
        //                    ChucVu=dmcn.ChucVu,
        //                    GioiTinh=dmcn.GioiTinh,
        //                    DonGia=dmcv.DonGia,
        //                    SanLuongThucTe=dmcvdl.SanLuongThucTe,
        //                    LuongHopDong=dmcn.LuongHopDong
        //                };
        //    //model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.OrderBy(x => x.MaCongViec).ToPagedList(pageIndex, pageSize); 
        //}
    }
}