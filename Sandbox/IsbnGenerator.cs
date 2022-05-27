using System;
using System.Text;

namespace ISBN
{
    public static class IsbnGenerator
    {
        /// <summary>
        /// Generates isbn-code.
        /// </summary>
        /// <returns></returns>
        public static string GenerateISBN()
        {
            Random rand = new Random();
            int[] isbnIntArray = new int[10];
            int maxCheckSumMultimpier = 46;
            int checkSum = rand.Next(maxCheckSumMultimpier) * 11;
            for (int i = 0; i < 9; ++i)
            {
                int isbnElement = rand.Next(10);
                checkSum -= isbnElement * (10 - i);
                if (checkSum >= 0)
                {
                    isbnIntArray[i] = isbnElement;
                }
                else
                {
                    break;
                }
            }

            if (checkSum >= 0 && checkSum <= 10)
            {
                isbnIntArray[9] = checkSum;
                return ToString(isbnIntArray);
            }

            return GenerateISBN();
        }

        private static string ToString(int[] arr)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < 10; ++i)
            {
                res.Append(IntToChar(arr[i]));
            }

            return res.ToString();
        }

        private static char IntToChar(int n)
        {
            return n switch
            {
                0 => '0',
                1 => '1',
                2 => '2',
                3 => '3',
                4 => '4',
                5 => '5',
                6 => '6',
                7 => '7',
                8 => '8',
                9 => '9',
                10 => 'X',
                _ => throw new ArgumentOutOfRangeException(nameof(n), "Argument must be more or equal 0 or less or equal 10."),
            };
        }
    }
}

