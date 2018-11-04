    namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinChiTietTour")]
    public partial class ThongTinChiTietTour
    {
        [Key]
        [StringLength(10)]
        public string MaChiTietTour { get; set; }

        [Display (Name = "Ngày giờ tập trung: ")]
        public DateTime? NgayGioTapTrung { get; set; }

        [Display(Name = "Nơi tập trung: ")]
        [StringLength(50)]
        public string NoiTapTrung { get; set; }

        [Display(Name = "Mã Phương tiện")]
        [StringLength(10)]
        public string MaPhuongTien { get; set; }

        [Display(Name = "Mã lưu ý: ")]
        [StringLength(10)]
        public string MaLuuY { get; set; }

        [Display (Name = "Có bảo hiểm: ")]
        public bool? CoBaoHiem { get; set; }

        [Display (Name = "Quà tặng: ")]
        [StringLength(80)]
        public string QuaTang { get; set; }

        [StringLength(100)]
        [Display (Name = "Lịch trình: ")]
        public string LichTrinh { get; set; }
    }
}
