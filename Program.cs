using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tЗдравствуйте, вас приветствует программа \"Градусник\"!");
            Console.WriteLine("\n\tДля старта нажмите на любую клавишу");
            Clear();
            // Ввод данных
            string n;
            do
            {
                Input();
                Console.WriteLine("\n\nДля выхода нажмите на клавишу \"N\"" +
                    "\nДля продолжения нажмите на любую клавишу");
                n = Console.ReadLine();
                Clear();
            } while (n.ToUpper() != "N");

           
        }

        public static void Input()
        {
            double temperatura;
            List<double> bloknot = new List<double>();

            int i=1;
            while (true)
            {
                Console.Write($"\nВведите вашу температуру \n{i} день: ");
                var input = Console.ReadLine();
                if (input=="")
                {
                    Console.WriteLine("Конец ввода, Нажмите на любую клавишу");
                    break;
                }
                double.TryParse(input, out temperatura);
                if (temperatura == 0 || temperatura <30 || temperatura>41)
                    Console.WriteLine("Ошибка ввода,  данные должны быть в интервале от 30 до 41 градусов");
                else
                {
                    bloknot.Add(temperatura);//запись в список
                    i++;
                }
            }
            Clear();
            if (bloknot.Count > 0)
            {
                Output(bloknot);
            }
           
                
        }
        public static void Clear()
        {
            Console.ReadKey();
            Console.Clear();
        }
        public static void Output (List<double> blok)
        {
            Console.WriteLine($"Самая низкая температура: {blok.Min(): 0.0}");
            Console.WriteLine($"Самая высокая температура: {blok.Max(): 0.0}");
            Console.WriteLine($"Средняя температура: {blok.Sum()/blok.Count(): 0.0}");
            Console.WriteLine($"Количество дней с минимальной температурой: {blok.Where(t => t == blok.Min()).Count()}");
            Console.WriteLine($"Количество дней с максимальной температурой: {blok.Where(t => t == blok.Max()).Count()}");
            Console.WriteLine($"Количество дней с номальной температурой: {blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с высокой температурой: {blok.Where(t => t <= 38.3).Count()- blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с очень высокой температурой: {blok.Where(t => t > 38.3).Count()}");
        }
    }
}
