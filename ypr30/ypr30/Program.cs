using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ypr30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10, m = 10;
            int i, j;           
            int[] Mas = new int[m];// массив с количеством положительных чисел в массиве 1 или 2 
            double[,] Matr1 = new double[n, m]; //массив 1
            double[,] Matr2 = new double[n, m]; //массив 2

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
            WriteText(Mas, n, 1); // вызов процедуры вывод положительных столбцов из массива 1

            Mas = new int[m];//Обнуление данных из 1 массива
            Console.WriteLine("Вывод положительных чисел из массива 2");
            for (j = 0; j < n; j++) // какая сторка сколько содержит положительных чисел 
            {
                Mas[j] = kollPlus(Matr2, j, m); // kollPlus процедура подсчет положительных столбцов
                Console.Write("{0,7}", Mas[j]);
            }
            Console.WriteLine();
            
            //Запись в text номера столбцов с положительными числами
            WriteText(Mas,n,2); // вызов процедуры вывод положительных столбцов из массива 2

            Console.ReadKey();
        }
        static int kollPlus(double[,] col, int j1, int m1) // процедура подсчет положительных столбцов (col=Matr1; j1=j, m1=m)
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
        static void WriteText(int[] Mas, int n, int num)
        {
            int j;
            string text = ""; //номера столбцов с положительными числаим 
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
                Console.WriteLine("Номера столбцов с положительными числами для массива " + num + ": " + text);
            }
            else if (text == "")
            {
                Console.WriteLine("В массиве " + num + " нет положительных столбцов");
            }
        }
    }

}
