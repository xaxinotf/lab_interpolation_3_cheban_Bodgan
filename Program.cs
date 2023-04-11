namespace Interpol
{
    public class Program
    {
        static double F(double x)
        {
            return Math.Pow(x, 4) - 2 * Math.Pow(x, 3) + Math.Pow(x, 2) - 2 * x + 1;
        }

        static double[,] Table(double x, double h, int n)
        {
            int index = 0;
            double[,] matrix = new double[n, 3];
            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = index;
                matrix[i, 1] = x;
                matrix[i, 2] = Math.Round(F(x), 6);
                index++;
                x += h;
                x = Math.Round(x, 4);
            }
            return matrix;
        }

        static string L(int n, double[,] table)
        {
            string lagrangian = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        lagrangian += $"(x - {table[j, 0]})";
                    }
                }
                double num = 1;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        num *= Math.Round(table[j, 1] - table[j, 0], 5);
                    }
                }
                lagrangian += "(" + Math.Round(table[i, 2] / num, 7) + ")";

                if (i != n - 1)
                {
                    lagrangian += " + ";
                }
            }
            return lagrangian;
        }

        static double[,] NTable(double x, double h, int n)
        {
            int index = 0;
            double[,] matrix = new double[n, n + 2];
            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = index;
                matrix[i, 1] = x;
                matrix[i, 2] = Math.Round(F(x), 5);
                index++;
                x += h;
                x = Math.Round(x, 4);
            }

            return matrix;
        }

        static double[,] N(int i, double[,] table, int k)
        {
            double a;
            double b = 0;
            for (int j = 0; j < i; j++)
            {
                a = b;
                b = Math.Round(table[j, k], 5);
                if (j == 0)
                {
                    continue;
                }
                else
                {
                    table[j - 1, k + 1] = Math.Round(b - a, 7);
                }
            }
            a = 0;
            b = 0;

            if (k != 12)
            {
                N(i - 1, table, k + 1);
            }
            return table;
        }

        static int fact(int a)
        {
            int b = 1;
            for (int k = 1; k != a + 1; k++)
            {
                b *= k;
            }

            return b;
        }

        public static void Main()
        {
            //==============================================================
            //                          Lagranj
            //==============================================================

            // [-1 ; 1]
            double a = -1;
            double b = 1;
            int n =10;
            double h = (double)(b - a) / n;

            var matrix = Table(a, h, n);

            Console.WriteLine();
            Console.WriteLine(" ----------------------------");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" | " + matrix[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine(" ----------------------------");
            }
            Console.WriteLine();
            var str = L(n, matrix);

            Console.WriteLine(str);//Вивід Лагранжіана
            Console.WriteLine("\n\n");

            //==============================================================
            //                          Newton
            //==============================================================

            var nmatrix = NTable(a, h, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    Console.Write(nmatrix[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------");
            }

            var Nmatrix = N(10, nmatrix, 2);

            Console.WriteLine();
            Console.WriteLine("!!!NEWTON!!!");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    Console.Write(Nmatrix[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------");
            }
            Console.WriteLine();

            string newton = "(" + Nmatrix[0, 2].ToString() + ")";

            for (int i = 1; i < 10; i++)
            {
                newton += " + ";
                newton += $"({Math.Round(Nmatrix[0, i + 2] / (fact(i) * Math.Pow(h, i)), 4)})";
                for (int j = 0; j < i; j++)
                {
                    double aa = Nmatrix[j, 1];
                    if (aa >= 0)
                    {
                        newton += $"(x - {Math.Abs(aa)})";
                    }
                    else
                    {
                        newton += $"(x + {Math.Abs(aa)})";
                    }
                    aa = 0;
                }
            }

            Console.WriteLine(newton);

            using (StreamWriter stream = new StreamWriter(@"D:\res.txt"))
            {
                string s = "";
                for (int index = 0; index < str.Length; index++)
                {
                    if (str[index] == '(')
                    {
                        s += @"\left(";
                    }
                    else if (str[index] == ')')
                    {
                        s += @"\right)";
                    }
                    else if (str[index] == ',')
                        s += ".";
                    else if (str[index] == 'E')
                    {
                        s += @"\cdot10^{" + str[index + 1] + str[index + 2] + str[index + 3] + "}";
                        index += 3;
                    }
                    else
                        s += str[index];
                }

                stream.Write(s);

                stream.WriteLine("\n\n\n");

                s = "";

                for (int index = 0; index < newton.Length; index++)
                {
                    if (newton[index] == '(')
                    {
                        s += @"\left(";
                    }
                    else if (newton[index] == ')')
                    {
                        s += @"\right)";
                    }
                    else if (newton[index] == ',')
                        s += ".";
                    else if (newton[index] == 'E')
                    {
                        s += @"\cdot10^{" + newton[index + 1] + newton[index + 2] + newton[index + 3] + "}";
                        index += 3;
                    }
                    else
                        s += newton[index];
                }

                stream.Write(s);
            }
        }
    }
}