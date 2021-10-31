namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhatKi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThucHien { get; set; }

        public TimeSpan? GioBatDau { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
    }
}
