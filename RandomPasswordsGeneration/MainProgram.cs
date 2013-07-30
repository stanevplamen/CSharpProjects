using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumbersGeneration
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNumbers.Generator.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static class RandomNumbers
        {
            public static Random Generator = new Random();
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            PasswordsGenerator passwordsGenerator = new PasswordsGenerator();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(passwordsGenerator.Generate(12));
            }
        }

        public static class RandomNumbers
        {
            public static Random Generator = new Random();
        }

        public class PasswordsGenerator
        {
            private readonly string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
            private readonly string alphabetUpper;
            private readonly string digits = "123456789";
            private readonly string specialCharacters = "!@#$%^&*()_-+<>";

            private const int percentAlphabetLower = 25;
            private const int percentAlphabetUpper = 25;
            private const int percentDigits = 25;

            private readonly Random random;

            public PasswordsGenerator()
            {
                random = new Random();
                alphabetUpper = alphabetLower.ToUpper();
            }

            public string Generate(int length = 10)
            {
                int alphaLowerCount = length * percentAlphabetLower / 100;
                int alphaUpperCount = length * percentAlphabetUpper / 100;
                int alphaDigitsCount = length * percentDigits / 100;
                int alphaSpecialCount = length - alphaLowerCount - alphaUpperCount - alphaDigitsCount;

                List<char> randomPassword = new List<char>();
                for (int i = 1; i <= alphaLowerCount; i++)
                {
                    int randomIndex = RandomNumbers.Generator.Next(0, alphabetLower.Length);
                    char randomChar = alphabetLower[randomIndex];
                    randomPassword.Add(randomChar);
                }

                for (int i = 1; i <= alphaUpperCount; i++)
                {
                    int randomIndex = RandomNumbers.Generator.Next(0, alphabetUpper.Length);
                    char randomChar = alphabetUpper[randomIndex];
                    randomPassword.Add(randomChar);
                }

                for (int i = 1; i <= alphaDigitsCount; i++)
                {
                    int randomIndex = RandomNumbers.Generator.Next(0, digits.Length);
                    char randomChar = digits[randomIndex];
                    randomPassword.Add(randomChar);
                }


                for (int i = 1; i <= alphaSpecialCount; i++)
                {
                    int randomIndex = RandomNumbers.Generator.Next(0, specialCharacters.Length);
                    char randomChar = specialCharacters[randomIndex];
                    randomPassword.Add(randomChar);
                }

                randomPassword.Shuffle();
                return string.Concat(randomPassword);
            }
        }
    }
}
