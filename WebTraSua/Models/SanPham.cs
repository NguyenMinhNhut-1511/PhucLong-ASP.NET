namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string tenSP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gia { get; set; }
        public string Mota { get; set; }

        public string Anh { get; set; }

        public string ChonLoai { get; set; }

        public string ChonSize { get; set; }

        public string ChonDuong { get; set; }

        public string ChonDa { get; set; }

        public string ChonTopping { get; set; }

        public int? GiamGia { get; set; }

        [StringLength(10)]
        public string maLoai { get; set; }

        [StringLength(10)]
        public string maTinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual TinhTrang TinhTrang { get; set; }
    }
}
