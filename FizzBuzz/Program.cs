using System;
using System.IO;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
            OutputObject output = fizzBuzzDetector.getOverlappings(input);
            Console.WriteLine(output.count);
        }
    }
}