using System;
using System.Linq;

namespace Kata
{
    public class Participant
    {
        private string city;
        private string name;
        private string telephoneNumber;
        private string country;

        public string RegistrationNumber { get; set; }


        public string Country
        { get;set;}



        public string City
        {
            get => city;
            set
            {
                if (!CityNameValidation(value))
                    city = value;
                else
                    throw new ArgumentException("City name not valid");
            }
        }


        public int ZipCode { get; set; }


        public string TelephoneNumber 
        {
            get => telephoneNumber;

            set
            {
                ValidateTelephoneNumber(value);
            } 
        }


        public string Name
        {
            get => name;
            set
            {
                ParticipantNameValidation(value);
                name = value;
            }
        }

        private bool CityNameValidation(string cityName)
        {
            var approvedLetters = "abcdefghijklmnopqrstuvwxzæøå";

            foreach (var c in cityName.ToLower())
                if (!approvedLetters.Contains(c))
                    return false;
            return true;
        }

        private void ParticipantNameValidation(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is null or empty");

            var approvedLetters = "abcdefghijklmnopqrstuvwxzæøå- ";

            foreach (var c in name.ToLower())
                if (!approvedLetters.Contains(c))
                    throw new ArgumentException("navn ikke validt");
        }
 
    
        private void ValidateTelephoneNumber(string input)
        {


            if (Country=="Denmark")
            {
               string correctFormattedNumber= ReformatTelephoneNumber(input);
                ValidatePhoneNumberLength(correctFormattedNumber);
            }
            else
            {
                telephoneNumber = input;
            }

        }

        private string ReformatTelephoneNumber(string input)
        {
            return input.Replace(" ", "");
        }

        private void ValidatePhoneNumberLength(string input)
        {
            if (input.Length!=8)
            {
                throw new ArgumentException();
            }
            telephoneNumber = input;
        }
    }
}