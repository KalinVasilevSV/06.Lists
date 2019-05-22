using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Array_Manipulator
{
    //Done but with just under 17.00MB of memory used

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            while (true)
            {
                Command command = new Command(Console.ReadLine());

                command.PerformOn(list);

                if (command.action == "print")
                    break;

            }

        }
    }

    class Command
    {
        public string action;
        int? atIndex;
        int? shiftBy;
        List<int> elements = new List<int>();

        public Command(string input)
        {
            string[] command = input.Trim().Split();

            switch (command[0])
            {
                case "add":
                    this.action = command[0];
                    this.atIndex = int.Parse(command[1]);
                    this.elements.Add(int.Parse(command[2]));
                    break;
                case "addMany":
                    this.action = command[0];
                    this.atIndex = int.Parse(command[1]);
                    for (int i = 2; i < command.Length; i++)
                    {
                        this.elements.Add(int.Parse(command[i]));
                    }
                    break;
                case "contains":
                    this.action = command[0];
                    this.elements.Add(int.Parse(command[1]));
                    break;
                case "remove":
                    this.action = command[0];
                    this.atIndex = int.Parse(command[1]);
                    break;
                case "shift":
                    this.action = command[0];
                    this.shiftBy = int.Parse(command[1]);
                    break;
                case "sumPairs":
                    this.action = command[0];
                    break;
                case "print":
                    this.action = command[0];
                    break;

                default: break;
            }
        }

        public void PerformOn(List<int> list)
        {
            switch (this.action)
            {
                case "add":
                    list.Insert((int)this.atIndex, elements[0]);
                    break;
                case "addMany":
                    list.InsertRange((int)this.atIndex, elements);
                    break;
                case "contains":
                    if (list.Contains(this.elements[0]))
                    {
                        Console.WriteLine(list.IndexOf(this.elements[0]));
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                    break;
                case "remove":
                    list.RemoveAt((int)this.atIndex);
                    break;
                case "shift":
                    ShiftLeft(list, (int)this.shiftBy);
                    break;
                case "sumPairs":
                    SumPairs(list);
                    break;
                case "print":
                    Console.WriteLine('[' + String.Join(", ", list).Trim() + ']');
                    break;

                default: break;
            }
        }

        public void ShiftLeft(List<int> list, int shiftBy)
        {
            List<int> newList = list.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                int newPosition;

                if (i - (shiftBy % list.Count) >= 0)
                {
                    newPosition = i - (shiftBy % list.Count);
                }
                else
                {
                    newPosition = list.Count + (i - (shiftBy % list.Count));
                }

                newList[newPosition] = list[i];
            }

            list.Clear();
            foreach (int element in newList)
            {
                list.Add(element);
            }

            GC.Collect();
        }

        public void SumPairs(List<int> list)
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < list.Count; i += 2)
            {
                try
                {
                    newList.Add(list[i] + list[i + 1]);
                }
                catch(ArgumentOutOfRangeException)
                {
                    newList.Add(list[i]);
                }
            }

            list.Clear();
            foreach(int element in newList)
            {
                list.Add(element);
            }

            GC.Collect();
        }

    }
}
