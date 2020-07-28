﻿namespace ValidationShark
{
    /// <summary>
    ///     Ergebnis einer Validierung
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        ///     Gibt an, ob der geprüfte Wert valide ist
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        ///     Nachricht der Validierung (ggf. für Fehler)
        /// </summary>
        public string Message { get; set; }
    }
}