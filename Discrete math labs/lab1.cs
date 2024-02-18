using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discrete_math_labs 
{
    class lab1
    {
        static void Main(string[] args)
        {
            var multiplicity_U = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            var multiplicity_A = new HashSet<string> { "1", "5", "6", "8" };    // множество А
            var multiplicity_B = new HashSet<string> { "3", "6", "9", "10" };   // множество B

            var union_multiplicity = new HashSet<string>(multiplicity_A);   // записываем множество A

            union_multiplicity.UnionWith(multiplicity_B);   // объединяем множество А с множеством В и записываем в отдельную переменную

            Console.Write("Объединенные множества А и В: ");

            foreach (var element in union_multiplicity)
            {
                Console.Write($"{element} ");   // выводим
            }

            Console.WriteLine('\n');

            var buffer_A = new HashSet<string> (multiplicity_A);    // ищем одинаковые элементы в множествах

            var same = buffer_A.Intersect(multiplicity_B);

            Console.Write("Пересечение множеств А и В: ");

            foreach (var element in same)
            {
                Console.Write($"{element} ");
            }

            var difference_A_buffer = new HashSet<string>(multiplicity_A);

            var difference_B_buffer = new HashSet<string>(multiplicity_B);

            var difference_A_B = difference_A_buffer.Except(multiplicity_B);    // разность множества А и В

            var difference_B_A = difference_B_buffer.Except(multiplicity_A);    // разность множества В и А

            Console.WriteLine('\n');

            Console.Write("Разность множеств А и В: ");

            foreach (var element in difference_A_B)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine('\n');

            Console.Write("Разность множеств B и A: ");

            foreach (var element in difference_B_A)
            {
                Console.Write($"{element} ");
            }

            var symmetrical_difference = new HashSet<string>(difference_A_B.Union(difference_B_A));

            Console.WriteLine('\n');

            Console.Write("Симметрическая разность A и B: ");

            foreach (var element in symmetrical_difference)
            {
                Console.Write($"{element} ");
            }

            // дополненное множество А
            var supplement_multiplicity_A = new HashSet<string>();  

            supplement_multiplicity_A.Add("2");
            supplement_multiplicity_A.Add("3");
            supplement_multiplicity_A.Add("4");
            supplement_multiplicity_A.Add("7");
            supplement_multiplicity_A.Add("9");
            supplement_multiplicity_A.Add("10");

            // дополненное множество В
            var supplement_multiplicity_B = new HashSet<string>();

            supplement_multiplicity_B.Add("1");
            supplement_multiplicity_B.Add("2");
            supplement_multiplicity_B.Add("4");
            supplement_multiplicity_B.Add("5");
            supplement_multiplicity_B.Add("7");
            supplement_multiplicity_B.Add("8");

            Console.WriteLine('\n');

            Console.Write("Дополненное множество А: ");

            foreach (var element in supplement_multiplicity_A)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine('\n');

            Console.Write("Дополненное множество B: ");

            foreach (var element in supplement_multiplicity_B)
            {
                Console.Write($"{element} ");
            }
        }
    }
}