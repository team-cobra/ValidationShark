using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidationShark
{
    /// <summary>
    ///    Base for ValidationProfiles
    /// </summary>
    public abstract class ValidationProfile<TValidationTarget> : IValidationProfile
    {
        
        private readonly List<IValidationRuleBuilder<TValidationTarget>> _ruleBuilders =
            new List<IValidationRuleBuilder<TValidationTarget>>();

        /// <summary>
        ///  Validates the Model by using its Rules
        /// </summary>
        /// <param name="model">Model that should be validated</param>
        /// <returns>Result of the validation-process</returns>
        public ValidationResult Validate(object model)
        {
            var results = _ruleBuilders.Select(r => r.Validate((TValidationTarget) model));

            return ValidationResult.Build(results);
        }

        /// <summary>
        /// Adds a new Rule to validate a Property Field
        /// </summary>
        /// <param name="expression">Expression to determine the Propteryfield that the rule is for</param>
        /// <typeparam name="TProperty">Type of the property</typeparam>
        /// <returns>ValidationRuleBuilder, that can be used to fluently create the Validation-Rule</returns>
        protected IValidationRuleBuilderForProperty<TValidationTarget, TProperty> RuleFor<TProperty>(
            Func<TValidationTarget, TProperty> expression)
        {
            var builder = new ValidationRuleBuilderForProperty<TValidationTarget, TProperty>(expression);
            _ruleBuilders.Add(builder);
            return builder;
        }
    }
}