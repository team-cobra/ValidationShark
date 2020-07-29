namespace ValidationShark.ValidationRule
{
    public interface IValidationRule<TProperty>
    {
        ValidationResult Validate(TProperty value);
    }
}