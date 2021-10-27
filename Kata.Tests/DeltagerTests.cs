using FluentAssertions;
using System;
using Xunit;

namespace Kata.Tests
{
    public class ParticipantsTests
    {
        //[Fact]
        //public void ParticipantsValid()
        //{
        //    // Arrange
        //    var sut = new Participant();
        //    sut.City = "City";
        //    sut.Country = "Country";
        //    sut.Name = "Name";
        //    sut.RegistrationNumber = "1";
        //    sut.TelephoneNumber = 80808080;
        //    sut.ZipCode = 9999;

        //    // Act
        //    // Assert
            
        //}
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

            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        
        [Fact]
        public void ParticipantsNameThrowsExceptionIfNameIsSpecialCharacter()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "#";
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Fact]
        public void ParticipantsNameWithNummericIsNotValid()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "9";
            // Act
            //sut.Name = positiveResult;

            // Assert
            Assert.Throws<ArgumentException>(() => sut.Name = positiveResult);
        }
        [Fact]
        public void ParticipantsNameWithAlphaCharicIsValid()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "Name";
            // Act
            sut.Name = positiveResult;

            // Assert
            sut.Name.Should().Be(positiveResult);
        }
    }
}