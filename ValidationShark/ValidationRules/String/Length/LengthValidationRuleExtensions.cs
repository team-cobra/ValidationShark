namespace ValidationShark.ValidationRules.String.Length
{
    public static class LengthValidationRuleExtensions
    {
        public static IValidationRuleBuilderForProperty<TForModel, string> Length<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, string> context, int min, int max)
        {
            context.AddRule(new MinLengthValidationRule(min));
            context.AddRule(new MaxLengthValidationRule(max));

            return context;
        }

        public static IValidationRuleBuilderForProperty<TForModel, string> Required<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, string> context)
        {
            context.AddRule(new MinLengthValidationRule(1));

            return context;
        }

        public static IValidationRuleBuilderForProperty<TForModel, string> Min<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, string> context, int min)
        {
            context.AddRule(new MinLengthValidationRule(min));

            return context;
        }

        public static IValidationRuleBuilderForProperty<TForModel, string> Max<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, string> context, int max)
        {
            context.AddRule(new MaxLengthValidationRule(max));

            return context;
        }
    }
}