using System;
using Xunit;

namespace ExcellentLearningApp.Tests
{
    public class Example
    {
        [Fact]
        public void Should_Pass_Aways()
        {
            // Arrange
            var expected = true;

            // Act
            var result = expected == true;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
