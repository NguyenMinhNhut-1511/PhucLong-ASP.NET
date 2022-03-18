namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topping")]
    public partial class Topping
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string tenTP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gia { get; set; }

        [StringLength(10)]
        public string maTinhTrang { get; set; }

        public virtual TinhTrang TinhTrang { get; set; }
    }
}
