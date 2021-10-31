namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongNhanThucHienKhoan")]
    public partial class DanhMucCongNhanThucHienKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDanhMucCongNhanThucHienKhoan { get; set; }

        public int MaNhatKi { get; set; }

        public int MaCongNhan { get; set; }

        public DateTime? ThoiGianBatDauCongViec { get; set; }

        public DateTime? ThoiGianKetThucCongViec { get; set; }

        public virtual NhatKiSanLuongKhoan NhatKiSanLuongKhoan { get; set; }

        public virtual ThongTinCongNhan ThongTinCongNhan { get; set; }
    }
}
