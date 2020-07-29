namespace ValidationShark.ValidationRules
{
    public interface IValidationRule<TProperty>
    {
        ValidationResult Validate(TProperty value);
    }
}