namespace HTML5.ScratchPad.DDD.Domain.DataContracts
{
    public class AddressDTO : IAddressDTO
    {
        public int AddressId { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
    }
}
