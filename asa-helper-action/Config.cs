using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaHelperAction
{
    public class StreamingJobOptions : IValidatableObject
    {

        public string? JobName { get; set; }

        public string? ResourceGroup { get; set; }

        public string? Subscription { get; set; }

        public string? JobQuery { get; set; }

        public string? StartTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(JobName))
            {
                yield return new ValidationResult("JobName is required.");
            }
            if (string.IsNullOrEmpty(ResourceGroup))
            {
                yield return new ValidationResult("ResourceGroup is required.");
            }
            if (string.IsNullOrEmpty(Subscription))
            {
                yield return new ValidationResult("Subscription is required.");
            }
            if (string.IsNullOrEmpty(JobQuery))
            {
                yield return new ValidationResult("JobQuery is required.");
            }
            if (string.IsNullOrEmpty(StartTime))
            {
                yield return new ValidationResult("StartTime is required.");
            }
        }
    }
}