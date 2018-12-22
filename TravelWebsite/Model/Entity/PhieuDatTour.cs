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

        public string TongTien { get; set; }

        public string MaPDT { get; set; }

        public string KhachThamGia { get; set; }

        public bool isDeleted { get; set; }

        public int soGheNguoiLon { get; set; }

        public int soGheTreEm { get; set; }

        public int soPhongDon { get; set; }
    }
}
