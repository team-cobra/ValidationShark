using ValidationShark.ValidationRules;

namespace ValidationShark
{
    public interface
        IValidationRuleBuilderForProperty<in TValidationTarget, TProperty> : IValidationRuleBuilder<TValidationTarget>
    {
        void AddRule(IValidationRule<TProperty> rule);
    }
}