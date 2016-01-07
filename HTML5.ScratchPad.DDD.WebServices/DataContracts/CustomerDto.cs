using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HTML5.ScratchPad.DDD.WebServices.DataContracts
{
    //[Serializable]
    public class CustomerDto
    {
        //[Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 2)]
        public string Surname { get; set; }

        [DisplayName("Inception Date")]
        [ScaffoldColumn(false)]
        public DateTime? InceptionDate { get; set; }

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; }

        //[JsonIgnore]
        public AddressDto Address { get; set; }


        
    }
}