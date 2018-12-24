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
        [StringLength(50)]
        public string MaChiTietTour { get; set; }

        [Display(Name = "Ngày giờ tập trung: ")]
        public DateTime NgayGioTapTrung { get; set; }

        [StringLength(50)]
        [Display(Name = "Nơi tập trung: ")]
        public string NoiTapTrung { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã Phương tiện")]
        public string MaPhuongTien { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã lưu ý: ")]
        public string MaLuuY { get; set; }

        [Display(Name = "Có bảo hiểm: ")]
        public bool? CoBaoHiem { get; set; }

        [Display(Name = "Quà tặng: ")]
        [StringLength(80)]
        public string QuaTang { get; set; }

        [StringLength(100)]
        [Display(Name = "Lịch trình: ")]
        public string LichTrinh { get; set; }
    }
}
