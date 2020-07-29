namespace ValidationShark.ValidationRules.Int
{
    public static class IntegerExtensions
    {
        public static IValidationRuleBuilderForProperty<TForModel, int> Min<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, int> context, int min)
        {
            context.AddRule(new MinValidationRule(min));

            return context;
        }

        public static IValidationRuleBuilderForProperty<TForModel, int> Max<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, int> context, int max)
        {
            context.AddRule(new MaxValidationRule(max));

            return context;
        }

        public static IValidationRuleBuilderForProperty<TForModel, int> Range<TForModel>(
            this IValidationRuleBuilderForProperty<TForModel, int> context, int from, int to)
        {
            context.AddRule(new MinValidationRule(from));
            context.AddRule(new MaxValidationRule(to));

            return context;
        }
    }
}