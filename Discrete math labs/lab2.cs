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

            if (AntisymmetricCheck(BynaryMatrix))   // проверки антисимметричности вызовом метода
            {
                Console.WriteLine("\nБинарная матрица антисимметрична");
            }
            else
            {
                Console.WriteLine("\nБинарная матрица не антисимметрична");
            }

            if (TransitivityCheck(BynaryMatrix))    // проверка транзитивности вызовом метода
            {
                Console.WriteLine("\nБинарная матрица транзитивна");
            }
            else
            {
                Console.WriteLine("\nБинарная матрица антитранзитивна");
            }
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

            bool flag = false;  // булевая переменная-флаг для прерывания циклов, при соответсвии условий симметричности матрицы

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bynaryMatrix[i, j] == transposedMatrix[i, j])   // если элемент бинарной матрицы равен элементу транспонированной матрицы
                    {
                        flag = true;    // устанавливаем истинность
                        Console.WriteLine("\nБинарная матрица симметрична");
                        break;  // прерываем вложенный цикл
                    }
                }
                if (flag)   // поскольку флаг истинный, то прерываем основной цикл
                {
                    break;
                }
            }
        }

        public static bool AntisymmetricCheck(int[,] bynaryMatrix)
        {
            int rows = bynaryMatrix.GetLength(0);     // количество строк
            int cols = bynaryMatrix.GetLength(1);     // количество столбцов

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bynaryMatrix[i, j] == 1 && bynaryMatrix[j, i] == 1 && i != j)   // если элементы в главной диагонали равны 1
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool TransitivityCheck(int[,] binaryMatrix)
        {
            int n = binaryMatrix.GetLength(0);     // Получаем количество строк в матрице

            for (int i = 0; i < n; i++)            
            {
                for (int j = 0; j < n; j++)        
                {
                    if (binaryMatrix[i, j] == 1)  // Если элемент матрицы равен 1
                    {
                        for (int k = 0; k < n; k++)  // Для каждого элемента в строке j
                        {
                            // Проверяем, если в строке j есть элемент k такой, что для элементов (i, j) и (j, k) условие транзитивности не выполняется
                            if (binaryMatrix[j, k] == 1 && binaryMatrix[i, k] != 0)
                            {
                                return false;  // Возвращаем отрицание, так как нарушено условие транзитивности
                            }
                        }
                    }
                }
            }

            return true;  // Если ни для одной тройки (i, j, k) не нарушено условие транзитивности, возвращаем истинность
        }

    }
}
