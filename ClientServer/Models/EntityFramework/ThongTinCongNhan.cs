namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCongNhan { get; set; }

        [StringLength(1024)]
        public string Hoten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(1024)]
        public string PhongBan { get; set; }

        [StringLength(1024)]
        public string ChucVu { get; set; }

        [StringLength(1024)]
        public string QueQuan { get; set; }

        public int? LuongHopDong { get; set; }

        public int? LuongBaoHiem { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }
    }
}
