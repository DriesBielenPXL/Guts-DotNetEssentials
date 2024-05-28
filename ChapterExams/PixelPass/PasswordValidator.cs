using System;

namespace PixelPass
{
    public class PasswordValidator
    {
        private const int MinimumLength = 5;
        private const int AverageLength = 10;

        private const string alfabetSmallCaps = "abcdefghijklmnopqrstuvwxyz";
        private const string alfabetUpperCaps = "ABCEDFGHIJKLMNOPQRSTUVWXYZ";
        private const string digits = "0123456789";

        public static Strength CalculateStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Strength.Weak;
            }

            int length = password.Length;
            bool hasLower = password.Contains(alfabetSmallCaps);
            bool hasUpper = password.Contains(alfabetUpperCaps);
            bool hasDigit = password.Contains(digits);

            int charTypes = 0;

            if (hasLower) charTypes++;
            if (hasUpper) charTypes++;
            if (hasDigit) charTypes++;

            if (length < 5)
            {
                return Strength.Weak;
            }
            if (charTypes >= 3 && length >= 10)
            {
                return Strength.Strong;
            }
            if (charTypes == 1 ) {
                return Strength.Weak;
            }
            return Strength.Average;
        }
    }

    public enum Strength
    {
        Weak,
        Average,
        Strong
    }
}