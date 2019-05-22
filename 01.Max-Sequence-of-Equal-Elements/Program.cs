using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            int bestStart = 0;
            int bestLength = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                int count = 0;

                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[i] == elements[j]) count++;
                }

                if (count > bestLength)
                {
                    bestLength = count;
                    bestStart = i;
                }

                i += count;
            }

            for (int i = bestStart; i <= bestStart + bestLength; i++)
            {
                Console.Write(elements[i] + " ");
            }
        }
    }
}
