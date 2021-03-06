﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChef
{
    class Program
    {
        public static bool IsBeautiful(List<int> seq)
        {
            if (seq.All(n => n % 4 == 0))
                return true;

            return false;
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            System.Threading.Thread.Sleep(500);
            stopwatch.Start();

            Console.WriteLine("Enter number of test cases");
            int numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for(int k = 1; k <= numberOfTestCases; k++)
            {
                Console.WriteLine("Enter sequence size");
                int seqSize = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the sequence numbers");
                List<int> primeSeq = Console.ReadLine()
                    .Split(' ')
                    .Select(m => Convert.ToInt32(m))
                    .ToList();

                int counta = 0;

                primeSeq = primeSeq.Where(n => n % 4 != 0).ToList();

                while (true)
                {
                start:
                    if (IsBeautiful(primeSeq))
                    {
                        Console.WriteLine("Sequence is beautiful");
                        break;
                    }

                    if (primeSeq.Count == 1)
                    {
                        Console.WriteLine("sequence cannot be beautiful");
                        break;
                    }

                    for (int i = 1; i < primeSeq.Count; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if ((primeSeq[i] + primeSeq[j]) % 4 == 0)
                            {
                                int x = primeSeq[i];
                                int y = primeSeq[j];

                                primeSeq.Remove(x);
                                primeSeq.Remove(y);
                                //primeSeq.Add(x + y);
                                counta++;
                                goto start;
                            }
                            if ((primeSeq[i] + primeSeq[j]) % 2 == 0)
                            {
                                int x = primeSeq[i];
                                int y = primeSeq[j];

                                primeSeq.Remove(x);
                                primeSeq.Remove(y);
                                //primeSeq.Add(x + y);
                                counta++;
                                goto start;
                            }
                        }
                    }
                    int a = primeSeq[0];
                    int b = primeSeq[1];

                    primeSeq.Remove(a);
                    primeSeq.Remove(b);
                    primeSeq.Add(a + b);
                    counta++;
                }
                Console.WriteLine("number of reps is {0}", counta);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }
    }
}

//A sequence of integers is beautiful if each element of this sequence is divisible by 4.
//You are given a sequence a1, a2, ..., an. In one step, you may choose any two elements
//of this sequence, remove them from the sequence and append their sum to the sequence.
//Compute the minimum number of steps necessary to make the given sequence beautiful.
//Input
//The first line of the input contains a single integer T denoting the number of test cases.
//The description of T test cases follows.
//The first line of each test case contains a single integer n.
//The second line contains n space-separated integers a1, a2, ..., an.
//Output
//For each test case, print a single line containing one number — the minimum number of
//steps necessary to make the given sequence beautiful. If it's impossible to make the
//sequence beautiful, print -1 instead.

//Constraints
//1 ≤ T ≤ 105
//1 ≤ n ≤ 105
//1 ≤ sum of n over all test cases ≤ 106
//0 ≤ ai ≤ 109

//Example

//Input:
//1
//7
//1 2 3 1 2 3 8

//Output:
//3
