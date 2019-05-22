using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

            Bomb bomb = new Bomb(Console.ReadLine());

            bomb.Explode(sequence);

            Console.WriteLine(sequence.Sum());
        }

        class Bomb
        {
            int model;
            int power;

            public Bomb(string input)
            {
                int[] bombSpecs = input.Trim().Split().Select(int.Parse).ToArray();
                int model = bombSpecs[0];
                int power = bombSpecs[1];

                this.model = model;
                this.power = power;
            }

            public void Explode(List<int> sequence)
            {
                int bombLocation;

                while (sequence.Contains(this.model))
                {
                    //sequence.RemoveRange(bombLocation - this.power, this.power);
                    //Above code throws exception when fewer elements on either side ofthe bomb than the power
                    //May be included as part of an encompassing try

                    for (int i = 1; i <=power; i++)
                    {
                        bombLocation = sequence.IndexOf(this.model);
                        try
                        {
                            sequence.RemoveAt(bombLocation - 1);
                        }catch(ArgumentOutOfRangeException)
                        {
                            break;
                        }
                    }

                    //sequence.RemoveRange(bombLocation + 1, this.power);
                    //Above code throws exception when fewer elements on either side ofthe bomb than the power
                    //May be included as part of an encompassing try

                    for (int i = 1; i <= power; i++)
                    {
                        bombLocation = sequence.IndexOf(this.model);
                        try
                        {
                            sequence.RemoveAt(bombLocation + 1);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            break;
                        }
                    }

                    bombLocation = sequence.IndexOf(this.model);
                    sequence.RemoveAt(bombLocation);
                }
            }
        }

    }
}
