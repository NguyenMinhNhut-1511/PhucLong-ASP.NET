namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
            ResetPasses = new HashSet<ResetPass>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(32)]
        public string MatKhau { get; set; }

        [StringLength(13)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(4)]
        public string GioiTinh { get; set; }

        [StringLength(10)]
        public string maTinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual TinhTrang TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResetPass> ResetPasses { get; set; }
    }
}
