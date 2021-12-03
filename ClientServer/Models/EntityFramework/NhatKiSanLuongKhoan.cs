namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhatKiSanLuongKhoan")]
    public partial class NhatKiSanLuongKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhatKiSanLuongKhoan()
        {
            DanhMucCongNhanThucHienKhoans = new HashSet<DanhMucCongNhanThucHienKhoan>();
            DanhMucCongViecDaLams = new HashSet<DanhMucCongViecDaLam>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã nhật ký")]
        public int MaNhatKi { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày thực hiện")]
        [Required(ErrorMessage = "Không được để trống ngày thực hiện")]
        public DateTime NgayThucHien { get; set; }

        [DisplayName("Giờ bắt đầu")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Không được để trống giờ bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan GioBatDau { get; set; }

        [DisplayName("Giờ kết thúc")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Không được để trống giờ kết thúc")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan GioKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
    }
}
