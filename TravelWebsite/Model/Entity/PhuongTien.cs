namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongTien")]
    public partial class PhuongTien
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Mã Phương tiện: ")]
        public string MaPhuongTien { get; set; }

        [Display(Name = "Thời gian đến: ")]
        public DateTime? ThoiGianDen { get; set; }

        [Display(Name = "Thời gian đi: ")]
        public DateTime? ThoiGianDi { get; set; }

        [StringLength(50)]
        public string TenSanBay { get; set; }

        [Display(Name = "Tên bến/sân bay xuất phát: ")]
        public bool? isDeleted { get; set; }
    }
}
