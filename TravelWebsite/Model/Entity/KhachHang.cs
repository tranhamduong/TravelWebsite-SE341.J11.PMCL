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
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên khách hàng: ")]
        public string HoTenKhachHang { get; set; }

        [Display(Name = "Số điện thoại khách hàng: ")]
        [StringLength(12)]
        public string SoDienThoaiKH { get; set; }

        [Display(Name = "Số CMND/Hộ chiếu khách hàng: ")]
        [StringLength(15)]
        public string SoHoChieuCMND { get; set; }


        [Display(Name = "Email: ")]
        [StringLength(30)]
        public string Email { get; set; }

        [Display(Name = "Tên đăng nhập: ")]
        [StringLength(30)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Password: ")]
        [StringLength(30)]
        public string Password { get; set; }

        public bool? isDeleted { get; set; }
    }
}
