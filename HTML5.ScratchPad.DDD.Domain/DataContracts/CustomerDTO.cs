using System;

namespace HTML5.ScratchPad.DDD.Domain.DataContracts
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool Active { get; set; }

        public AddressDTO Address { get; set; }
    }
}
