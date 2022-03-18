namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        public int ID { get; set; }

        public int? ID_NguoiDung { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(13)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string TinhTrang { get; set; }

        public DateTime? ThoiGianDat { get; set; }

        public DateTime? ThoiGianNhan { get; set; }

        [StringLength(10)]
        public string maPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual PTThanhToan PTThanhToan { get; set; }
    }
}
