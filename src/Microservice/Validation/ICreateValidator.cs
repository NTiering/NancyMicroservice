using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microservice.Data;

namespace Microservice.Validation
{
    public interface ICreateValidator
    {
        ICollection<ValidationResult> ValidateMode3l(DataModel model);
    }
}