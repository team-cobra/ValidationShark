namespace ValidationShark.ValidationRules.Int
{
    public class MinValidationRule : IValidationRule<int>
    {
        private readonly int _min;

        public MinValidationRule(int min)
        {
            _min = min;
        }

        public ValidationResult Validate(int value)
        {
            if (value >= _min)
                return ValidationResult.Succeeded;

            return ValidationResult.Failed(
                $"The given integer must have a value above {_min}. Actual: {value}");
        }
    }
}