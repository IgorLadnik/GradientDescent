using System;
using GradientDescentStd;

namespace GradientDescentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dx = 0.05;

            var t = GradientDescent.SteepestDescent(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                      initX: new[] { 10.0, 10.0 },
                                                      dx: new[] { dx, dx },
                                                      precision: 1e-4);

            Console.WriteLine($"SteepestDescent approx.:  {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

            t = GradientDescent.SteepestDescent(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                      initX: new[] { 10.0, 10.0 },
                                                      dx: new[] { dx, dx },
                                                      precision: 1e-4,
                                                      deriv: new Func<double[], double>[]
                                                      {
                                                          x => 20 * x[0],
                                                          x =>  2 * x[1],
                                                      });

            Console.WriteLine($"SteepestDescent accurate: {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

            t = GradientDescent.ConstStep(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                initX: new[] { 10.0, 10.0 },
                                                dx: new[] { dx, dx },
                                                precision: 1e-4);

            Console.WriteLine($"ConstStep approx.:        {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

            t = GradientDescent.ConstStep(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                initX: new[] { 10.0, 10.0 },
                                                dx: new[] { dx, dx },
                                                precision: 1e-4,
                                                deriv: new Func<double[], double>[]
                                                {
                                                    x => 20 * x[0],
                                                    x =>  2 * x[1],
                                                });

            Console.WriteLine($"ConstStep accurate:       {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
        }
    }
}
