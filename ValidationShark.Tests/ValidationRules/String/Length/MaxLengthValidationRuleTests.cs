using ValidationShark.ValidationRules.String.Length;
using Xunit;

namespace ValidationShark.Tests.ValidationRules.String.Length
{
    public class MaxLengthValidationRuleTests
    {

        [Fact]
        public void ShouldFailWhenStringIsToLong()
        {
            // => Arrange
            var rule = new MaxLengthValidationRule(10);
            
            // => Act
            var result = rule.Validate("123456789101112");

            // => Assert
            Assert.False(result.Success);
        }
        
        [Fact]
        public void ShouldSucceedWhenStringIsNotToLong()
        {
            // => Arrange
            var rule = new MaxLengthValidationRule(100);
            
            // => Act
            var result = rule.Validate("123456789101112");

            // => Assert
            Assert.True(result.Success);
        }
        
        [Fact]
        public void ShouldSucceedOnNull()
        {
            // => Arrange
            var rule = new MaxLengthValidationRule(100);
            
            // => Act
            var result = rule.Validate(null);

            // => Assert
            Assert.True(result.Success);
        }
    }
}