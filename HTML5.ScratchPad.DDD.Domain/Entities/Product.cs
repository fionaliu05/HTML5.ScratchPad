using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTML5.ScratchPad.DDD.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        //References - 1-to-Many Foriegn Key ? for optional
        //public virtual int CustomerId { get; set; }
        public int? CustomerId { get; set; }
   
        [Key, ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}
