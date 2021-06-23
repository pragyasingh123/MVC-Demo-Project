namespace DemoProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemMst")]
    public partial class ItemMst
    {
        [Key]
        public int IID { get; set; }

        [DisplayName("Product Name")]
        public string IName { get; set; }

        [DisplayName("Product Detail")]
        public string Detail { get; set; }

        [DisplayName("Product Price")]
        public double? Price { get; set; }

        [DisplayName("Product Quantity")]
        public int? Qnt { get; set; }

        [StringLength(50)]

        [DisplayName("Company Name")]
        public string CName { get; set; }

        public DateTime? EntryDate { get; set; }

        public string ImagePath { get; set; }

        public int? Size { get; set; }
    }
}
