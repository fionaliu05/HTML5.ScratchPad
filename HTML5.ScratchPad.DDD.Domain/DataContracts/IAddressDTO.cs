using System.ComponentModel.DataAnnotations;

namespace HTML5.ScratchPad.DDD.Domain.DataContracts
{
    public interface IAddressDTO
    {
        int AddressId { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        string AddressLine1 { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        string AddressLine2 { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        string AddressLine3 { get; set; }
        [StringLength(150, ErrorMessage = "Must have a minimum {0} maximum {1} characters", MinimumLength = 1)]
        string AddressLine4 { get; set; }
        [Required]
        string Postcode { get; set; }
        string Email { get; set; }
    }
}