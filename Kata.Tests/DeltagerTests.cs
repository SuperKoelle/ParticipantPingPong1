using FluentAssertions;
using System;
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

        [Fact]
        public void ParticipantsNameThrowsExceptionIfNameIsNull()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = null;
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Fact]
        public void ParticipantsNameThrowsExceptionIfNameIsEmpty()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "";

            // Act
            sut.City = positiveResult;
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
    }
}