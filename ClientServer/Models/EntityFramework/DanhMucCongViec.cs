namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongViec")]
    public partial class DanhMucCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucCongViec()
        {
            DanhMucCongViecDaLams = new HashSet<DanhMucCongViecDaLam>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã công việc")]
        public int MaCongViec { get; set; }

        [StringLength(1024)]
        [DisplayName("Tên công việc")]
        [Required(ErrorMessage = "Không được để trống tên công việc")]
        public string TenCongViec { get; set; }

        [DisplayName("Định mức khoán")]
        [Required(ErrorMessage = "Không được để trống định mức khoán")]
        public int DinhMucKhoan { get; set; }

        [StringLength(24)]
        [DisplayName("Đơn vị khoán")]
        [Required(ErrorMessage = "Không được để trống đơn vị khoán")]
        public string DonViKhoan { get; set; }

        [DisplayName("Hệ số khoán")]
        [Required(ErrorMessage = "Không được để trống hệ số khoán")]
        public decimal HeSoKhoan { get; set; }

        [DisplayName("Định mức lao động")]
        [Required(ErrorMessage = "Không được để trống định mức lao động")]
        public int DinhMucLaoDong { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Đơn giá")]
        public decimal? DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
    }
}
