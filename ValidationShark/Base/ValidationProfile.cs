using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ValidationShark
{
    /// <summary>
    ///     Basisklasse für ein Profil, in dem eine Validierung definiert ist
    /// </summary>
    public abstract class ValidationProfile<TValidationTarget> : IValidationProfile
    {
        private readonly List<IValidationRuleBuilder<TValidationTarget>> _ruleBuilders =
            new List<IValidationRuleBuilder<TValidationTarget>>();

        /// <summary>
        ///     Führt die Validierung auf dem Model aus
        /// </summary>
        /// <param name="model">Model, das validiert werden soll</param>
        /// <returns>Ergebnis der Validierung</returns>
        public ValidationResult Validate(object model)
        {
            var results = _ruleBuilders.Select(r => r.Validate((TValidationTarget) model));

            return ValidationResult.Build(results);
        }

        protected IValidationRuleBuilderForProperty<TValidationTarget, TProperty> RuleFor<TProperty>(
            Expression<Func<TValidationTarget, TProperty>> expression)
        {
            var builder = new ValidationRuleBuilderForProperty<TValidationTarget, TProperty>(expression);
            _ruleBuilders.Add(builder);
            return builder;
        }
    }
}