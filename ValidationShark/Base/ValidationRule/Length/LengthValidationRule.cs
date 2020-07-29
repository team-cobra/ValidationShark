namespace ValidationShark.ValidationRule.Length
{
    public class LengthValidationRule : IValidationRule<string>
    {
        private readonly int _max;
        private readonly int _min;

        public LengthValidationRule(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public ValidationResult Validate(string value)
        {
            if (_min <= value.Length && value.Length <= _max)
                return ValidationResult.Succeeded;

            return ValidationResult.Failed(
                $"The given string must be in range of min({_min}, max({_max}). Actual: {value.Length}");
        }
    }
}