using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string exit;
            do
            {
                Greeting();
                Input();
                exit = Ending();
            } while (exit.ToUpper() != "N");

        }
        public static void Greeting()
        {
            Console.WriteLine("Здравствуйте, вас приветствует программа \"Градусник\"!"+
            "\nДля старта нажмите на любую клавишу.");
            Console.ReadKey();
            Clear();
        }
        public static void Input()
        {
            double temperature;
            List<double> logbook = new List<double>();

            int i=1;
            while (true)
            {
                Console.WriteLine($"Введите вашу температуру \n{i} день:");
                var input = Console.ReadLine();
                if (input=="")
                {
                    Console.WriteLine("Для просмотра статистики нажмите на \"Enter\"" +
                        "\nДля того чтобы продолжить нажмите на любую клавишу");
                    if (Console.ReadLine() == "") break;
                }
                else
                {
                    var input1 = input.Replace(" ", "");
                    var input2 = input1.Replace(",", ".");

                    double.TryParse(input2, out temperature);
                    if (temperature == 0 || temperature < 30 || temperature > 41)
                        Console.WriteLine("Ошибка ввода, данные должны быть в интервале от 30 до 41 градусов");
                    else
                    {
                        logbook.Add(temperature);
                        i++;
                    }
                }               
            }

            if (logbook.Count > 0) Output(logbook);
                
        }
        public static void Clear()
        {
            Console.Clear();
        }
        
        public static void Output (List<double> blok)
        {
            Clear();
            Console.WriteLine($"Самая низкая температура: {blok.Min(): 0.0}");
            Console.WriteLine($"Самая высокая температура: {blok.Max(): 0.0}");
            Console.WriteLine($"Средняя температура: {blok.Average(): 0.0}");

            Console.WriteLine($"\nКоличество дней с минимальной температурой: {blok.Where(t => t == blok.Min()).Count()}");
            Console.WriteLine($"Количество дней с максимальной температурой: {blok.Where(t => t == blok.Max()).Count()}");
            
            // Самые сильные скочки (рост и спад)  температуры и в какой день это было 

            Console.WriteLine($"\nКоличество дней с нормальной температурой: {blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с высокой температурой: {blok.Where(t => t <= 38.3).Count()- blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с очень высокой температурой: {blok.Where(t => t > 38.3).Count()}");
        }

        public static void Osut()
        {
            string str = Console.ReadLine();
            var str1 = str.Replace(" ", "");
            var str2 = str1.Replace(",", ".");

           
            Console.WriteLine(str2);
            
        }

        private static string Ending()
        {
            Console.WriteLine("\n\nДля выхода нажмите на клавишу \"N\"" +
                    "\nНачать заново нажмите на любую клавишу");
            return Console.ReadLine();
        }
    }
}
