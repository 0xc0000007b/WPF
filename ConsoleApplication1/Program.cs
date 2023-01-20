using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var res = String.Empty.Split((char)StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(res);
        }
    }
}