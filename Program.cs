using System;
using System.Linq;

namespace pr16_KM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите строку {i + 1}");
                arr[i] = Console.ReadLine();
            }

            Console.WriteLine();

            foreach (var s in arr)
            {
                if (s.Contains('/'))
                {
                    Console.WriteLine($"Строка: {s}");

                    string[] elements = s.Split('/');

                    Num(elements);
                    BeforeSlash(elements);
                    AfterSlash(elements);
                }
                else
                {
                    Console.WriteLine("В строке нет символа /");
                }
            }
        }

        static void Num(string[] s) // определение цифр
        {
            var text = "";
            
            var num = s.SelectMany(s => s.Where(c => Char.IsDigit(c))).ToArray();

            Console.WriteLine($"Количество чисел: {num.Count()}");
            foreach (var n in num)
            {
                text += $"{n} ";
            }
            Console.WriteLine(text);
        }
        static void BeforeSlash(string[] s) // вывод до слэша
        {
            string text = "";

            Console.WriteLine("Элементы до первого '/':");

            text = s[0];

            if (text != string.Empty)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Нет элементов");
            }
        }
        static void AfterSlash(string[] s) // вывод после слэша
        {
            Console.WriteLine("Элементы после '/':");

            for (int i = 1; i < s.Length; i++)
            {
                Console.WriteLine(s[i].Select(c => char.IsUpper(c) ?
                char.ToLower(c) : char.IsLower(c) ? char.ToUpper(c) : c).ToArray());
            }
        }
    }
}
