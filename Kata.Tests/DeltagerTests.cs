using FluentAssertions;
using System;
using Xunit;

namespace Kata.Tests
{
    public class ParticipantsTests
    {

        [Fact]
        [Trait("Category", "City")]
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
        [Trait("Category", "Name")]
        public void ParticipantsNameThrowsExceptionIfNameIsNull()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = null;
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Fact]
        [Trait("Category", "Name")]
        public void ParticipantsNameThrowsExceptionIfNameIsEmpty()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        
        [Fact]
        [Trait("Category", "Name")]
        public void ParticipantsNameThrowsExceptionIfNameIsSpecialCharacter()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "#";
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Fact]
        [Trait("Category", "Name")]
        public void ParticipantsNameWithNummericIsNotValid()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "9";


            // Act & // Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Theory]
        [InlineData("Anna")]
        [InlineData("anna")]
        [InlineData("Anna-Marie")]
        [InlineData("anna-marie")]
        [InlineData("Anna Marie")]
        [InlineData("anna marie")]
        [InlineData("aNna")]
        [InlineData("ANNA")]
        [Trait("Category","Name")]
        public void ParticipantsNameWithAlphaCharicIsValid(string name)
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = name;
            // Act
            sut.Name = positiveResult;

            // Assert
            sut.Name.Should().Be(positiveResult);
        }

        [Theory]
        [InlineData("Anna","Anna")]
        [InlineData("anna","Anna")]
        [InlineData("Anna-Marie","Anna-Marie")]
        [InlineData("anna-marie","Anna-Marie")]
        [InlineData("Anna Marie", "Anna Marie")]
        [InlineData("anna marie", "Anna Marie")]
        [InlineData("aNna", "Anna")]
        [InlineData("ANNA", "Anna")]
        [Trait("Category", "Name")]
        public void ParticipantsNameAlwaysHasCorrectCasing(string name, string expected)
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = name;
            // Act
            sut.Name = positiveResult;

            // Assert
            sut.Name.Should().Be(expected);
        }
    }
}