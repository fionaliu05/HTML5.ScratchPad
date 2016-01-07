using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTML5.ScratchPad.DDD.MVC.Full.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage="Please enter your first name")]
        [StringLength(100, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 2)]
        public string Surname { get; set; }

        [DisplayName("Inception Date")]
        [ScaffoldColumn(false)]
        public DateTime InceptionDate { get; set; }
        
        public bool Active { get; set; }

        #region Address

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters",MinimumLength = 1)]
        public string AddressLine1 { get; set; }

        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine2 { get; set; }

        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter your county")]
        public string AddressLine4 { get; set; }

        [Required(ErrorMessage = "Please enter your postcode")]
        [StringLength(11, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 7)]
        public string Postcode { get; set; }

        [StringLength(100, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        public string Email { get; set; }

        #endregion

        //Relations
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}