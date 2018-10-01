namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HuongDanVien")]
    public partial class HuongDanVien
    {
        [Key]
        [StringLength(10)]
        public string MaHuongDanVien { get; set; }

        [StringLength(50)]
        [Display (Name = "Họ tên Hướng dẫn viên: ")]
        public string HoTenHDV { get; set; }

        [Display(Name = "Số điện thoại Hướng dẫn viên: ")]
        [StringLength(12)]
        public string SoDienThoaiHDV { get; set; }

        public bool? isDeleted { get; set; }
    }
}
