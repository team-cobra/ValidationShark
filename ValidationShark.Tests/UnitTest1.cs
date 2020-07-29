using ValidationShark.ValidationRules.Length;
using Xunit;

namespace ValidationShark.Tests
{
    public class UnitTest1
    {
        internal class TestProfile : ValidationProfile<TestModel>
        {
            public TestProfile()
            {
                RuleFor(x => x.Name).Length(5, 10);
            }
        }

        [Fact]
        public void Validator_TestProfile_ResultMustBeFalse()
        {
            // => Arrange
            var model = new TestModel {Name = "Hal"};
            var validator = new Validator(new[] {new TestProfile()});

            // => Act
            var result = validator.Validate(model);

            // => Assert
            Assert.False(result.Success);
        }

        [Fact]
        public void Validator_TestProfile_ResultMustBeTrue()
        {
            // => Arrange
            var model = new TestModel {Name = "Hallo Welt"};
            var validator = new Validator(new[] {new TestProfile()});

            // => Act
            var result = validator.Validate(model);

            // => Assert
            Assert.True(result.Success);
        }
    }

    internal class TestModel
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}