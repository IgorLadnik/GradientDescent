using System;
using GradientDescentStd;

namespace GradientDescentApp;

class Program
{
    static void Main(string[] args)
    {
        var dx = 0.01;
        var precision = 1e-4;

        var t = GradientDescent.SteepestDescent(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                  initX: [10.0, 10.0],
                                                  dx: [dx, dx],
                                                  precision);

        Console.WriteLine($"SteepestDescent approx.:  {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

        t = GradientDescent.SteepestDescent(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                                  initX: [10.0, 10.0],
                                                  dx: [dx, dx],
                                                  precision,
                                                  deriv:
                                                  [
                                                      x => 20 * x[0],
                                                      x =>  2 * x[1],
                                                  ]);

        Console.WriteLine($"SteepestDescent accurate: {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

        t = GradientDescent.ConstStep(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                            initX: [10.0, 10.0],
                                            dx: [dx, dx],
                                            precision);

        Console.WriteLine($"ConstStep approx.:        {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

        t = GradientDescent.ConstStep(func: x => 10 * x[0] * x[0] + x[1] * x[1],
                                            initX: [10.0, 10.0],
                                            dx: [dx, dx],
                                            precision,
                                            deriv:
                                            [
                                                x => 20 * x[0],
                                                x =>  2 * x[1],
                                            ]);

        Console.WriteLine($"ConstStep accurate:       {t.Item2} steps, x0 = {t.Item1[0]}, x1 = {t.Item1[1]}");

        Console.WriteLine("\nPress any key to quit...");
        Console.ReadKey();
    }
}
