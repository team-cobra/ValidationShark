namespace ValidationShark
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
        /// <returns>Ergebnis der Validierung</returns>
        ValidationResult Validate(object model);
    }
}