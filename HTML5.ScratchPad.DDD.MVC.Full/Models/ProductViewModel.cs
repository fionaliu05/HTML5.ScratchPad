using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTML5.ScratchPad.DDD.MVC.Full.Models
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [MaxLength(250, ErrorMessage = "Maximum {0} characters")]
        [MinLength(2, ErrorMessage = "Minimum {0} characters")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Please enter a value")]
        public decimal Value { get; set; }

        //Foreign Key References
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}