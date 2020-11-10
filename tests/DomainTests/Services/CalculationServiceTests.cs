using FluentAssertions;
using Hms.Exercise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hms.Exercise.DomainTests.Services
{
    public class CalculationServiceTests
    {
        [Theory]
        [InlineData(28, 121)]
        [InlineData(51, 66)]
        [InlineData(11, 11)]
        [InlineData(607, 4444)]
        [InlineData(196, -1)]
        [InlineData(0151, 151)]
        public void PassDifferentValues_CorrectResults(int input, int expected)
        {
            /// arrange
            var sut = new Transform();

            /// act
            var result = sut.Palindrome(input);

            /// assert
            result.Should().Be(expected, "the calculation should be correct");
        }

        [Fact]
        public void Pass196_ShouldReturnMinus1()
        {
            /// arrange
            var sut = new Transform();

            /// act
            var result = sut.Palindrome(196);

            /// assert
            result.Should().Be(-1, "the calculation should be correct");
        }

        [Fact]
        public void PassTooHighInput_ShouldThrowException()
        {
            /// arrange
            var sut = new Transform();

            /// act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Palindrome(9999999));
        }

        [Fact]
        public void PassTooLowInput_ShouldThrowException()
        {
            /// arrange
            var sut = new Transform();

            /// act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Palindrome(-1));
        }
    }
}
