namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(50)]
        public string MaKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên khách hàng: ")]
        public string HoTenKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại khách hàng: ")]
        public string SoDienThoaiKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Số CMND/Hộ chiếu: ")]
        public string SoHoChieuCMND { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên đăng nhập: ")]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isAdmin { get; set; }

        [Display(Name = "Có là nữ?")]
        public bool isFemale { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ: ")]
        public string DiaChi { get; set; }
    }
}
