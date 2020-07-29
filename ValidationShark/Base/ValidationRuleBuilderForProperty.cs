using System;
using System.Collections.Generic;
using System.Linq;
using ValidationShark.ValidationRules;

namespace ValidationShark
{
    public class
        ValidationRuleBuilderForProperty<TValidationTarget, TProperty> : IValidationRuleBuilderForProperty<
            TValidationTarget, TProperty>
    {
        private readonly Func<TValidationTarget, TProperty> _expression;

        private readonly List<IValidationRule<TProperty>> _rules = new List<IValidationRule<TProperty>>();

        private Func<TValidationTarget, bool> _condition;

        public ValidationRuleBuilderForProperty(Func<TValidationTarget, TProperty> expression)
        {
            _expression = expression;
        }

        public void AddRule(IValidationRule<TProperty> rule)
        {
            _rules.Add(rule);
        }

        public ValidationResult Validate(TValidationTarget value)
        {
            if (!_condition.Invoke(value))
                return ValidationResult.Succeeded;

            var propertyValue = _expression.Invoke(value);
            var results = _rules.Select(r => r.Validate(propertyValue));

            return ValidationResult.Build(results);
        }

        public IValidationRuleBuilder<TValidationTarget> When(Func<TValidationTarget, bool> condition)
        {
            _condition = condition;
            return this;
        }
    }
}