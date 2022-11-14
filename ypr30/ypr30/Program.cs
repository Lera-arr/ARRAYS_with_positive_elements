using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ypr30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10, m = 10;
            int i, j;
            string text = ""; //номера столбцов с положительными числаим 
            int[] Mas = new int[m];
            double[,] Matr1 = new double[n, m];
            double[,] Matr2 = new double[n, m];

            Random r = new Random();

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Matr1[i, j] = Convert.ToDouble(r.Next(-10, 40) / 10.0);//Заполняем матрицу 1
                    Matr2[i, j] = Convert.ToDouble(r.Next(-10, 40) / 10.0);//Заполняем матрицу 2
                }
            }

            //Вывод 1
            Console.WriteLine("Исходный массив 1");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write("{0,7}", Matr1[i, j]);
                }
                Console.WriteLine();
            }
            //Вывод 2
            Console.WriteLine("Исходный массив 2");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write("{0,7}", Matr2[i, j]);
                }
                Console.WriteLine();
            }
            // 1 Цикл
            Console.WriteLine("Вывод положительных чисел из массива 1");
            for (j = 0; j < n; j++) // какая сторка сколько содержит положительных чисел 
            {
                Mas[j] = kollPlus(Matr1, j, m);
                Console.Write("{0,7}", Mas[j]);
            }
            Console.WriteLine();
            //Запись в text номера столбцов с положительными числами
            for (j = 0; j < n; j++)
            {
                if (Mas[j] == 10)
                {
                    if (text != "")
                    {
                        text += ",";
                    }
                    text += (j + 1);
                }
            }
            if (text != "")
            {
                Console.WriteLine("Номера столбцов с положительными числами для массива 1: " + text);
            }
            else if (text == "")
            {
                Console.WriteLine("В массиве 1 нет положительных столбцов");
            }

            Mas = new int[m];//Обнуление данных из 1 массива
            text = "";   //ООбнуление данных из 1 массива

            Console.WriteLine("Вывод положительных чисел из массива 2");
            for (j = 0; j < n; j++) // какая сторка сколько содержит положительных чисел 
            {
                Mas[j] = kollPlus(Matr2, j, m); // kollPlus процедура подсчет положительных столбцов
                Console.Write("{0,7}", Mas[j]);
            }
            Console.WriteLine();
            //Запись в text номера столбцов с положительными числами
            for (j = 0; j < n; j++)
            {
                if (Mas[j] == 10)
                {
                    if (text != "")
                    {
                        text += ",";
                    }
                    text += (j + 1);
                }
            }
            if (text != "")
            {
                Console.WriteLine("Номера столбцов с положительными числами для массива 2: " + text);
            }
            else if (text == "")
            {
                Console.WriteLine("В массиве 2 нет положительных столбцов");
            }
            Console.ReadKey();
        }
        static int kollPlus(double[,] col, int j1, int m1)
        {
            int i1, kol = 0;
            for (i1 = 0; i1 < m1; i1++)
            {
                if (col[i1, j1] > 0)
                {
                    kol++;
                }
            }
            return kol;
        }
    }
}
