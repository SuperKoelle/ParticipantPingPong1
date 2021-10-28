using FluentAssertions;
using System;
using System.Reflection;
using NSubstitute.Extensions;
using Xunit;

namespace Kata.Tests
{
    public class ParticipantsTests
    {

        //Navne må ikke være null
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

        //Navne må ikke være tom
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


        //Telefonnumre for deltagere i ”Danmark” skal være bestå af 8 cifre
        //Telefonnumre for deltagere i andre lande end ”Danmark” skal kunne være i en string


        [Theory]
        [InlineData("80808080", "Denmark", "80808080")]
        [InlineData("8080 8080", "Denmark", "80808080")]
        [InlineData("80 80 80 80", "Denmark", "80808080")]
        // //[InlineData("+4580808080", "Denmark", "80808080")]
        // //[InlineData("+45 80808080", "Denmark", "80808080")]
        // //[InlineData("+45 8080 8080", "Denmark", "80808080")]
        // //[InlineData("+45 80 80 80 80", "Denmark", "80808080")]
        // [InlineData("004580808080", "Denmark", "80808080")]
        // [InlineData("0045 80808080", "Denmark","80808080")]
        // [InlineData("0045 8080 8080", "Denmark","80808080")]
        // [InlineData("0045 80 80 80 80", "Denmark","80808080")]
        [InlineData("AnyString", "Not Denmark", "AnyString")]


         [Trait("Category", "PhoneNumber")]
        public void ParticipantsDanishPhonenumberMustBe8Digits(string telephoneNumber, string country, string expectedResult)
        {
            //Arrange
            var sut = new Participant();

            // Act
            sut.Country = country;
            sut.TelephoneNumber = telephoneNumber;



            // Assert
            Assert.Equal(expectedResult, sut.TelephoneNumber);
        }


        [Theory]
        [InlineData("8080808", "Denmark")]
        [InlineData("808080800", "Denmark")]

        [Trait("Category", "PhoneNumber")]
        public void ParticipantsDanishPhonenumberNotValid(string telephoneNumber, string country)
        {
            //Arrange
            var sut = new Participant();
            sut.Country = country;
            // Act & // Assert
            Assert.Throws<ArgumentException>(() => sut.TelephoneNumber = telephoneNumber);
        }
        
        [Theory]
        [InlineData("AnyString", "Not Denmark", "AnyString")]


        [Trait("Category", "PhoneNumber")]
        public void ParticipantsNonDanishPhonenumberAnyStringAccepted(string telephoneNumber, string country, string expectedResult)
        {
            //Arrange
            var sut = new Participant();

            // Act
            sut.Country = country;
            sut.TelephoneNumber = telephoneNumber;

            // Assert
            Assert.Equal(expectedResult, sut.TelephoneNumber);
        }

        
        
        //Postnumre for deltagere i ”Danmark” skal være bestå af 4 cifre
        [Theory]
        [InlineData(1234, "Denmark", 1234)]
        [InlineData(1, "Not Denmark", 1)]
        [InlineData(12, "Not Denmark", 12)]
        [InlineData(123, "Not Denmark", 123)]
        [InlineData(1234, "Not Denmark", 1234)]
        [InlineData(12345, "Not Denmark", 12345)]


        [Trait("Category", "PhoneNumber")]
        public void ParticipantsDanishZipCodeMustBe8Digits(int zipCode, string country, int expectedResult)
        {
            //Arrange
            var sut = new Participant();

            // Act
            sut.Country = country;
            sut.ZipCode = zipCode;



            // Assert
            Assert.Equal(expectedResult, sut.ZipCode);
        }



        [Theory]
        [InlineData(1, "Denmark")]
        [InlineData(12, "Denmark")]
        [InlineData(123, "Denmark")]
        [InlineData(12345, "Denmark")]

        [Trait("Category", "PhoneNumber")]
        public void ParticipantsDanishZipCodeNotValidThrowsArgumentException(int zipCode, string country)
        {
            //Arrange
            var sut = new Participant();
            sut.Country = country;
            // Act & // Assert
            Assert.Throws<ArgumentException>(() => sut.ZipCode = zipCode);
        }

        //Postnumre for deltagere i andre lande end ”Danmark” skal kunne være i en string.
        [Theory]
        [InlineData(1, "Not Denmark", 1)]
        [InlineData(12, "Not Denmark", 12)]
        [InlineData(123, "Not Denmark", 123)]
        [InlineData(1234, "Not Denmark", 1234)]
        [InlineData(12345, "Not Denmark", 12345)]


        [Trait("Category", "PhoneNumber")]
        public void ParticipantsNonDanishZipCodeAllAccepted(int zipCode, string country, int expectedResult)
        {
            //Arrange
            var sut = new Participant();

            // Act
            sut.Country = country;
            sut.ZipCode = zipCode;

            // Assert
            Assert.Equal(expectedResult, sut.ZipCode);
        }

