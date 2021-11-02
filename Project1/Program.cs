/// Week 10 Project 1
///
/// @author: Julian Trupe
/// Date:  November 1, 2021
///
/// Problem Statement: Create a Duelist class and simulate 10,000 duels between 3 participants
//
/// Overall Plan:
/// 1) Create Duelist class with properties name (string), accuracy (double), isAlive (bool), wins (int), shootAtTarget(Duelist enemy) method
/// 2) Each shooter must aim for the remaining Duelist with highest accuracy
/// 3) The last duelist alive wins
/// 4) Several commented section update console with relevant information as it occurs(hit/miss/eliminated/win)
/// 5)      Makes sure things are working as expected when doing a few duels, but too much information for 10,000 duels
/// 6) Test one duel, several times to ensure different results
/// 7) Loop 10 duels to make sure things are still working as expected
/// 8) Run program several times with 10,000 duels
/// 9)      After the program finished each time, check that percent win for each person is close to the previous run, as expected
/// 10) Comment/Delete line 41 to simulate alternate strategy where Aaron misses his first shot
/// 11)     Repeat (6)-(9) for the new strategy
/// 
/// Conclusion: It seems like Aaron's strategy to miss his first shot gives him a higher chance 
///             to win the duel than if he did not miss.           

using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSims = 10000;
            double percentWinA, percentWinB, percentWinC;
            Duelist aaron = new Duelist("Aaron", .333333333333333333333333333333333333333);
            Duelist bob = new Duelist("Bob", .5);
            Duelist charlie = new Duelist("Charlie", .95);
            Console.WriteLine("Below we will test our Duelist class by simulating duels");

            for(int i=0; i<numSims; i++)
            {
                //reset all Duelists to alive
                aaron.isAlive = bob.isAlive = charlie.isAlive = true;

                //Aaron shoots at Charlie first, comment line below to simulate alternate strategy where Aaron misses his first shot
                aaron.shootAtTarget(charlie);
                while (bob.isAlive || aaron.isAlive || charlie.isAlive)
                {
                    if (charlie.isAlive)
                    {
                        if (bob.isAlive)
                        {
                            bob.shootAtTarget(charlie);
                            if (charlie.isAlive)
                            {
                                charlie.shootAtTarget(bob);
                                aaron.shootAtTarget(charlie);
                            }
                            else
                            {
                                aaron.shootAtTarget(bob);
                            }
                        }
                        else if (aaron.isAlive)
                        {
                            charlie.shootAtTarget(aaron);
                            if (aaron.isAlive)
                            {
                                aaron.shootAtTarget(charlie);
                            }
                            else
                            {
                                charlie.wins++;
                                //Console.WriteLine("Charlie wins round " + (i+1));

                                //kill Charlie to exit while loop
                                charlie.isAlive = false;
                            }
                        }
                        else
                        {
                            charlie.wins++;
                            //Console.WriteLine("Charlie wins round " + (i+1));

                            //kill Charlie to exit while loop
                            charlie.isAlive = false;
                        }
                    }
                    else if (aaron.isAlive && bob.isAlive)
                    {
                        bob.shootAtTarget(aaron);
                        if (aaron.isAlive)
                        {
                            aaron.shootAtTarget(bob);
                            if (!bob.isAlive)
                            {
                                aaron.wins++;
                                //Console.WriteLine("Aaron wins round " + (i+1));

                                //kill Aaron to exit while loop
                                aaron.isAlive = false;
                            }
                        }
                        else
                        {
                            bob.wins++;
                            //Console.WriteLine("Bob Wins round " + (i+1));

                            //kill Bob to exit while loop
                            bob.isAlive = false;
                        }
                    }
                    else if (aaron.isAlive)
                    {
                        aaron.wins++;
                        //Console.WriteLine("Aaron wins round " + (i + 1));

                        //kill Aaron to exit while loop
                        aaron.isAlive = false;
                    }
                    else if (bob.isAlive)
                    {
                        bob.wins++;
                        //Console.WriteLine("Bob Wins round " + (i + 1));

                        //kill Bob to exit while loop
                        bob.isAlive = false;
                    }
                }
            }
            percentWinA = 100 * ((double)aaron.wins / numSims);
            percentWinB = 100 * ((double)bob.wins / numSims);
            percentWinC = 100 * ((double)charlie.wins / numSims);
            Console.WriteLine("Aaron won " + aaron.wins + " out of " + numSims + " duels or " + Math.Round(percentWinA, 2) + "%");
            Console.WriteLine("Bob won " + bob.wins + " out of " + numSims + " duels or " + Math.Round(percentWinB, 2) + "%");
            Console.WriteLine("Charlie won " + charlie.wins + " out of " + numSims + " duels or " + Math.Round(percentWinC, 2) + "%");
        }
    }

    public class Duelist
    {
        public string name;
        public double accuracy;
        public bool isAlive;
        public int wins;

        public Duelist(string duelistName, double acc)
        {
            name = duelistName;
            accuracy = acc;
            isAlive = true;
            wins = 0;
        }

        public void shootAtTarget(Duelist enemy)
        {
            Random rand = new Random();
            // using 60 because it is the LCM of 2,3,20
            bool shotSuccess = rand.Next(60) <= (60 *accuracy - 1);
            if (shotSuccess)
            {
                //Console.WriteLine(name + " has shot and eliminated " + enemy.name);
                enemy.isAlive = false;
            } else
            {
                //Console.WriteLine(name + "'s shot missed " + enemy.name);
            }
        }
    }
}
