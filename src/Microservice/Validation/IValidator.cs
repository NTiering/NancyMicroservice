using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microservice.Data;

namespace Microservice.Validation
{
    public interface IValidator
    {
        bool TryValidateCreate(DataModel model, List<ValidationResult> validationResults);
        bool TryValidateDelete(DataModel model, List<ValidationResult> validationResults);
        bool TryValidateUpdate(DataModel model, List<ValidationResult> validationResults);
    }
}