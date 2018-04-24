using System;
using static System.Console;
using Program;
using System.Diagnostics;

namespace TPLab
{
    class Class1
    {
        public static void Main()
        {

            WriteLine("WYKONYWANIE TESTU WYDAJNOSCIOWEGO...");
            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();
            Stopwatch stopWatch3 = new Stopwatch();
            Stopwatch stopWatch4 = new Stopwatch();
            Stopwatch stopWatch5 = new Stopwatch();
            Console.WriteLine("Wykonywanie testu tworzenia po 10 sztuk...");
            stopWatch1.Start();
            WypelnijLosowymi w1 = new WypelnijLosowymi(10, 10, 10, 10);
            stopWatch1.Stop();
            Console.WriteLine("Po 10 sztuk: " + stopWatch1.Elapsed);
            Console.WriteLine("Wykonywanie testu tworzenia po 100 sztuk...");
            stopWatch2.Start();
            WypelnijLosowymi w2 = new WypelnijLosowymi(100, 100, 100, 100);
            stopWatch2.Stop();
            Console.WriteLine("Po 100 sztuk: " + stopWatch2.Elapsed);
            Console.WriteLine("Wykonywanie testu tworzenia po 1000 sztuk...");
            stopWatch3.Start();
            WypelnijLosowymi w3 = new WypelnijLosowymi(1000, 1000, 1000, 1000);
            stopWatch3.Stop();
            Console.WriteLine("Po 1000 sztuk: " + stopWatch3.Elapsed);
            Console.WriteLine("Wykonywanie testu tworzenia po 10000 sztuk...");
            stopWatch4.Start();
            WypelnijLosowymi w4 = new WypelnijLosowymi(10000, 10000, 10000, 10000);
            stopWatch4.Stop();
            Console.WriteLine("Po 10000 sztuk: " + stopWatch4.Elapsed);
            Console.WriteLine("Wykonywanie testu tworzenia po 100000 sztuk...");
            stopWatch5.Start();
            WypelnijLosowymi w5 = new WypelnijLosowymi(100000, 100000, 100000, 100000);
            stopWatch5.Stop();
            Console.WriteLine("Po 100000 sztuk: " + stopWatch5.Elapsed);


            ReadKey();
            ReadKey();



        }
    }
}
