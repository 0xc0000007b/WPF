using System;
using System.Text.RegularExpressions;

namespace CA
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine());
            
             
            Console.Write(f % 2 != 0 ? "YES" : "NO");
           
        }
    }
}