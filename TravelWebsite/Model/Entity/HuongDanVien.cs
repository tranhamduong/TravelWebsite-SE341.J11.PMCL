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
        [StringLength(50)]
        public string MaHuongDanVien { get; set; }

        [StringLength(100)]
        [Display(Name = "Họ tên Hướng dẫn viên: ")]
        public string HoTenHDV { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại Hướng dẫn viên: ")]
        public string SoDienThoaiHDV { get; set; }

        public bool? isDeleted { get; set; }
    }
}
