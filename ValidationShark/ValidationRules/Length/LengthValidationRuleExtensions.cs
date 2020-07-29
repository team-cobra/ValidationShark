namespace ValidationShark.ValidationRules.Length
{
    public static class LengthValidationRuleExtensions
    {
        public static IValidationRuleBuilderForProperty<TForModel, string> Length<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, string> context, int min, int max)
        {
            context.AddRule(new LengthValidationRule(min, max));

            return context;
        }
    }
}