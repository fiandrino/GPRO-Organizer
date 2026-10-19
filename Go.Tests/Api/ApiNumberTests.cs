using go.Api;
using Xunit;

namespace go.Tests.Api
{
    public class ApiNumberTests
    {
        [Theory]
        [InlineData("370000", 370000)]
        [InlineData(" 17 ", 17)]
        [InlineData("-5", -5)]
        public void ToInt_ParsesNumbers(string text, int expected)
        {
            Assert.Equal(expected, ApiNumber.ToInt(text));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("abc")]
        public void ToInt_ReturnsZeroWhenNotANumber(string text)
        {
            Assert.Equal(0, ApiNumber.ToInt(text));
        }

        [Theory]
        [InlineData("119.502", 119.502)]
        [InlineData("1", 1.0)]
        public void ToDouble_ParsesNumbers(string text, double expected)
        {
            Assert.Equal(expected, ApiNumber.ToDouble(text), 6);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("abc")]
        public void ToDouble_ReturnsZeroWhenNotANumber(string text)
        {
            Assert.Equal(0.0, ApiNumber.ToDouble(text));
        }
    }
}
