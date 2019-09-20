using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microservice.Data;

namespace Microservice.Validation
{
    public interface IUpdateValidator
    {
        ICollection<ValidationResult> ValidateModel(DataModel model);
    }
}