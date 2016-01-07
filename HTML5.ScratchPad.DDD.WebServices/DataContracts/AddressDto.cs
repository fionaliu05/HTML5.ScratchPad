using System;
using System.ComponentModel.DataAnnotations;

namespace HTML5.ScratchPad.DDD.WebServices.DataContracts
{
    //[Serializable]
    public class AddressDto
    {
        //[Key]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Please enter the first line of your address")]
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine1 { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine2 { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine3 { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine4 { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your postcode")]
        public string Postcode { get; set; }
    }
}