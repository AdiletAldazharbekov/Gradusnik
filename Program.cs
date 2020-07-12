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
            string stop;
            do
            {
                //Приветствие
                Greeting();
                // Ввод данных
                Input();


                Console.WriteLine("\n\nДля выхода нажмите на клавишу \"N\"" +
                    "\nДля продолжения нажмите на любую клавишу");
                stop = Console.ReadLine();
                Clear();
            } while (stop.ToUpper() != "N");

           
        }

        public static void Greeting()
        {
            Console.WriteLine("Здравствуйте, вас приветствует программа \"Градусник\"!"+
            "\nДля старта нажмите на любую клавишу.");
            Clear();
        }
        public static void Input()
        {
            double temperature;

            List<double> logbook = new List<double>();

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
                double.TryParse(input, out temperature);
                if (temperature == 0 || temperature <30 || temperature>41)
                    Console.WriteLine("Ошибка ввода,  данные должны быть в интервале от 30 до 41 градусов");
                else
                {
                    logbook.Add(temperature);//запись в список
                    i++;
                }
            }
            Clear();
            if (logbook.Count > 0)
            {
                Output(logbook);
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
            Console.WriteLine($"Средняя температура: {blok.Average(): 0.0}");
            Console.WriteLine($"Количество дней с минимальной температурой: {blok.Where(t => t == blok.Min()).Count()}");
            Console.WriteLine($"Количество дней с максимальной температурой: {blok.Where(t => t == blok.Max()).Count()}");
            Console.WriteLine($"Количество дней с нормальной температурой: {blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с высокой температурой: {blok.Where(t => t <= 38.3).Count()- blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с очень высокой температурой: {blok.Where(t => t > 38.3).Count()}");
            // Самые сильные скочки температуры

        }
    }
}
