using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Longest_Increasing_Subsequence
{
    //Unfinished

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            List<int> longestSequence = new List<int>();

            for (int A = 0; A < list.Count; A++)
            {
                List<int> sequence = new List<int>();
                sequence.Add(list[A]);
                
                for (int B = A + 1; B < list.Count; B++)
                {
                    if (list[B] > list[A])
                    {
                        for (int C = B+1; C < list.Count; C++)
                        {
                            if (list[C] < list[B] && list[C] > list[A]) sequence.Add(list[C]);
                        }
                    }
                }

                if (sequence.Count > longestSequence.Count)
                    longestSequence = sequence;
            }

            Console.WriteLine(String.Join(' ', longestSequence));

        }
    }
}
