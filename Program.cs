using System;
using System.Linq;

namespace pr16_KM
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            int count = 0;
            
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
                    
                    Console.WriteLine(Num(elements, ref count));
                    Console.WriteLine($"Количество цифр: {count}");
                    Console.WriteLine($"Элементы до первого '/':\n{BeforeSlash(elements)}");
                    Console.WriteLine($"Элементы после '/'::\n{AfterSlash(elements)}");
                    
                    text = $"Строка: {s}\nКоличество цифр:{count}\n{Num(elements, ref count)}\nЭлементы до первого '/':\n{BeforeSlash(elements)}\nЭлементы после '/'::\n{AfterSlash(elements)}";
                    
                    string filePath = "Result.txt";
                    File.WriteAllText(filePath, text);
                }
                else
                {
                    Console.WriteLine("В строке нет символа /");
                }
            }
        }

        static string Num(string[] s, ref int count) // определение цифр
        {
            var text = "";
        
            var num = s.SelectMany(s => s.Where(c => Char.IsDigit(c))).ToArray();
        
            count = num.Count();
        
            foreach (var n in num)
            {
                text += $"{n} ";
            }
            return text;
        }
        static string BeforeSlash(string[] s) // вывод до слэша
        {
            string text = "";
        
            text = s[0];
        
            if (text != string.Empty)
            {
                return text;
            }
            else
            {
                return "Нет элементов";
            }
        }
        static string AfterSlash(string[] s) // вывод после слэша
        {
            if (s.Length <= 1)
                return "";
        
            string text = "";
        
            for (int i = 1; i < s.Length; i++)
            {
                string transform = new string (s[i].Select(c => char.IsUpper(c) ?
                char.ToLower(c) : char.IsLower(c) ? char.ToUpper(c) : c).ToArray());
        
                text += transform;
            }
        
            return text;
        }
    }
}
