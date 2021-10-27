using System;
using System.Linq;

namespace Kata
{
    public class Participant
    {
        private string name;
        private int telephoneNumber;
        private int zipCode;
        private string city;
        private string country;
        private string registreringsNumber;

        public string RegistrationNumber
        {
            get { return registreringsNumber; }
            set { registreringsNumber = value; }
        }


        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        public string City
        {
            get { return city; }
            set { 
              
                if (CityNameValidation( value))
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentException("City name not valid");
                }
             
            }
        }


        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }


        public int TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool CityNameValidation(string cityName)
        {
            string approvedLetters = "abcdefghijklmnopqrstuvwxzæøå";
            
            foreach (char c in cityName.ToLower())
            {
               if (!approvedLetters.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
