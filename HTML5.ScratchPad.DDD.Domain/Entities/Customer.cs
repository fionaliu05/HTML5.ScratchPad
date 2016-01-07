using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HTML5.ScratchPad.DDD.Domain.Entities
{
    public class Customer : IValidatableObject
    {
        //[Key] only needed if the actual name of the Id is not CustomerId

        //Scalar Properties - equivalent to table columns
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool Active { get; set; }
        //This adds a rowversion id to the table for concurrency
        [Timestamp]
        public byte[] RowVersion { get; set; }

        //Relations - Navigational Properties to Related Entities
        //one-to-many-optional
        public virtual ICollection<Product> Product { get; set; }
        //one-to-one

        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }

        #region Special Customers

        public bool SpecialCustomer(Customer customer)
        {
            return customer.Active && DateTime.Now.Year - customer.InceptionDate.Year >= 5;
        }

        #endregion

        #region Validation
        //Belt and Braces validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (FirstName.Contains("\n"))
            {
                results.Add(
                    new ValidationResult("Newline character is illegal",
                        new[] { "FirstName" }));
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                results.Add(
                    new ValidationResult("FirstName is required",
                        new[] { "FirstName" }));
            }
            if (string.IsNullOrEmpty(Surname))
            {
                results.Add(
                    new ValidationResult("Surname is required",
                        new[] { "Surname" }));
            }
            return results;
        }

        #endregion
    }
}
