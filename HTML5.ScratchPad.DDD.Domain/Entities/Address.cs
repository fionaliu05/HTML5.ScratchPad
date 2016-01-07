using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTML5.ScratchPad.DDD.Domain.Entities
{
    public class Address
    {
        [Key]
        //[Key, ForeignKey("AddressId")]
        public int AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }

        [Required]
        public string Postcode { get; set; }

        public string Email { get; set; }

        //public virtual int CustomerId { get; set; }
        //[Key, ForeignKey("CustomerId")]

        public virtual Customer Customer { get; set; }
    }
}
