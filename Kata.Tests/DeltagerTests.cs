using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class ParticipantsTests
    {
        [Fact]
        public void ParticipantsCitySymbols()
        {
            // Arrange
            var sut = new Participant();
            var positiveResult = "#¤%";

            // Act
            sut.City = positiveResult;

            // Assert
            sut.City.Should().Be(positiveResult);
        }
    }
}