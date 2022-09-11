using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RomanNumeralsConverter
{
    public class Converter
    {
        public char[] RomanNumeral { get;  set; }
        public Dictionary<char, int> NumeralsList;

        public Converter(string romanNumeral)
        {
            RomanNumeral = romanNumeral.ToUpper().ToCharArray();

            NumeralsList = new Dictionary<char, int>
            {
                { 'I',1 },

                { 'V', 5},

                { 'X', 10 },

                { 'L',50 },

                { 'C',100 },

                { 'D',500 },

                { 'M',1000 }
            };

        }


        private bool CheckForValidity()
        {
            // Checking whether user entered valid pattern of Roman Numeral
            string pattern = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(new string(RomanNumeral));

            return match.Success;
        }
        public int ConvertToNumber()
        {
            int sum = 0;
            int firstNumber = 0;
            int nextNumber = 0;

            if (CheckForValidity() == false)
            {
                sum = -1;
                return sum;
            }

            int len = RomanNumeral.Length;
            for (int i = 0; i < len; i++)
            {
                firstNumber = NumeralsList[RomanNumeral[i]];
                if (len == 1)
                {
                    //if only one numeral character is entered by user
                    sum += firstNumber;
                    break;
                }

                if ((i + 1) < len)
                {
                    //if user entered multi character numeral
                    nextNumber = NumeralsList[RomanNumeral[i + 1]];
                    if (firstNumber < nextNumber)
                    {
                        sum += (nextNumber - firstNumber);
                        i++;
                    }
                    else
                    {
                        sum += firstNumber;
                    }
                }
                else
                {
                    if (i + 1 == len)
                    {
                        sum += firstNumber;
                        break;

                    }
                }

            }
            return sum;

        }
    }
}




