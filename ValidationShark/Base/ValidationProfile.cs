using System;

namespace ValidationShark
{
    /// <summary>
    ///     Basisklasse für ein Profil, in dem eine Validierung definiert ist
    /// </summary>
    public abstract class ValidationProfile<TForModel> : IValidationProfile
    {
        /// <summary>
        ///     Führt die Validierung auf dem Model aus
        /// </summary>
        /// <param name="model">Model, das validiert werden soll</param>
        /// <returns>Ergebnis der Validierung</returns>
        public ValidationResult Validate(object model)
        {
            if(model.GetType() != typeof(TForModel))
                throw new InvalidCastException();
            
            throw new NotImplementedException();
        }
    }
}