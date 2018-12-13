namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageTour")]
    public partial class ImageTour
    {
        [Key]
        [StringLength(10)]
        public string MaTour { get; set; }

        [Column(TypeName = "image")]
        public byte[] PictureOne { get; set; }

        [Column(TypeName = "image")]
        public byte[] PictureTwo { get; set; }

        [Column(TypeName = "image")]
        public byte[] PictureThree { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

    }
}
