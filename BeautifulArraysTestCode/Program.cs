using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static void Iterate(List<int> seq)
        {
            int x = seq[0];
            int y = seq[1];
            seq.Remove(x);
            seq.Remove(y);
            seq.Add(x + y);
        }

        public static void Iterate2(List<int> seq, List<int> minorSeq2)
        {
            int x = minorSeq2[0];
            int y = minorSeq2[1];
            seq.Remove(x);
            seq.Remove(y);
        }

        public static void Iterate13(List<int> seq, List<int> minorSeq1, List<int> minorSeq3)
        {
            int x = minorSeq1[0];
            int y = minorSeq3[0];
            seq.Remove(x);
            seq.Remove(y);
            seq.Add(x + y);
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Threading.Thread.Sleep(500);

            //Console.WriteLine("Enter number of test cases");
            int numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (int k = 1; k <= numberOfTestCases; k++)
            {
                //Console.WriteLine("Enter sequence size");
                int seqSize = Convert.ToInt32(Console.ReadLine());

                //Console.WriteLine("Enter the sequence numbers");
                var primeSeq = Console.ReadLine()
                    .Split(' ')
                    .Select(m => Convert.ToInt32(m))
                    .ToList();

                int counta = 0;

                primeSeq = primeSeq.Where(n => n % 4 != 0).ToList();

                while (true)
                {
                    start:
                    var primeSeq1 = primeSeq.Where(n => n % 4 == 1).ToList();
                    var primeSeq2 = primeSeq.Where(n => n % 4 == 2).ToList();
                    var primeSeq3 = primeSeq.Where(n => n % 4 == 3).ToList();

                    if (IsBeautiful(primeSeq))
                    {
                        //Console.WriteLine("Sequence is beautiful");
                        break;
                    }

                    if (primeSeq.Count == 1)
                    {
                        //Console.WriteLine("sequence cannot be beautiful");
                        break;
                    }

                    if (primeSeq2.Count >= 2)
                    {
                        Iterate2(primeSeq, primeSeq2);
                        counta++;
                        goto start;
                    }

                    if (primeSeq1.Count >= 1 && primeSeq3.Count >= 1)
                    {
                        Iterate13(primeSeq, primeSeq1, primeSeq3);
                        counta++;
                        goto start;
                    }

                    if (primeSeq1.Count >= 4)
                    {
                        Iterate2(primeSeq, primeSeq1);
                        counta++;
                        goto start;
                    }

                    if (primeSeq3.Count >= 4)
                    {
                        Iterate2(primeSeq, primeSeq3);
                        counta++;
                        goto start;
                    }

                    Iterate(primeSeq);
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
