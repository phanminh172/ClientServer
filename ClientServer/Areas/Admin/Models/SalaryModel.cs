using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientServer.Areas.Admin.Models
{
    public class SalaryModel:ThongTinCongNhan
    {
        
        public int SanLuongThucTe { set; get; }
        public int MaCongViec { set; get; }
        public decimal? DonGia { set; get; }
        public decimal? BangLuong { set; get; }
        public string TenCongViec { set; get; }
    }
}