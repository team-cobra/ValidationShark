namespace ValidationShark.ValidationRules.String.Length
{
    public class MinLengthValidationRule : IValidationRule<string>
    {
        private readonly int _minLength;

        public MinLengthValidationRule(int minLength)
        {
            _minLength = minLength;
        }

        public ValidationResult Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return ValidationResult.Failed(
                    $"The given string cannot be null or empty. The string must be at least {_minLength} characters long.");

            if (_minLength <= value.Length)
                return ValidationResult.Succeeded;

            return ValidationResult.Failed(
                $"The given string must be at least {_minLength} characters long. Actual: {value.Length}");
        }
    }
}