﻿ namespace ValidationShark
{
    public interface IValidationProfile
    {
        ValidationResult Validate(object model);
    }
}