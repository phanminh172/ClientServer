namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinCongNhan")]
    public partial class ThongTinCongNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinCongNhan()
        {
            DanhMucCongNhanThucHienKhoans = new HashSet<DanhMucCongNhanThucHienKhoan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã công nhân")]
        public int MaCongNhan { get; set; }

        [StringLength(1024)]
        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Không được để trống họ tên")]
        public string Hoten { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Không được để trống ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(1024)]
        [DisplayName("Phòng ban")]
        [Required(ErrorMessage = "Không được để trống phòng ban")]
        public string PhongBan { get; set; }

        [StringLength(1024)]
        [DisplayName("Chức vụ")]
        [Required(ErrorMessage = "Không được để trống chức vụ")]
        public string ChucVu { get; set; }

        [StringLength(1024)]
        [DisplayName("Quê quán")]
        [Required(ErrorMessage = "Không được để trống quê quán")]
        public string QueQuan { get; set; }

        [DisplayName("Lương hợp đồng")]
        [Required(ErrorMessage = "Không được để trống lương hợp đồng")]
        public int? LuongHopDong { get; set; }

        [DisplayName("Lương bảo hiểm")]
        [Required(ErrorMessage = "Không được để trống lương bảo hiểm")]
        public int? LuongBaoHiem { get; set; }

        [StringLength(5)]
        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Không được để trống họ tên")]
        public string GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }
    }
}
