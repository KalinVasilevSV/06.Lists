using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Search_for_a_Number
{
    //Judge does not recognize some of the methods implemented in the latest C# libraries

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            Action action = new Action(Console.ReadLine());

            action.PerformOn(list);

        }
    }

    public class Action
    {
        public int numsToTake;
        public int numsToDelete;
        public int numToFind;

        public Action(string input)
        {
            string[] actions = input.Trim().Split();

            this.numsToTake = int.Parse(actions[0]);
            this.numsToDelete = int.Parse(actions[1]);
            this.numToFind = int.Parse(actions[2]);
        }

        public void PerformOn(List<int> list)
        {
            List<int> newList = new List<int>();
            //list = list.Take(numsToTake).ToList();
            //Judge does not recognize Take()
            for (int i = 0; i < this.numsToTake; i++)
            {
                newList.Add(list[i]);
            }
            list = newList;

            //list = list.TakeLast(list.Count - numsToDelete).ToList();
            //Judge does not recognize TakeLast()
            newList = new List<int>();
            for (int i = numsToDelete; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }
            list = newList;

            if (list.Contains(numToFind))
                Console.WriteLine("YES!");
            else
                Console.WriteLine("NO!");
        }
    }
}
