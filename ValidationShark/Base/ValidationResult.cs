using System.Collections.Generic;
using System.Linq;

namespace ValidationShark
{
    /// <summary>
    ///     Ergebnis einer Validierung
    /// </summary>
    public class ValidationResult
    {
        private ValidationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        ///     Gibt an, ob der geprüfte Wert valide ist
        /// </summary>
        public bool Success { get; } = true;

        /// <summary>
        ///     Nachricht der Validierung (ggf. für Fehler)
        /// </summary>
        public string Message { get; }

        public IEnumerable<ValidationResult> NestedResults { get; private set; }

        public static ValidationResult Succeeded { get; } = new ValidationResult(true, null);

        public static ValidationResult Failed(string message)
        {
            return new ValidationResult(false, message);
        }

        public static ValidationResult Build(IEnumerable<ValidationResult> nestedResults)
        {
            var failedResults = nestedResults.Where(r => !r.Success).ToList();
            return new ValidationResult(failedResults.Any(), null)
            {
                NestedResults = failedResults
            };
        }
    }
}