        //Bynavne må ikke være null
        [Fact]
        [Trait("Category", "City")]
        public void ParticipantsCityThrowsExceptionIfNameIsNull()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = null;
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.City = positiveResult);
        }

        //Bynavn må ikke være tom
        [Fact]
        [Trait("Category", "City")]
        public void ParticipantsNameThrowsExceptionIfCityIsEmpty()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.City = positiveResult);
        }
       
        //Bynavn må ikke indeholde special tegn
        [Fact]
        [Trait("Category", "City")]
        public void ParticipantsCitySymbols()
        {
            // Arrange
            var sut = new Participant();
            var positiveResult = "¤%";

            // Act

            // Assert 
            Assert.Throws<ArgumentException>(() => sut.City = positiveResult);
        }

        //Bynavne skal have stort begyndelsesbogstav og resten skal være små
        [Theory]
        [InlineData("Vejle", "Vejle")]
        [InlineData("Store Jyndevad", "Store Jyndevad")]
        [InlineData("Allinge-Sandvig", "Allinge-Sandvig")]
        [InlineData("Store Fuglede Stationsby", "Store Fuglede Stationsby")]
        [InlineData("vejle", "Vejle")]
        [InlineData("VEJLE", "Vejle")]
        [InlineData("store jyndevad", "Store Jyndevad")]
        [InlineData("jyllinge-sandvig", "Allinge-Sandvig")]
        [InlineData("store fuglede stationsby", "Store Fuglede Stationsby")]
        [Trait("Category", "City")]
        public void ParticipantsCityAlwaysHasCorrectCasing(string city, string expected)
        {
            //Arrange
            var sut = new Participant();
            // Act
            sut.City = city;

            // Assert
            Assert.Equal(expected, sut.City);
        }
        
        //Landenavne må ikke være null
        [Fact]
        [Trait("Category", "Country")]
        public void ParticipantsCountryThrowsExceptionIfNameIsNull()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = null;
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Country = positiveResult);
        }

        //Landenavn må ikke være tom
        [Fact]
        [Trait("Category", "Country")]
        public void ParticipantsNameThrowsExceptionIfCountryIsEmpty()
        {
            //Arrange
            var sut = new Participant();
            string positiveResult = "";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Country = positiveResult);
        }

        //Landenavn må ikke indeholde special tegn
        [Fact]
        [Trait("Category", "Country")]
        public void ParticipantsCountrySymbols()
        {
            // Arrange
            var sut = new Participant();
            var positiveResult = "¤%";

            // Act

            // Assert 
            Assert.Throws<ArgumentException>(() => sut.Country = positiveResult);
        }
       
        //Landenavn skal have stort begyndelsesbogstav og resten skal være små
        [Theory]
        [InlineData("Danmark", "Danmark")]
        [InlineData("Baker Island", "Baker Island")]
        [InlineData("danmark", "Danmark")]
        [InlineData("baker island", "Baker Island")]
        [Trait("Category", "City")]
        public void ParticipantsCountryAlwaysHasCorrectCasing(string country, string expected)
        {
            //Arrange
            var sut = new Participant();
            // Act
            sut.Country = country;

            // Assert
            Assert.Equal(expected, sut.Country);
        }

        //Registreringsnumre skal bestå af to bogstaver og 5 tal, hvis deltageren kommer fra ”Danmark” 
        [Theory]
        [InlineData("aa1234", "Danmark","aa1234")]
        [InlineData("AA1234", "Danmark", "AA1234")]
        [Trait("Category", "RegistrationNumber")]
        public void ParticipantsDanishRegistrationNumberValid(string registrationNumber,string country, string expected)
        {
            //Arrange
            var sut = new Participant();
            // Act
            sut.Country = country;
            sut.RegistrationNumber = registrationNumber;

            // Assert
            Assert.Equal(expected, sut.RegistrationNumber);
        }
        
        [Theory]
        [InlineData("a1234", "Danmark")]
        [InlineData("AAA1234", "Danmark")]
        [Trait("Category", "RegistrationNumber")]
        public void ParticipantsDanishRegistrationNumberValidNotValidThrowsArgumentException(string registrationNumber, string country)
        {
            //Arrange
            var sut = new Participant();
            sut.Country = country;
            // Act

            // Assert 
            Assert.Throws<ArgumentException>(() => sut.RegistrationNumber = registrationNumber);
        }

        [Theory]
        [InlineData("a1234", "Baker Island","a1234")]
        [InlineData("AAA1234", "Baker Island","AAA1234")]
        [InlineData("x", "Baker Island","x")]
        [Trait("Category", "RegistrationNumber")]
        public void ParticipantsNonDanishRegistrationNumberAllStringAccepted(string registrationNumber, string country, string expected)
        {
            //Arrange
            var sut = new Participant();
            // Act
            sut.Country = country;
            sut.RegistrationNumber = registrationNumber;
            sut.RegistrationNumber = registrationNumber;

            // Assert
            Assert.Equal(expected, sut.RegistrationNumber);
        }
    }
}