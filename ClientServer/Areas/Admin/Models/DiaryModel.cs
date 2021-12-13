using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Areas.Admin.Models
{
    public class DiaryModel : DanhMucCongNhanThucHienKhoan
    {
        public string TenCongViec { set; get; }
        
        public int? Ngay { set; get; }
        public int? Thang { set; get; }
    }
    
}