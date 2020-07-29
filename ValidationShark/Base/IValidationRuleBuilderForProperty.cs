using ValidationShark.ValidationRules;

namespace ValidationShark
{
    public interface
        IValidationRuleBuilderForProperty<TValidationTarget, TProperty> : IValidationRuleBuilder<TValidationTarget>
    {
        /// <summary>
        /// Adds a Rule to the current calidation-chain
        /// </summary>
        /// <param name="rule">Rule that should be added to the validation-chain</param>
        void AddRule(IValidationRule<TProperty> rule);
    }
}