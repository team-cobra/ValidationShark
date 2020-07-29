using System;
using System.Collections.Generic;
using System.Linq;
using ValidationShark.ValidationRules;

namespace ValidationShark
{
    /// <inheritdoc />
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

        /// <summary>
        ///     Adds a Rule to the current calidation-chain
        /// </summary>
        /// <param name="rule">Rule that should be added to the validation-chain</param>
        public void AddRule(IValidationRule<TProperty> rule)
        {
            _rules.Add(rule);
        }

        /// <summary>
        ///     Builds the chain und Validates the Value with it
        /// </summary>
        /// <param name="value">Value that should be validated</param>
        /// <returns>Result of the validation-process</returns>
        public ValidationResult Validate(TValidationTarget value)
        {
            if (!_condition.Invoke(value))
                return ValidationResult.Succeeded;

            var propertyValue = _expression.Invoke(value);
            var results = _rules.Select(r => r.Validate(propertyValue));

            return ValidationResult.Build(results);
        }

        /// <summary>
        ///     Creates a Condition for the current chain
        ///     When the Condition is false, everything on the current chain will pass the validaiton
        /// </summary>
        /// <param name="condition">Condition for applying the validaiton</param>
        /// <returns>Returns the Builder for additianl chaining</returns>
        public IValidationRuleBuilder<TValidationTarget> When(Func<TValidationTarget, bool> condition)
        {
            _condition = condition;
            return this;
        }
    }
}