namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDon")]
    public partial class CTHoaDon
    {
        public int ID { get; set; }

        public int? ID_HoaDon { get; set; }

        public int? ID_SanPham { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gia { get; set; }

        [StringLength(10)]
        public string ChonLoai { get; set; }

        [StringLength(10)]
        public string ChonSize { get; set; }

        [StringLength(10)]
        public string ChonDuong { get; set; }

        public string ChonTopping { get; set; }

        public string ChonDa { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
