namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamSo")]
    public partial class ThamSo
    {
        public string InternalTourPR { get; set; }

        public string ExternalTourPR { get; set; }

        [StringLength(10)]
        public string VISAcharge { get; set; }

        [Key]
        [StringLength(10)]
        public string key { get; set; }
    }
}
