using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discrete_math_labs
{
    class Correspondence
    {
        public int ValueFrom { get; } // Определение свойства для значения, откуда происходит соответствие
        public int ValueTo { get; }   // Определение свойства для значения, куда происходит соответствие

        public Correspondence(int from, int to) // Конструктор для создания нового экземпляра соответствия
        {
            ValueFrom = from; // Присваивание значения "откуда"
            ValueTo = to;     // Присваивание значения "куда"
        }
    }

    class lab6
    {
        public static List<Correspondence> f = new List<Correspondence> // Список соответствий f
        {
            new Correspondence(2, 3), // Соответствие: 2 -> 3
            new Correspondence(3, 4), // Соответствие: 3 -> 4
            new Correspondence(5, 9), // Соответствие: 5 -> 9
            new Correspondence(8, 9)  // Соответствие: 8 -> 9
        };

        public static List<Correspondence> g = new List<Correspondence> // Список соответствий g
        {
            new Correspondence(3, 9), // Соответствие: 3 -> 9
            new Correspondence(4, 6), // Соответствие: 4 -> 6
            new Correspondence(5, 4), // Соответствие: 5 -> 4
            new Correspondence(7, 8), // Соответствие: 7 -> 8
            new Correspondence(9, 5)  // Соответствие: 9 -> 5
        };

        public static void Main(string[] args)
        {
            // Вывод результатов
            Console.WriteLine("\nВиды соответствия:");

            if (IsEverywhereDefined(f, g)) // Проверка на всюду определенное соответствие для f и g
            {
                Console.WriteLine("Соответствие f всюду определенное");
            }
            else
            {
                Console.WriteLine("Соответствие f частично определенное");
            }

            Console.WriteLine();

            if (IsFunctional(f)) // Проверка на функциональное соответствие для f
            {
                Console.WriteLine("Соответствие f функционально");
            }
            else
            {
                Console.WriteLine("Соответствие f не функционально");
            }

            Console.WriteLine();

            if (IsSurjective(f)) // Проверка на сюръективное соответствие для f
            {
                Console.WriteLine("Соответствие f сюръективно");
            }
            else
            {
                Console.WriteLine("Соответствие f не сюръективно");
            }

            Console.WriteLine();

            if (IsInjective(f)) // Проверка на инъективное соответствие для f
            {
                Console.WriteLine("Соответствие f инъективно");
            }
            else
            {
                Console.WriteLine("Соответствие f не инъективно");
            }

            Console.WriteLine();

            if (IsSurjective(f) && IsInjective(f)) // Проверка на биективное соответствие для f
            {
                Console.WriteLine("Соответствие f биективно");
            }
            else
            {
                Console.WriteLine("Соответствие f не биективно");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            if (IsEverywhereDefined(g, f)) // Проверка на всюду определенное соответствие для g и f
            {
                Console.WriteLine("Соответствие g всюду определенное");
            }
            else
            {
                Console.WriteLine("Соответствие g частично определенное");
            }

            Console.WriteLine();

            if (IsFunctional(g)) // Проверка на функциональное соответствие для g
            {
                Console.WriteLine("Соответствие g функционально");
            }
            else
            {
                Console.WriteLine("Соответствие g не функционально");
            }

            Console.WriteLine();

            if (IsSurjective(g)) // Проверка на сюръективное соответствие для g
            {
                Console.WriteLine("Соответствие g сюръективно");
            }
            else
            {
                Console.WriteLine("Соответствие g не сюръективно");
            }

            Console.WriteLine();

            if (IsInjective(g)) // Проверка на инъективное соответствие для g
            {
                Console.WriteLine("Соответствие g инъективно");
            }
            else
            {
                Console.WriteLine("Соответствие g не инъективно");
            }

            Console.WriteLine();

            if (IsSurjective(g) && IsInjective(g)) // Проверка на биективное соответствие для g
            {
                Console.WriteLine("Соответствие g биективно");
            }
            else
            {
                Console.WriteLine("Соответствие g не биективно");
            }

        }

        static int FindImage(int x, List<Correspondence> correspondence) // Поиск образа для элемента x в соответствии
        {
            foreach (var pair in correspondence)
            {
                if (pair.ValueFrom == x)
                    return pair.ValueTo; // Возвращает образ, если нашелся
            }
            return -1; // Если образ не найден
        }

        // Проверка на всюду определенное соответствие
        static bool IsEverywhereDefined(List<Correspondence> f, List<Correspondence> g)
        {
            // Проверяем, что для каждого элемента из U определены оба соответствия
            for (int i = 0; i < 10; i++)
            {
                if (FindImage(i, f) == -1 || FindImage(i, g) == -1)
                    return false;
            }
            return true;
        }

        // Проверка на функциональное соответствие
        static bool IsFunctional(List<Correspondence> f)
        {
            // Проверяем, что для каждого элемента из U определен только один образ
            HashSet<int> valuesFrom = new HashSet<int>();
            foreach (var pair in f)
            {
                if (!valuesFrom.Add(pair.ValueFrom))
                    return false; // Найдено несколько образов для одного элемента
            }
            return true;
        }

        // Проверка на сюръективное соответствие
        static bool IsSurjective(List<Correspondence> g)
        {
            // Проверяем, что образы покрывают всё множество Y
            HashSet<int> valuesTo = new HashSet<int>();
            foreach (var pair in g)
            {
                valuesTo.Add(pair.ValueTo);
            }
            return valuesTo.Count == 10; // Проверяем, что образы покрывают все элементы из U
        }

        // Проверка на инъективное соответствие
        static bool IsInjective(List<Correspondence> f)
        {
            // Проверяем, что для каждого элемента из Y определен только один прообраз
            HashSet<int> valuesTo = new HashSet<int>();
            foreach (var pair in f)
            {
                if (!valuesTo.Add(pair.ValueTo))
                    return false; // Найдено несколько прообразов для одного элемента
            }
            return true;
        }
    }
}
