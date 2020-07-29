namespace ValidationShark
{
    /// <summary>
    ///     Validator with whom Models can be checked for validity
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        ///     Validates the Model
        /// </summary>
        /// <param name="model">Model that should be validated</param>
        /// <exception cref="MissingValidationProfileException">
        ///     When there is no
        ///     <see cref="ValidationProfile{TValidationTarget}" /> registered for the given model
        /// </exception>
        /// <returns>Result of the validation-process</returns>
        ValidationResult Validate(object model);
    }
}