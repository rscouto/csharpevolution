using CsharpEvolution.Tests01.SimpleCalculator;
using System;

namespace CharpEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator calculator = new SimpleCalculator();
            calculator.Calculate();

            Console.ReadKey();
            System.Environment.Exit(0);

        }
    }
}
