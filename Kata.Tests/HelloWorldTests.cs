using System;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void SayHelloWorld_ShouldReturnHelloWorld()
        {
            // Arrange
            var sut = new HelloWorld();
            // Act
            var actual = sut.SayHelloWorld();
            // Assert
            actual.Should().Be("Hello World!");
        }

        [Fact]
        public void ParticipantsCityValid()
        {
            // Arrange
            var sut = new Participant();
            var positiveResult = "Vejle";
            
            // Act
            sut.City = positiveResult;

            // Assert 
            sut.City.Should().Be((positiveResult));
            
        }

        [Fact]
        public void ParticipantsCitySymbols()
        {
            // Arrange
            var sut = new Participant();
            var positiveResult = "¤%";

            // Act

            // Assert 
            Assert.Throws<ArgumentException>(() => sut.City = positiveResult);
        }
    }
}