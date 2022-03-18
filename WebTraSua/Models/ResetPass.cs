namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResetPass")]
    public partial class ResetPass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(32)]
        public string maRS { get; set; }

        public int? ID_NguoiDung { get; set; }

        [StringLength(20)]
        public string ThoiHan { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
