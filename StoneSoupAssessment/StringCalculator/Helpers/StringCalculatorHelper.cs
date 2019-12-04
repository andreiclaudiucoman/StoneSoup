using StoneSoupAssessment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StoneSoupAssessment.Helpers
{
    public static class StringCalculatorHelper
    {
        private static string[] defaultDelimiters = { ",", "\n" };

        private static string pattern = @"(?<=//)[^0-9a-zA-Z](?=\n)|(?<=\[)[^0-9a-zA-Z\[\]]+(?=\])";

        private static string[] GetCustomDelimiters(string numbers)
        {
            MatchCollection matches = Regex.Matches(numbers, pattern);

            if (matches.Count == 0)
            {
                return new string[0];
            }

            IList<string> customDelimiters = new List<string>();

            foreach (Match match in matches)
            {

                customDelimiters.Add(match.Value);
            }

            return customDelimiters.ToArray();
        }

        private static string[] GetAllDelimiters(string numbers)
        {
            string[] customDelimiters = GetCustomDelimiters(numbers);

            if (customDelimiters.Length == 0)
            {
                return defaultDelimiters;
            }

            return customDelimiters.Concat(defaultDelimiters).ToArray();
        }

        public static IList<int> GetListNumbersAsInt(string numbers)
        {
            string[] delimiters = GetAllDelimiters(numbers);
            string[] inputNumbersArray = numbers.Split(delimiters, StringSplitOptions.None);

            IList<int> validNumbers = new List<int>();
            IList<int> negativeNumbers = new List<int>();

            foreach (string strNumber in inputNumbersArray)
            {
                if (int.TryParse(strNumber, out int number))
                {
                    if (number < 0)
                    {
                        negativeNumbers.Add(number);
                    }
                    else if (number < 1000)
                    {
                        validNumbers.Add(number);
                    }
                }
            }

            if (negativeNumbers.Count() > 0)
            {
                throw new NegativeNumbersException($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
            }

            return validNumbers;
        }
    }
}
