using System;
using System.Text;

namespace Notepad.Models
{
    public class NoteId
    {
        //Fields
        private static Random rnd = new Random();
        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";

        //Constructor
        private NoteId()
        {

        }

        //Methods
        public static string GenerateCodeID()
        {
            StringBuilder code = new StringBuilder();

            // Generate two random capital letters
            for (int i = 1; i <= 2; i++)
            {
                char capitalLetter = GenerateChar(CapitalLetters);
                InsertAtRandomPosition(code, capitalLetter);
            }
            // Generate two random small letters
            for (int i = 1; i <= 2; i++)
            {
                char smallLetter = GenerateChar(SmallLetters);
                InsertAtRandomPosition(code, smallLetter);
            }
            // Generate one random digit
            char digit = GenerateChar(Digits);
            InsertAtRandomPosition(code, digit);

            code.Append(".txt");


            return code.ToString();
        }
        private static void InsertAtRandomPosition(StringBuilder password, char character)
        {
            int randomPosition = rnd.Next(password.Length + 1);
            password.Insert(randomPosition, character);
        }
        private static char GenerateChar(string availableChars)
        {
            int randomIndex = rnd.Next(availableChars.Length);
            char randomChar = availableChars[randomIndex];
            return randomChar;
        }
    }
}
