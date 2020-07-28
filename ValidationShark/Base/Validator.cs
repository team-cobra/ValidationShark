using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidationShark
{
    /// <inheritdoc />
    public class Validator : IValidator
    {
        private readonly Dictionary<Type, IValidationProfile> _profiles = new Dictionary<Type, IValidationProfile>();

        /// <summary>
        ///     Initialisiert einen neuen Validator mit Profilen
        ///     Die Profile werden gespeichert und stehen in der gesamten Lebenszeit des Validators zur Verfügung
        /// </summary>
        /// <param name="profiles">Profile, die Initial erstellt werden sollen</param>
        /// <exception cref="InvalidOperationException">Bei Ungültigen Profilen kommt es zu einer Exception</exception>
        public Validator(IEnumerable<IValidationProfile> profiles)
        {
            foreach (var validationProfile in profiles)
            {
                //Typen des Profils holen
                var t = validationProfile.GetType();
                if (t.BaseType == null)
                    throw new InvalidOperationException();

                //Typen des Models holen
                var modelType = t.BaseType.GenericTypeArguments.FirstOrDefault();
                if (modelType == null)
                    throw new InvalidOperationException();

                //Profil mit Model als Index speichern
                _profiles.Add(modelType, validationProfile);
            }
        }

        /// <summary>
        ///     Validiert das Model auf Gültigkeit
        /// </summary>
        /// <param name="model">Model, das auf Gültigkeit geprüft werden soll</param>
        /// <typeparam name="TValidationProfile">Profil, mit dem das Model validiert werden soll</typeparam>
        /// <returns>Ergebnis der Validierung</returns>
        public ValidationResult Validate<TValidationProfile>(object model) where TValidationProfile : IValidationProfile
        {
            //Profil suchen
            if (!_profiles.ContainsKey(model.GetType()))
                throw new MissingValidationProfileException(model.GetType().FullName);

            var profile = _profiles[model.GetType()];

            //Validierung an das Profil weitergeben
            return profile.Validate(model);
        }
    }
}