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
        [StringLength(50)]
        public string MaDiaDanh { get; set; }

        [Display(Name = "Mô tả địa danh: ")]
        public string MoTaDiaDanh { get; set; }

        [StringLength(100)]
        [Display(Name = "Các nơi nên ghé thăm: ")]
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

        [Column(TypeName = "image")]
        [Display(Name = "Hình ảnh")]
        public byte[] Anh { get; set; }

        public bool? isDeleted { get; set; }

        public enum Vung_Mien
        {
            Miền_Bắc,
            Miền_Trung,
            Miền_Nam,
            Nước_Ngoài
        }
    }
}
