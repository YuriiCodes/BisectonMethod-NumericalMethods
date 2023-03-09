using System;

namespace bisectionMethodNamespace
{
    public class Program
    {
        private static int Sign(double x)
        {
            return (x < 0) ? -1 : 1;
        }
        private static uint GetExpectedNumberOfIterations(double a, double b, double eps)
        {
            return (uint)Math.Truncate(Math.Log((b - a) / eps, 2)) + 1;
        }
        private static double BisectionMethod(double a, double b, double precision = 1e-3)
        {
            int i = 1;
            while (true)
            {
                var t = (a + b) / 2;

                if (F(t) == 0.0 || Math.Abs(b - a) < Math.Abs(precision))
                {
                    return t;
                }

                if (Sign(F(t)) == Sign(F(a)))
                {
                    Console.WriteLine($"{i}-th iteration:\ta = {a}\tb = {b}\t t={t}\t F(t)={F(t)}");
                    a = t;
                    ++i;
                }
                else
                {
                    Console.WriteLine($"{i}-th iteration:\ta = {a}\tb = {b}\t t={t}\t F(t)={F(t)}");
                    b = t;
                    ++i;
                }
            }
        }
        private static double F(double x) => Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - 4 * x + 16;
        
        public static void Main(string[] args)
        {
            double a = -5;
            double b = 0;
            double eps = 1e-3;
            // get epsilon input:
            Console.WriteLine("Enter epsilon:");
            eps = double.Parse(Console.ReadLine());

            Console.WriteLine("Expected number of iterations: {0}", GetExpectedNumberOfIterations(a, b, eps));
            var result = BisectionMethod(a, b, eps);
            Console.WriteLine("End result:");
            Console.WriteLine("x = {0}\r\nf({0}) = {1}", result, F(result));
        }
    }
}