namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDatTour")]
    public partial class PhieuDatTour
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaTour { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        public bool? TinhTranThanhToan { get; set; }

        public bool? XacNhanThamGia { get; set; }

        public double? DanhGia { get; set; }

        public bool? isDeleted { get; set; }
    }
}
