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
        ///     Initialized the Validator with a list of Validation Profiles that will be registered for later usage
        /// </summary>
        /// <param name="profiles">List of profiles that should be registered</param>
        public Validator(IEnumerable<IValidationProfile> profiles)
        {
            foreach (var validationProfile in profiles)
            {
                var t = validationProfile.GetType();
                if (t.BaseType == null)
                    throw new InvalidOperationException();

                var modelType = t.BaseType.GenericTypeArguments.FirstOrDefault();
                if (modelType == null)
                    throw new InvalidOperationException();

                _profiles.Add(modelType, validationProfile);
            }
        }


        /// <summary>
        ///     Validates the Model
        /// </summary>
        /// <param name="model">Model that should be validated</param>
        /// <exception cref="MissingValidationProfileException">
        ///     When there is no
        ///     <see cref="ValidationProfile{TValidationTarget}" /> registered for the given model
        /// </exception>
        /// <returns>Result of the validation-process</returns>
        public ValidationResult Validate(object model)
        {
            if (!_profiles.ContainsKey(model.GetType()))
                throw new MissingValidationProfileException(model.GetType().FullName);

            var profile = _profiles[model.GetType()];

            return profile.Validate(model);
        }
    }
}