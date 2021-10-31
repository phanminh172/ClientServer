namespace ClientServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCongViec { get; set; }

        [StringLength(1024)]
        public string TenCongViec { get; set; }

        public int DinhMucKhoan { get; set; }

        [StringLength(24)]
        public string DonViKhoan { get; set; }

        public decimal HeSoKhoan { get; set; }

        public int DinhMucLaoDong { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViecDaLam> DanhMucCongViecDaLams { get; set; }
    }
}
