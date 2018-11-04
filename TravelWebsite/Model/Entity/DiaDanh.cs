namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDanh")]
    public partial class DiaDanh
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaDiaDanh { get; set; }

        [Display(Name = "Mô tả địa danh: ")]
        public string MoTaDiaDanh { get; set; }

        [Display(Name = "Các nơi nên ghé thăm: ")]
        [StringLength(100)]
        public string DiaDanhConTieuBieu { get; set; }

        [Display(Name = "Thuộc miền: ")]
        public int? MaVungMien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        [Display(Name = "Tên địa danh: ")]
        public string TenDiaDanh { get; set; }

        [Display(Name = "Số khách đến tham quan: ")]
        public int? SoKhachDaThamQuan { get; set; }

        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "image")]
        public byte[] Anh { get; set; }

        public enum Vung_Mien
        {
            Miền_Bắc,
            Miền_Trung,
            Miền_Nam,
            Nước_Ngoài
        }

        public bool? isDeleted { get; set; }
    }
}
