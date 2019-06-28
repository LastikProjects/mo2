using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите количество строк");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите количество столбцов");
            //int m = Convert.ToInt32(Console.ReadLine());
            //int[,] matrix = new int[n, m];
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.WriteLine("Введите {0} элемент {1} строки", j, i);
            //        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            int n = 4, m = 5;
            int[,] matrix = { { 5, 4, 1, 2, 60 }, { 4, 2, 6, 3, 40 }, { 7, 3, 5, 4, 35 }, { 40, 25, 20, 50, -1 } };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            int[,] matrix2 = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix2[i, j] = -1;
                }
            }
            for (int i = 0; i < m; i++)
                matrix2[n - 1, i] = matrix[n - 1, i];
            for (int i = 0; i < n; i++)
                matrix2[i, m - 1] = matrix[i, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", matrix2[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            int sym = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < m - 1; j++)
                    sym += matrix2[i, j] * matrix[i, j];
            int counter = 0;
            while (counter < 20)
            {
                int stolbec = 0, stroka = 0;
                while (matrix2[n - 2, m - 1] != -1 & matrix2[n - 1, m - 2] != -1)
                {
                    if (matrix2[n - 1, stolbec] > matrix2[stroka, m - 1])
                    {
                        matrix2[stroka, stolbec] = matrix2[stroka, m - 1];
                        matrix2[n - 1, stolbec] -= matrix2[stroka, m - 1];
                        matrix2[stroka, m - 1] = -1;
                        stroka++;
                    }
                    else if (matrix2[n - 1, stolbec] < matrix2[stroka, m - 1])
                    {
                        matrix2[stroka, stolbec] = matrix2[n - 1, stolbec];
                        matrix2[stroka, m - 1] -= matrix2[n - 1, stolbec];
                        matrix2[n - 1, stolbec] = -1;
                        stolbec++;
                    }
                    else
                    {
                        matrix2[stroka, stolbec] = matrix2[n - 1, stolbec];
                        matrix2[n - 1, stolbec] = -1;
                        matrix2[stroka, m - 1] = -1;
                        stolbec++;
                        stroka++;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("{0} ", matrix2[i, j]);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                int[] a = new int[n - 1];
                int[] b = new int[m - 1];
                for (int i = 0; i < n - 1; i++)
                    a[i] = 5000;
                for (int i = 0; i < m - 1; i++)
                    b[i] = 5000;
                a[0] = 0;
                bool flag = true;
                while (flag)
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = 0; j < m - 1; j++)
                        {
                            if (matrix2[i, j] != -1)
                                if (a[i] == 5000 & b[j] != 5000)
                                    a[i] = matrix[i, j] - b[j];
                                else
                                    if (b[j] == 5000 & a[i] != 5000)
                                    b[j] = matrix[i, j] - a[i];
                        }
                    }
                    flag = false;
                    for (int i = 0; i < a.Length; i++)
                        if (a[i] == 5000)
                            flag = true;
                    for (int i = 0; i < b.Length; i++)
                        if (b[i] == 5000)
                            flag = true;
                }
                for (int i = 0; i < n-1; i++)
                    Console.Write("alpha[{0}]={1} ", i, a[i]);
                Console.WriteLine();
                for (int i = 0; i < m-1; i++)
                    Console.Write("beta[{0}]={1} ", i, b[i]);
                Console.WriteLine();
                int perem = 0, perem1 = 0, perem2 = 0, Temp = 0;
                //for (int i = 0; i < n - 1; i++)
                //{
                //    for (int j = 0; j < m - 1; j++)
                //    {
                //        if (matrix2[i, j] == -1)
                //        {
                //            Temp = matrix[i, j] - a[i] - b[j];
                //            perem = Temp;
                //            perem1 = i;
                //            perem2 = j;
                //            break;
                //        }
                //    }
                //}
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (matrix2[i, j] == -1)
                        {
                            Temp = matrix[i, j] - a[i] - b[j];
                            Console.Write("delta{0}{1}={2} ", i, j, Temp);
                        }
                        if (Temp < perem)
                        {
                            perem = Temp;
                            perem1 = i;
                            perem2 = j;
                        }
                    }
                }
                Console.WriteLine();
                if (perem >= 0)
                    break;
                else
                {
                    int[] smena1 = new int[0];
                    int[] smena2 = new int[0];
                    bool first = true;
                    bool finish = false;
                    caterpillar(matrix2, perem1, perem2, n, m, first, ref smena1, ref smena2,ref finish, perem1, perem2);
                    int min = matrix2[smena1[0], smena2[0]];
                    for (int i = 2; i < smena1.Length; i += 2)
                    {
                        if (matrix2[smena1[i], smena2[i]] < min)
                            min = matrix2[smena1[i], smena2[i]];
                    }
                    matrix2[perem1, perem2] += 1;
                    for (int i = 0; i < smena1.Length; i++)
                    {
                        if (i % 2 == 0)
                            matrix2[smena1[i], smena2[i]] -= min;
                        else
                            matrix2[smena1[i], smena2[i]] += + min;
                        //if (matrix2[smena1[i], smena2[i]] == 0)
                        //    matrix2[smena1[i], smena2[i]] = -1;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (matrix2[smena1[i], smena2[i]] == 0)
                            {
                                matrix2[smena1[i], smena2[i]] = -1;
                                goto m1;
                            }
                        }
                    }
                   m1:         for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            Console.Write("{0} ", matrix2[i, j]);
                        }
                        Console.WriteLine();
                    }
                    sym = 0;
                    for (int i = 0; i < n - 1; i++)
                        for (int j = 0; j < m - 1; j++)
                            if (matrix2[i, j] != -1)
                                sym += matrix2[i, j] * matrix[i, j];
                    Console.WriteLine("{0}", sym);
                    sym = 0;
                }
                counter++;
            }
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < m - 1; j++)
                    if (matrix2[i, j] != -1)
                        sym += matrix2[i, j] * matrix[i, j];
            Console.WriteLine("{0}", sym);
            Console.ReadKey();
        }
        static public void caterpillar(int[,] matrix2, int perem1, int perem2, int n, int m, bool first, ref int[] smena1, ref int[] smena2,ref bool finish, int a, int b)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (finish)
                    return;
                if (i != perem1 & matrix2[i, perem2] != -1)
                {
                    int[] refreshsmena1 = new int[smena1.Length + 1];
                    int[] refreshsmena2 = new int[smena1.Length + 1];
                    for (int k = 0; k < refreshsmena1.Length - 1; k++)
                    {
                        refreshsmena1[k] = smena1[k];
                        refreshsmena2[k] = smena2[k];
                    }
                    refreshsmena1[refreshsmena1.Length - 1] = i;
                    refreshsmena2[refreshsmena2.Length - 1] = perem2;
                    smena1 = new int[refreshsmena1.Length];
                    smena2 = new int[refreshsmena2.Length];
                    for (int k = 0; k < refreshsmena1.Length; k++)
                    {
                        smena1[k] = refreshsmena1[k];
                        smena2[k] = refreshsmena2[k];
                    }
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (j != perem2 & matrix2[i, j] != -1 | i==a & j==b)
                        {
                            refreshsmena2 = new int[smena2.Length + 1];
                            refreshsmena1 = new int[smena1.Length + 1];
                            for (int k = 0; k < smena2.Length; k++)
                            {
                                refreshsmena1[k] = smena1[k];
                                refreshsmena2[k] = smena2[k];
                            }
                            refreshsmena1[refreshsmena1.Length - 1] = i;
                            refreshsmena2[refreshsmena2.Length - 1] = j;
                            smena1 = new int[refreshsmena1.Length];
                            smena2 = new int[refreshsmena2.Length];
                            for (int k = 0; k < refreshsmena2.Length; k++)
                            {
                                smena2[k] = refreshsmena2[k];
                                smena1[k] = refreshsmena1[k];
                            }
                            //smena2[smena2.Length - 1] = j;
                            if (smena1[smena1.Length - 1] == a & smena2[smena2.Length - 1] == b)
                                finish = true;
                            if (finish)
                                return;
                            caterpillar(matrix2, i, j, n, m, first, ref smena1, ref smena2,ref finish, a, b);
                            if (finish)
                                return;
                            j = smena2[smena2.Length - 1];
                            i = smena1[smena1.Length - 1];
                            refreshsmena2 = new int[smena2.Length - 1];
                            refreshsmena1 = new int[smena1.Length - 1];
                            for (int k = 0; k < refreshsmena2.Length; k++)
                            {
                                refreshsmena2[k] = smena2[k];
                                refreshsmena1[k] = smena1[k];
                            }
                            smena1 = new int[refreshsmena1.Length];
                            smena2 = new int[refreshsmena2.Length];
                            for (int k = 0; k < refreshsmena2.Length; k++)
                            {
                                smena1[k] = refreshsmena1[k];
                                smena2[k] = refreshsmena2[k];
                            }
                        }
                    }
                    if (finish)
                        return;
                    i = smena1[smena1.Length - 1];
                    refreshsmena1 = new int[smena1.Length - 1];
                    refreshsmena2 = new int[smena2.Length - 1];
                    for (int k = 0; k < refreshsmena1.Length; k++)
                    {
                        refreshsmena1[k] = smena1[k];
                        refreshsmena2[k] = smena2[k];
                    }
                    smena1 = new int[refreshsmena1.Length];
                    smena2 = new int[refreshsmena2.Length];
                    for (int k = 0; k < refreshsmena1.Length; k++)
                    {
                        smena1[k] = refreshsmena1[k];
                        smena2[k] = refreshsmena2[k];
                    }
                }
            }
        }
    }
}
