using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (logbook.Count > 0) Diagram(logbook);


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

            double maxRise = 0;
            double maxDrop = 0;
            int maxRiseDay = 0;
            int maxDropDay = 0;
            double difference = 0;
            for (int i = 0; i < blok.Count(); i++)
            {
                if (i!=0)
                {
                    var d1 = blok[i];
                    var d2 = blok[i-1];
                    difference = d1 - d2;
                }
                
                if (difference>maxRise)
                {
                    maxRise = difference;
                    maxRiseDay = i+1;
                }
                else if (difference < maxDrop)
                {
                    maxDrop = difference;
                    maxDropDay = i+1;
                }
            }
            Console.WriteLine($"\nМаксимальный рост температуры составил {maxRise: 0.0} градусов, который был зафиксирован в {maxRiseDay}-день");

            Console.WriteLine($"Максимальный спад температуры составил {maxDrop*-1: 0.0} градусов, который был зафиксирован в {maxDropDay}-день");

            Console.WriteLine($"\nКоличество дней с нормальной температурой: {blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с высокой температурой: {blok.Where(t => t <= 38.3).Count()- blok.Where(t => t <= 37.5).Count()}");
            Console.WriteLine($"Количество дней с очень высокой температурой: {blok.Where(t => t > 38.3).Count()}");
        }

        

        private static string Ending()
        {
            Console.WriteLine("\n\nДля выхода нажмите на клавишу \"N\"" +
                    "\nНачать заново нажмите на любую клавишу");
            return Console.ReadLine();
        }
        public static void Diagram(List<double> blok)
        {
            int maxT = 41;
            int t = Console.CursorTop + 11;
            for (int i = Console.CursorTop; i <= t; i++)
            {
                if (maxT>38.3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (maxT > 37.5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"{maxT:0.0}");

                for (int j = 0; j < blok.Count(); j++)
                {
                    if (Convert.ToInt32(blok[j]) == maxT)
                    {
                        Console.SetCursorPosition(j+5, i);
                        Console.Write("*");
                    }

                }
                maxT -=1;
                Console.Write("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
