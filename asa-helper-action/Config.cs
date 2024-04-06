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

        public string? StreamingJobName { get; set; }
        public string? StreamingJobResourceGroup { get; set; }
        public string? StreamingJobQuery { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(StreamingJobName))
            {
                yield return new ValidationResult("StreamingJobName is required.");
            }
            if (string.IsNullOrEmpty(StreamingJobResourceGroup))
            {
                yield return new ValidationResult("StreamingJobResourceGroup is required.");
            }
            if (string.IsNullOrEmpty(StreamingJobQuery))
            {
                yield return new ValidationResult("StreamingJobQuery is required.");
            }
        }
    }
}