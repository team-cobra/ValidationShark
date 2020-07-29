using ValidationShark.ValidationRules.Int;
using Xunit;

namespace ValidationShark.Tests.ValidationRules.Int
{
    public class MinValidationRuleTests
    {
        [Fact]
        public void ShouldSucceedOnAboveMin()
        {
            // => Arrange
            var rule = new MinValidationRule(10);
            
            // => Act
            var result = rule.Validate(11);

            // => Assert
            Assert.True(result.Success);
        }
        
        [Fact]
        public void ShouldFailOnBelowMin()
        {
            // => Arrange
            var rule = new MinValidationRule(10);
            
            // => Act
            var result = rule.Validate(1);

            // => Assert
            Assert.False(result.Success);
        }
    }
}