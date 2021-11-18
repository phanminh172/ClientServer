namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongNhanThucHienKhoan")]
    public partial class DanhMucCongNhanThucHienKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMucCongNhanThucHienKhoan { get; set; }


        [DisplayName("Mã nhật kí")]
        public int MaNhatKi { get; set; }


        [DisplayName("Công nhân")]
        [Required(ErrorMessage = "Không được để trống công nhân")]
        public int MaCongNhan { get; set; }


        [DisplayName("Thời gian bắt đầu")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Không được để trống giờ bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan ThoiGianBatDauCongViec { get; set; }


        [DisplayName("Thời gian kết thúc")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Không được để trống giờ kết thúc")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan ThoiGianKetThucCongViec { get; set; }

        public virtual NhatKiSanLuongKhoan NhatKiSanLuongKhoan { get; set; }

        public virtual ThongTinCongNhan ThongTinCongNhan { get; set; }
    }
}
