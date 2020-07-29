namespace ValidationShark.ValidationRules.Int
{
    public class MaxValidationRule : IValidationRule<int>
    {
        private readonly int _max;

        public MaxValidationRule(int max)
        {
            _max = max;
        }

        public ValidationResult Validate(int value)
        {
            if (value <= _max)
                return ValidationResult.Succeeded;

            return ValidationResult.Failed(
                $"The given integer must have a value below {_max}. Actual: {value}");
        }
    }
}