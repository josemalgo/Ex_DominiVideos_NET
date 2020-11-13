using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure
{
    public class ValidationResult
    {
        public string ValidatedResult { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Messages { get; set; }

        public string AllErrors
        {
            get
            {
                var output = string.Empty;

                foreach (var error in Messages)
                    output += error + "\n\r";

                return output;
            }
        }

        public ValidationResult()
        {
            Messages = new List<string>();
        }
    }
}
