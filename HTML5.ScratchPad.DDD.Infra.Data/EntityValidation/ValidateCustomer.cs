using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace HTML5.ScratchPad.DDD.Infra.Data.EntityValidation
{
    //Belt and Braces server-side validation
    public static class ValidateCustomer
    {
        public static List<DbValidationError> Validate(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var list = new List<DbValidationError>();

            if (entityEntry.CurrentValues.GetValue<string>("FirstName") == "")
            {
                list.Add(new DbValidationError("FirstName", "FirstName is required"));
            }
            if (entityEntry.CurrentValues.GetValue<string>("Surname") == "")
            {
                list.Add(new DbValidationError("Surname", "Surname is required"));
            }
            return list;
        }
    }
}

