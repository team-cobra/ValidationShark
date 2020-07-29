namespace ValidationShark
{
    public interface IValidationRuleBuilder<in TValidationTarget>
    {
        ValidationResult Validate(TValidationTarget value);
    }
}