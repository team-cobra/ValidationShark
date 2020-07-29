using ValidationShark.ValidationRules.Int;
using Xunit;

namespace ValidationShark.Tests.ValidationRules.Int
{
    public class MaxValidationRuleTests
    {
        [Fact]
        public void ShouldFailOnAboveMax()
        {
            // => Arrange
            var rule = new MaxValidationRule(10);

            // => Act
            var result = rule.Validate(11);

            // => Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void ShouldSucceedOnBelowMax()
        {
            // => Arrange
            var rule = new MaxValidationRule(10);

            // => Act
            var result = rule.Validate(1);

            // => Assert
            Assert.True(result.Success);
        }
    }
}