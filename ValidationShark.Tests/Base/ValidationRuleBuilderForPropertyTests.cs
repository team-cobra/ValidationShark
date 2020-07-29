using ValidationShark.ValidationRules.String;
using ValidationShark.ValidationRules.String.Length;
using Xunit;

namespace ValidationShark.Tests
{
    public class ValidationRuleBuilderForPropertyTests
    {
        internal class TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        internal class TestModelValidationProfile : ValidationProfile<TestModel>
        {
            public TestModelValidationProfile()
            {
                RuleFor(x => x.Name).Length(3, 10).When(x => x.Age == 10);
            }
        }

        [Fact]
        public void When_Condition_ShouldNotValidate()
        {
            // => Arrange
            var model = new TestModel
            {
                Age = 100,
                Name = "Tesrrrrrrrrrrrrrrrrrrrrtname"
            };
            var validator = new Validator(new[] {new TestModelValidationProfile()});

            // => Act
            var result = validator.Validate(model);

            // => Assert
            Assert.True(result.Success);
        }

        [Fact]
        public void When_Condition_ShouldValidate()
        {
            // => Arrange
            var model = new TestModel
            {
                Age = 10,
                Name = "Testname"
            };
            var validator = new Validator(new[] {new TestModelValidationProfile()});

            // => Act
            var result = validator.Validate(model);

            // => Assert
            Assert.True(result.Success);
        }
    }
}