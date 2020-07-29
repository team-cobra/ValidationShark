namespace ValidationShark
{
    /// <summary>
    ///     Base-Interface for ValidationProfiles
    /// </summary>
    public interface IValidationProfile
    {
        /// <summary>
        ///     Validates the Model by using its Rules
        /// </summary>
        /// <param name="model">Model that should be validated</param>
        /// <returns>Result of the validation-process</returns>
        ValidationResult Validate(object model);
    }
}