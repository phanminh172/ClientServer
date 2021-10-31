namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongViecDaLam")]
    public partial class DanhMucCongViecDaLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDanhMucCongViecDaLam { get; set; }

        public int MaNhatKi { get; set; }

        public int MaCongViec { get; set; }

        public int? SanLuongThucTe { get; set; }

        public int? SoLoSanPham { get; set; }

        public int? MaSanPham { get; set; }

        public virtual DanhMucCongViec DanhMucCongViec { get; set; }

        public virtual NhatKiSanLuongKhoan NhatKiSanLuongKhoan { get; set; }

        public virtual ThongTinSanPham ThongTinSanPham { get; set; }
    }
}
