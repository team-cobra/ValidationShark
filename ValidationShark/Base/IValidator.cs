﻿ namespace ValidationShark
{
    /// <summary>
    ///     Validator mit dem Models geprüft werden können
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        ///     Validiert das Model auf Gültigkeit
        /// </summary>
        /// <param name="model">Model, das auf Gültigkeit geprüft werden soll</param>
        /// <typeparam name="TValidationProfile">Profil, mit dem das Model validiert werden soll</typeparam>
        /// <returns>Ergebnis der Validierung</returns>
        ValidationResult Validate<TValidationProfile>(object model) where TValidationProfile : IValidationProfile;
    }
}