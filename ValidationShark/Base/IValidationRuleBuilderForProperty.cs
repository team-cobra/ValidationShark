using ValidationShark.ValidationRules;

namespace ValidationShark
{
    public interface
        IValidationRuleBuilderForProperty<TValidationTarget, TProperty> : IValidationRuleBuilder<TValidationTarget>
    {
        void AddRule(IValidationRule<TProperty> rule);
    }
}