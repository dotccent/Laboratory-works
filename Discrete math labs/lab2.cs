using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Discrete_math_labs
{
    class lab2
    {
        public static void Main(string[] args)
        {
            int[,] BynaryMatrix = new int[5, 5] { { 1, 1, 0, 0, 1 },   // бинарная матрица P
                                                   { 1, 1, 0, 0, 0 }, 
                                                   { 0, 0, 1, 0, 0 }, 
                                                   { 0, 0, 0, 1, 0 }, 
                                                   { 1, 0, 0, 0, 0 } };

            ReflexivityCheck(BynaryMatrix);    // проверка рефлексивности матрицы вызовом метода

            int[,] TransposedMatrix = Transpose(BynaryMatrix);     // получаем транспонированную матрицу вызовом метода

            SymmetryCheck(bynaryMatrix: BynaryMatrix, transposedMatrix: TransposedMatrix);  // проверка симметричности вызовом метода

            AntisymmetricCheck(BynaryMatrix);   // проверки антисимметричности вызовом метода

            TransitivityCheck(BynaryMatrix);
        }

        public static void ReflexivityCheck(int[,] bynaryMatrix)   // метод проверки рефлексивности бинарной матрицы
        {
            int rows = bynaryMatrix.GetLength(0);     // количество строк

            int counter = 0;    // счетчик для подсчета случаев рефлексивности

            for (int i = 0; i < rows; i++)
            {
                if (bynaryMatrix[i, i] == 0)   // если главная диагональ содержит ноль
                {
                    Console.WriteLine("Бинарная матрица является антирефлексивной");    // выводим сообщение о антирефлексивности
                }
                else    // в ином случае...
                {
                    if (bynaryMatrix[i, i] == 1)   // если главная диагональ содержит единицу
                    {
                        counter++;  // увеличиваем счетчик на единицу
                    }
                }
            }

            if (counter == 5)   // если счетчик равен исходному количеству элементов в главной диагонали
            {
                Console.WriteLine("Бинарная матрица является рефлексивной");    // выводим сообщение о рефлексивности
            }
        }

        public static int[,] Transpose(int[,] bynaryMatrix)   // метод для транспонирования бинарной матрицы
        {
            int rows = bynaryMatrix.GetLength(0);     // количество строк
            int cols = bynaryMatrix.GetLength(1);     // количество столбцов

            int[,] transposedMatrix = new int[rows, cols];  // пустая транспонированная матрица

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedMatrix[j, i] = bynaryMatrix[i, j];  // запись в транспонированную матрицу элементов бинарной матрицы в обратном порядке
                }
            }

            return transposedMatrix;    // возвращаем полученную матрицу
        }

        public static void SymmetryCheck(int[,] bynaryMatrix, int[,] transposedMatrix)  // метод проверки на симметричность или антисимметричность
        {
            int rows = bynaryMatrix.GetLength(0);     // количество строк
            int cols = bynaryMatrix.GetLength(1);     // количество столбцов

            bool flag = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bynaryMatrix[i,j] == transposedMatrix[i,j])
                    {
                        flag = true;
                        Console.WriteLine("Бинарная матрица симметрична");
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        public static void AntisymmetricCheck(int[,] bynaryMatrix)
        {
            int rows = bynaryMatrix.GetLength(0);     // количество строк
            int cols = bynaryMatrix.GetLength(1);     // количество столбцов

            bool flag = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bynaryMatrix[i, j] == 1 && bynaryMatrix[j, i] == 1 && i != j)
                    {
                        flag = true; 
                        Console.WriteLine("Бинарная матрица антисимметрична");
                        break;
                    }
                    else
                    {
                        flag = true;
                        Console.WriteLine("Бинарная матрица не антисимметрична");
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        public static void TransitivityCheck(int[,] bynaryMatrix)
        {
            int n = bynaryMatrix.GetLength(0);     // количество строк

            bool flag = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (bynaryMatrix[i, j] == 1)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (bynaryMatrix[j, k] == 1 && bynaryMatrix[i, k] != 1)
                            {
                                flag = true;
                                Console.WriteLine("Матрица не транзитивна");
                                break;
                            }
                            else
                            {
                                flag = true;
                                Console.WriteLine("Матрица транзитивна");
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }
    }
}