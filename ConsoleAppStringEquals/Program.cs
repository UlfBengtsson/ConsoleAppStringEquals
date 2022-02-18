using System;
using System.Text;

namespace ConsoleAppStringEquals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Avoid getting confused by interning
            object x = new StringBuilder("hello").ToString();
            object y = new StringBuilder("hello").ToString();
            if (x.Equals(y)) // Yes
            {
                Console.WriteLine("x.Equals(y) returns True");
            }
            else
            {
                Console.WriteLine("x.Equals(y) returns False");
            }
            // The compiler doesn't know to call ==(string, string) so it generates
            // a reference comparision instead
            if (x == y) // No
            {
                Console.WriteLine("x == y returns True");
            }
            else
            {
                Console.WriteLine("x == y returns False");
            }

            string xs = (string)x;//I´m making C# re-think here and to optimise it will see that x and y are the same so it will make them both point at the same data
            string ys = (string)y;

            // Now *this* will call ==(string, string), comparing values appropriately
            if (xs == ys) // Yes
            {
                Console.WriteLine("xs == ys returns True");
            }
            else
            {
                Console.WriteLine("xs == ys returns False");
            }
        }
    }
}
