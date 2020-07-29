using System.Collections.Generic;
using System.Linq;

namespace ValidationShark
{
    /// <summary>
    ///     Result of a Validation
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        ///     Creates a new Validation Result
        /// </summary>
        /// <param name="success">Success of the validation</param>
        /// <param name="message">Message given by the Validation Rule</param>
        private ValidationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        ///     Result of the Validation
        /// </summary>
        public bool Success { get; } = true;

        /// <summary>
        ///     Message for the User
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Nested Results from the underlying ValidationRules
        /// </summary>
        public IEnumerable<ValidationResult> NestedResults { get; private set; }

        /// <summary>
        ///     Gives a prepared Validation Result for success cases
        /// </summary>
        public static ValidationResult Succeeded { get; } = new ValidationResult(true, null);

        /// <summary>
        ///     Gives a prepared Validation Result for failed cases
        /// </summary>
        public static ValidationResult Failed(string message)
        {
            return new ValidationResult(false, message);
        }

        /// <summary>
        ///     Builds a new ValidationResult from a List of other ValidationResults
        ///     The ValidationResult will be invalid if one of the given ValidationResults is not successfull
        /// </summary>
        /// <param name="nestedResults">List of Results from which the ValidationResult should be built</param>
        /// <returns>Validation Result</returns>
        public static ValidationResult Build(IEnumerable<ValidationResult> nestedResults)
        {
            var failedResults = nestedResults.Where(r => !r.Success).ToList();
            return new ValidationResult(!failedResults.Any(), null)
            {
                NestedResults = failedResults
            };
        }
    }
}