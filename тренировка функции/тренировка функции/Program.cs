using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace тренировка_функции
{
    internal class Program
    {
        static double CalcLen(double x1,  double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        static double CalcSquare(double a, double b, double c)
        {
            double p = (a+b+c)/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static bool IsExist(double a, double b, double c)
        {
            return ((a + b > c) && (a + c > b) && (b + c > a));
        }
        static double InputDoubleNumber(string msg)
        {
            Console.WriteLine(msg);
            bool isConvert;
            double number;
            do
            {
                isConvert = double.TryParse(Console.ReadLine(), out number);
                if (!isConvert) Console.WriteLine("Неправильное число");
            }while(!isConvert);
            return number;
        }
        static void MakePoint(int num, out double x, out double y)
        {
            Console.WriteLine($"Введите координаты {num} точки");
            x = InputDoubleNumber($"Введите координату x{num}");
            y = InputDoubleNumber($"Введите координату y{num}");
        }
        static void Main(string[] args)
        {
            double x1, y1, x2, y2, x3, y3;
            MakePoint(1, out x1, out y1);
            MakePoint(2, out x2, out y2);
            MakePoint(3, out x3, out y3);
            double l1 = CalcLen(x1, y1, x2, y2);
            double l2 = CalcLen(x1, y1, x3, y3);
            double l3 = CalcLen(x3, y3, x2, y2);
            if (IsExist(l1, l2, l3))
            {
                double sq = CalcSquare(l1, l2, l3);
                Console.WriteLine($"Площадь треугольника {sq}");
            }
            else Console.WriteLine("Треугольника не существует");
        }
    }
}
