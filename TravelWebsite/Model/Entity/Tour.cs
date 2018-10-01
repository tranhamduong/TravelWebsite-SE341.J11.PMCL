namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [Key]
        [StringLength(10)]
        public string MaTour { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả ngắn về tour: ")]
        public string MoTaTour { get; set; }

        [Display(Name = "Đánh giá")]
        public double? DanhGia { get; set; }

        [Display(Name = "Tổng đánh giá")]
        public int? TongSoDanhGia { get; set; }

        [Display(Name = "Số ngày: ")]
        public double? SoNgay { get; set; }

        [Display(Name = "Số chỗ còn nhận khách: ")]
        public int? SoChoConLai { get; set; }

        [Display(Name = "Ngày khởi hành: ")]
        [Column(TypeName = "date")]
        public DateTime? NgayKhoiHanh { get; set; }

        [Display(Name = "Ngày trở về: ")]
        [Column(TypeName = "date")]
        public DateTime? NgayTroVe { get; set; }

        [Display(Name = "Giá tiền: ")]
        public int? GiaTien { get; set; }

        [Display(Name = "Giá tiền dành cho trẻ em: ")]
        public int? GiaTienTreEm { get; set; }

        [Display(Name = "Nơi khởi hành: ")]
        [StringLength(50)]
        public string NoiKhoiHanh { get; set; }

        [Display(Name = "Giảm giá: ")]
        public double? GiamGia { get; set; }

        [StringLength(10)]
        public string MaChiTietTour { get; set; }

        [Display(Name = "Hướng dẫn viên là: ")]
        [StringLength(100)]
        public string MaHuongDanVien { get; set; }

        [Display(Name = "Địa danh là: ")]
        [StringLength(100)]
        public string MaDiaDanh { get; set; }

        [Display(Name = "Tình trạng: ")]
        public bool? TinhTrang { get; set; }

        [Display(Name = "Mã phương tiện: ")]
        [StringLength(30)]
        public string PhuongTien { get; set; }

        public bool? isDeleted { get; set; }

        public enum Tinh_Trang
        {
           Mở,
           Đóng
        }
    }
}
