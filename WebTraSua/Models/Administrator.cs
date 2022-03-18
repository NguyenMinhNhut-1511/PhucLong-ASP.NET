namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        public int ID { get; set; }

        [StringLength(32)]
        public string TaiKhoan { get; set; }

        [StringLength(32)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }
    }
}
