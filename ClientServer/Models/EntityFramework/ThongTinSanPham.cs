namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinSanPham")]
    public partial class ThongTinSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinSanPham()
        {
            DanhMucCongViecDaLams = new HashSet<DanhMucCongViecDaLam>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã sản phẩm")]
        public int MaSanPham { get; set; }

        [StringLength(1024)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Không được để trống tên sản phẩm")]
        public string TenSanPham { get; set; }

        [StringLength(5)]
        [DisplayName("Số đăng ký")]
        [Required(ErrorMessage = "Không được để trống số đăng ký")]
        public string SoDangKy { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Hạn sử dụng")]
        [Required(ErrorMessage = "Không được để trống hạn sử dụng")]
        public DateTime? HanSuDung { get; set; }

        [StringLength(1024)]
        [DisplayName("Quy cách")]
        [Required(ErrorMessage = "Không được để trống quy cách")]
        public string QuyCach { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày đăng ký")]
        [Required(ErrorMessage = "Không được để trống ngày đăng ký")]
        public DateTime? NgayDangKy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
    }
}
