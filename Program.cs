
using System;
//n=16
class NewtonInterpolation
{
    static void Main()
    {
        int n = 17;
        double[] x = { -1, -0.8125, -0.625,-0.4375, -0.25, -0.0625, 0.125, 0.3125,0.5, 0.6875, 0.875, 1.0625,1.25, 1.4375, 1.625, 1.8125,2 };
        double[] y = {7, 4.7937164306640625, 3.281494140625, 2.2705230712890625, 1.59765625, 1.1294097900390625, 0.761962890625, 0.4211578369140625, 0.0625, -0.3288421630859375, -0.738037109375, -1.1205902099609375, -1.40234375, -1.4794769287109375, -1.218505859375, -0.4562835693359375, 1 };
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



/*
using System;
//n=8
class NewtonInterpolation
{
    static void Main()
    {
        int n = 9;
        double[] x = {-1, -0.625, -0.25, 0.125,0.5, 0.875,1.25, 1.625,2};
        double[] y = {7, 3.281494140625, 1.59765625, 0.761962890625, 0.0625, -0.738037109375, -1.40234375, -1.218505859375, 1 };
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
//n=4
class NewtonInterpolation
{
    static void Main()
    {
        int n = 5;
        double[] x = { -1,-0.25,0.5, 1.25, 2};
        double[] y = {7, 1.59765625, 0.0625, -1.40234375,1 };
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


