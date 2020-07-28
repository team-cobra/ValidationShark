﻿using System;

 namespace ValidationShark
{
    public class MissingValidationProfileException : Exception
    {
        private readonly string _name;

        public MissingValidationProfileException(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return $"Für das Model {_name} wurde kein ValidaitonProfile registriert.";
        }
    }
}