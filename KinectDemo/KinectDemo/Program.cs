using System;

namespace KinectDemo
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                var a = int.Parse(Console.ReadLine());
                var b = int.Parse(Console.ReadLine());
                Console.WriteLine(Gcd(a, b));
            }
        }

        private static int Gcd(int a, int b)
        {
            if (a > b) return Gcd(b, a);

            if (a == 0)
            {
                return b;
            }
            if (a > 0)
            {
                return Gcd(b % a, a);
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
