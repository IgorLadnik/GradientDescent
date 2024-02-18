using System;

namespace GradientDescentStd;

public static class GradientDescent
{
    public static Tuple<double[], int> ConstStep(Func<double[], double> func, double[] initX, double[] dx, double precision,
                                                 Func<double[], double>[] deriv = null)
    {
        var currX = initX;
        var currPrecision = double.MaxValue;
        var prevFunc = func(initX);

        int k;
        for (k = 0; currPrecision > precision; k++)
        {
            // Gradient
            var gradient = deriv == null
                                ? GetGradient(func, prevFunc, currX, dx)
                                : GetGradient(deriv, currX);

            // Next point
            for (var i = 0; i < initX.Length; i++)
                currX[i] -= dx[i] * gradient[i];

            // Func
            var currFunc = func(currX);
            currPrecision = Math.Abs(currFunc - prevFunc);
            prevFunc = currFunc;
        }

        return new Tuple<double[], int>(currX, k);
    }

    public static Tuple<double[], int> SteepestDescent(Func<double[], double> func, double[] initX, double[] dx, double precision,
                                                       Func<double[], double>[] deriv = null)
    {
        var currX = initX;
        var currPrecision = double.MaxValue;
        var prevFunc = func(initX);

        var changeGradient = true;
        double[] gradient = null;
        var prevX = new double[initX.Length];
        int k;
        for (k = 0; currPrecision > precision; k++)
        {
            // Gradient
            if (changeGradient)
                gradient = deriv == null
                    ? GetGradient(func, prevFunc, currX, dx)
                    : GetGradient(deriv, currX);

            // Next point
            for (var i = 0; i < initX.Length; i++)
            {
                prevX[i] = currX[i];
                currX[i] -= dx[i] * gradient[i];
            }

            // Func
            var currFunc = func(currX);
            currPrecision = Math.Abs(currFunc - prevFunc);

            if (changeGradient = currFunc > prevFunc)
            {
                for (var i = 0; i < initX.Length; i++)
                    currX[i] = prevX[i];
            }
            else
                prevFunc = currFunc;
        }

        return new Tuple<double[], int>(currX, k);
    }

    private static double[] GetGradient(Func<double[], double> func, double prevFunc, double[] x, double[] dx)
    {
        var gradient = new double[x.Length];
        var xD = new double[x.Length];
        for (var i = 0; i < x.Length; i++)
        {
            for (var j = 0; j < x.Length; j++)
                xD[j] = x[j];

            xD[i] += dx[i];
            gradient[i] = (func(xD) - prevFunc) / dx[i];
        }

        return gradient;
    }

    private static double[] GetGradient(Func<double[], double>[] deriv, double[] x)
    {
        var gradient = new double[x.Length];
        for (var i = 0; i < x.Length; i++)
            gradient[i] = deriv[i](x);

        return gradient;
    }
}
