using System;

namespace ValidationShark
{
    public interface IValidationRuleBuilder<TValidationTarget>
    {
        ValidationResult Validate(TValidationTarget value);

        IValidationRuleBuilder<TValidationTarget> When(Func<TValidationTarget, bool> condition);
    }
}