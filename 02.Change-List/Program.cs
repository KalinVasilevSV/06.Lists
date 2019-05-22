using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Change_List
{
    //Very happy with the use of while in the Delete() method

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            while (true)
            {
                Command command = new Command(Console.ReadLine());

                command.CompleteFor(list);

                if (command.action == "Odd" || command.action == "Even")
                    break;
            }
        }

        class Command
        {
            public string action;
            int? element;
            int? position;

            public Command(string input)
            {
                string[] command = input.Trim().Split();

                this.action = command[0];
                try
                {
                    this.element = int.Parse(command[1]);
                }
                catch (IndexOutOfRangeException)
                {
                    this.element = null;
                }

                try
                {
                    this.position = int.Parse(command[2]);
                }
                catch (IndexOutOfRangeException)
                {
                    this.position = null;
                }

            }

            public void CompleteFor(List<int> list)
            {
                switch (this.action)
                {
                    case "Delete":
                        DeleteElementIn(list);
                        break;
                    case "Insert":
                        InsertElementIn(list);
                        break;
                    case "Odd":
                        PrintOdd(list);
                        break;
                    case "Even":
                        PrintEven(list);
                        break;
                }
            }

            //Very happy with the use of while here

            void DeleteElementIn(List<int> list)
            {
                while(list.Remove((int)this.element));
            }

            void InsertElementIn(List<int> list)
            {
                list.Insert((int)this.position, (int)this.element);
            }

            void PrintOdd(List<int> list)
            {
                foreach (int element in list)
                {
                    if (element % 2 == 1)
                        Console.Write(element + " ");
                }
            }

            void PrintEven(List<int> list)
            {
                foreach (int element in list)
                {
                    if (element % 2 == 0)
                        Console.Write(element + " ");
                }
            }

        }
    }
}
