using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ValidationShark.ValidationRules;

namespace ValidationShark
{
    public class
        ValidationRuleBuilderForProperty<TValidationTarget, TProperty> : IValidationRuleBuilderForProperty<
            TValidationTarget, TProperty>
    {
        private readonly Expression<Func<TValidationTarget, TProperty>> _expression;

        private readonly List<IValidationRule<TProperty>> _rules = new List<IValidationRule<TProperty>>();

        public ValidationRuleBuilderForProperty(Expression<Func<TValidationTarget, TProperty>> expression)
        {
            _expression = expression;
        }

        public void AddRule(IValidationRule<TProperty> rule)
        {
            _rules.Add(rule);
        }

        public ValidationResult Validate(TValidationTarget value)
        {
            var propertyValue = _expression.Compile().Invoke(value);
            var results = _rules.Select(r => r.Validate(propertyValue));

            return ValidationResult.Build(results);
        }
    }
}