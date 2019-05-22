using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(ReverseStringToInt).ToList();

            Console.WriteLine(list.Sum());

        }

        static int ReverseStringToInt(string input)
        {
            string newString = string.Empty;

            for (int i = input.Length-1; i >=0; i--)
            {
                newString += input[i];
            }

            return int.Parse(newString);
        }
    }
}
