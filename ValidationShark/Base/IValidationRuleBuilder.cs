using System;

namespace ValidationShark
{
    /// <summary>
    ///     Builder that helps creating the FluentValidationChain
    /// </summary>
    /// <typeparam name="TValidationTarget"></typeparam>
    public interface IValidationRuleBuilder<TValidationTarget>
    {
        /// <summary>
        ///     Builds the chain und Validates the Value with it
        /// </summary>
        /// <param name="value">Value that should be validated</param>
        /// <returns>Result of the validation-process</returns>
        ValidationResult Validate(TValidationTarget value);

        /// <summary>
        ///     Creates a Condition for the current chain
        ///     When the Condition is false, everything on the current chain will pass the validaiton
        /// </summary>
        /// <param name="condition">Condition for applying the validaiton</param>
        /// <returns>Returns the Builder for additianl chaining</returns>
        IValidationRuleBuilder<TValidationTarget> When(Func<TValidationTarget, bool> condition);
    }
}