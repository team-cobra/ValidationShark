namespace ValidationShark.ValidationRules.String.Length
{
    public class MaxLengthValidationRule : IValidationRule<string>
    {
        private readonly int _maxLength;

        public MaxLengthValidationRule(int maxLength)
        {
            _maxLength = maxLength;
        }

        public ValidationResult Validate(string value)
        {
            if (_maxLength <= value.Length)
                return ValidationResult.Succeeded;

            return ValidationResult.Failed(
                $"The given string cannot be longer then {_maxLength} characters. Actual: {value.Length}");
        }
    }
}