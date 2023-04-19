/*
using System;
//n=16
class NewtonInterpolation
{
    static void Main()
    {
        int n = 17;
        double[] x = { 0, 0.125, 0.25, 0.375, 0.5 ,0.625, 0.75,0.875, 1, 1.125, 1.25,1.375, 1.5, 1.625, 1.75, 1.875, 2  };
        double[] y = { 1, 0.761962890625, 0.53515625, 0.304931640625, 0.0625, -0.195068359375, -0.46484375, -0.738037109375,-1, -1.230224609375, -1.40234375, -1.484130859375, -1.4375, -1.218505859375, -0.77734375, -0.058349609375, 1 };
        double[] a = new double[n];
        double[,] b = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            a[i] = y[i];
            b[i, 0] = y[i];
        }

        for (int j = 1; j < n; j++)
        {
            for (int i = j; i < n; i++)
            {
                b[i, j] = (b[i, j - 1] - b[i - 1, j - 1]) / (x[i] - x[i - j]);
            }
            a[j] = b[j, j];
        }

        Console.WriteLine("x\tf(x)\t");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(x[i] + "\t" + y[i]);
        }
        Console.WriteLine("\nNewton Interpolating Polynomial:");
        Console.Write("L(x) = ");
        for (int j = 0; j < n; j++)
        {
            if (j > 0)
            {
                Console.Write(" + ");
            }
            Console.Write(a[j].ToString("0.##################"));
            for (int i = 0; i < j; i++)
            {
                Console.Write("*(x-" + x[i].ToString("0.##################") + ")");
            }
        }
    }
}
*/


/*
using System;
//n=8
class NewtonInterpolation
{
    static void Main()
    {
        int n = 9;
        double[] x = {0, 0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75, 2 };
        double[] y = {1, 0.53515625, 0.0625, -0.46484375,-1, -1.40234375, -1.4375, -0.77734375, 1};
        double[] a = new double[n];
        double[,] b = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            a[i] = y[i];
            b[i, 0] = y[i];
        }

        for (int j = 1; j < n; j++)
        {
            for (int i = j; i < n; i++)
            {
                b[i, j] = (b[i, j - 1] - b[i - 1, j - 1]) / (x[i] - x[i - j]);
            }
            a[j] = b[j, j];
        }

        Console.WriteLine("x\tf(x)\t");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(x[i] + "\t" + y[i]);
        }
        Console.WriteLine("\nNewton Interpolating Polynomial:");
        Console.Write("L(x) = ");
        for (int j = 0; j < n; j++)
        {
            if (j > 0)
            {
                Console.Write(" + ");
            }
            Console.Write(a[j].ToString("0.##################"));
            for (int i = 0; i < j; i++)
            {
                Console.Write("*(x-" + x[i].ToString("0.##################") + ")");
            }
        }
    }
}
*/

using System;
//n=4
class NewtonInterpolation
{
    static void Main()
    {
        int n = 5;
        double[] x = { 0, 0.5, 1, 1.5, 2 };
        double[] y = {1, 0.0625, -1, -1.4375, 1 };
        double[] a = new double[n];
        double[,] b = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            a[i] = y[i];
            b[i, 0] = y[i];
        }

        for (int j = 1; j < n; j++)
        {
            for (int i = j; i < n; i++)
            {
                b[i, j] = (b[i, j - 1] - b[i - 1, j - 1]) / (x[i] - x[i - j]);
            }
            a[j] = b[j, j];
        }

        Console.WriteLine("x\tf(x)\t");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(x[i] + "\t" + y[i]);
        }
        Console.WriteLine("\nNewton Interpolating Polynomial:");
        Console.Write("L(x) = ");
        for (int j = 0; j < n; j++)
        {
            if (j > 0)
            {
                Console.Write(" + ");
            }
            Console.Write(a[j].ToString("0.##################"));
            for (int i = 0; i < j; i++)
            {
                Console.Write("*(x-" + x[i].ToString("0.##################") + ")");
            }
        }
    }
}


