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
            var multiplicity_U = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };     // универсальное множество U

            var multiplicity_A = new HashSet<string> { "1", "5", "6", "8" };    // множество А

            var multiplicity_B = new HashSet<string> { "3", "6", "9", "10" };   // множество B

            var union_multiplicity = new HashSet<string>(multiplicity_A);   // буфер множества A для объединения множеств

            union_multiplicity.UnionWith(multiplicity_B);   // объединяем множество А с множеством В и записываем в отдельную переменную

            Console.Write("Объединенные множества А и В: ");

            foreach (var element in union_multiplicity)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine('\n');

            var buffer_A = new HashSet<string>(multiplicity_A);    // буфер множества А для поиска пересечений с множеством В

            var same = buffer_A.Intersect(multiplicity_B);  // поиск пересечений множества А с множеством В

            Console.Write("Пересечение множеств А и В: ");

            foreach (var element in same)
            {
                Console.Write($"{element} ");
            }

            var difference_A_buffer = new HashSet<string>(multiplicity_A);  // буфер множества А для вычисления разницы между множествами

            var difference_B_buffer = new HashSet<string>(multiplicity_B);  // буфер множества В для вычисления разницы между множествами

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

            var symmetrical_difference = new HashSet<string>(difference_A_B.Union(difference_B_A)); // симметрическая разница множеств А и В

            Console.WriteLine('\n');

            Console.Write("Симметрическая разность A и B: ");

            foreach (var element in symmetrical_difference)
            {
                Console.Write($"{element} ");
            }

            // дополненное множество А

            var supplement_buffer_first = new HashSet<string>(multiplicity_U);  // первый буфер универсального множества U

            var supplement_multiplicity_A = new HashSet<string>();  // пустое множество для дополнения множества А

            // дополненное множество В

            var supplement_buffer_second = new HashSet<string>(multiplicity_U); // второй буфер универсального множества U

            var supplement_multiplicity_B = new HashSet<string>();    // пустое множество для дополнения множества В

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
