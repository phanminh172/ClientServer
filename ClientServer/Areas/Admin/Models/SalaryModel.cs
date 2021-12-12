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
        
        public string SanLuongThucTe { set; get; }
        public string MaCongViec { set; get; }
        public string DonGia { set; get; }
        public string BangLuong { set; get; }
        public DateTime? NgayThucHien { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "Không được để trống ngày bắt đầu")]
        public DateTime? NgayBatDau { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "Không được để trống ngày kết thúc")]
        public DateTime? NgayKetThuc { get; set; }
        public bool Type { set; get; }
    }
}