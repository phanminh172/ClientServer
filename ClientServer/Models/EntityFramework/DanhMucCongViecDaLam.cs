namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongViecDaLam")]
    public partial class DanhMucCongViecDaLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMucCongViecDaLam { get; set; }


        [DisplayName("Mã nhật ký")]
        [Required(ErrorMessage = "Không được để trống mã nhật ký")]
        public int MaNhatKi { get; set; }


        [DisplayName("Công việc")]
        [Required(ErrorMessage = "Không được để trống công việc")]
        public int MaCongViec { get; set; }


        [DisplayName("Sản lượng")]
        [Required(ErrorMessage = "Không được để trống sản lượng")]
        public int SanLuongThucTe { get; set; }


        [DisplayName("Số lô sản phẩm")]
        [Required(ErrorMessage = "Không được để trống số lô sản phẩm")]
        public int SoLoSanPham { get; set; }


        [DisplayName("Sản phẩm")]
        [Required(ErrorMessage = "Không được để trống sản phẩm")]
        public int MaSanPham { get; set; }

        public virtual DanhMucCongViec DanhMucCongViec { get; set; }

        public virtual NhatKiSanLuongKhoan NhatKiSanLuongKhoan { get; set; }

        public virtual ThongTinSanPham ThongTinSanPham { get; set; }
    }
}
