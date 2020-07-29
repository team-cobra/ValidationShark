using ValidationShark.ValidationRules.String.Length;
using Xunit;

namespace ValidationShark.Tests.ValidationRules.String.Length
{
    public class MinLengthValidationRuleTests
    {

        [Fact]
        public void ShouldFailWhenStringIsNotLongEnough()
        {
            // => Arrange
            var rule = new MinLengthValidationRule(10);
            
            // => Act
            var result = rule.Validate("123456789");

            // => Assert
            Assert.False(result.Success);
        }
        
        [Fact]
        public void ShouldSucceedWhenStringIsLongEnough()
        {
            // => Arrange
            var rule = new MinLengthValidationRule(5);
            
            // => Act
            var result = rule.Validate("12345");

            // => Assert
            Assert.True(result.Success);
        }
        
        [Fact]
        public void ShouldFailOnNull()
        {
            // => Arrange
            var rule = new MinLengthValidationRule(100);
            
            // => Act
            var result = rule.Validate(null);

            // => Assert
            Assert.False(result.Success);
        }
    }
}