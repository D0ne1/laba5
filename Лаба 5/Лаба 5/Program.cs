using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Лаба_5
{
    internal class Program
    {
        static int InputIntNumber() // проверка на целое число
        {
            bool isCorrert;
            int number;
            do
            {
                isCorrert = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrert) Console.WriteLine("Пожалуйста, введите целое число");
            } while (!isCorrert);
            return number;
        }
        static void CreateMassRnd(ref int[] mass) //создание одномерного массива с помощью ДСЧ
        {
            int length = 0;
            do
            {
                Console.WriteLine("Введите длину массива");
                length = InputIntNumber();
            } while (length < 0);
            Random rnd = new Random();
            mass = new int[length];
            for (int i = 0; i < length; i++)
            {
                mass[i] = rnd.Next(-10, 10);
            }      
            Console.WriteLine("Массив сформирован");
        }
        static void CreateMatrRnd(ref int[,]matr) //создание двумерного массива с помощью ДСЧ
        {
            int str = 0;
            int col = 0;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = InputIntNumber();
            }while (str < 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = InputIntNumber();
            } while (col < 0);
            matr = new int[str, col];
            Random rnd = new Random();
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matr[i, j] = rnd.Next(-10, 10);
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void CreateRmassRnd(ref int[][]rmass)// создание рваного массива при помощи ДСЧ
        {
            Random rnd = new Random();
            int str = 0;
            do
            {
                Console.WriteLine("Введите количество строк рваного массива");
                str = InputIntNumber();
            } while (str < 0);
            rmass = new int[str][];
            for (int i = 0; i < str; i++)
            {
                int col = 0;
                do
                {
                    Console.WriteLine($"Введите количество элементов в строке {i + 1}");
                    col = InputIntNumber();
                }while( col < 0);
                rmass[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    rmass[i][j] = rnd.Next(-10, 10);
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void CreateMass(ref int[] mass) //создание одномерного массива вручную
        {
            int length = 0;
            do
            {
                Console.WriteLine("Введите длину массива");
                length = InputIntNumber();
            } while (length < 0);
            mass = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите элемент массива под номером: {i+1}");
                mass[i] = InputIntNumber();
            }
            Console.WriteLine("Массив сформирован");
        }
        static void CreateMatr(ref int[,] matr) //создание двумерного массива вручную
        {
            int str = 0;
            int col = 0;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = InputIntNumber();
            } while (str < 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = InputIntNumber();
            } while (col < 0);
            matr = new int[str, col];
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine($"Введите элемент массива под номером: ({i+1}; {j+1})");
                    matr[i, j] = InputIntNumber();
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void CreateRmass(ref int[][] rmass)// создание рваного массива вручную
        {
            int str = 0;
            do
            {
                Console.WriteLine("Введите количество строк рваного массива");
                str = InputIntNumber();
            } while(str < 0);
            rmass = new int[str][];
            for (int i = 0; i < str; i++)
            {
                int col = 0;
                do
                {
                    Console.WriteLine($"Введите количество элементов в строке {i + 1}");
                    col = InputIntNumber();
                } while (col < 0);
                rmass[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine($"Введите {j+1}ый/ой элемент {i+1}ой/ей строки:");
                    rmass[i][j] = InputIntNumber();
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void PrintMass(int[] mass) // печать одномерного массива 
        {
            if (IsEmptyMass(mass)) Console.WriteLine("Массив пуст");
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < mass.Length; i++)
                {
                    Console.Write($"{mass[i]} ");
                }
            }
            Console.WriteLine();
        }
        static void PrintMatr(int[,] matr) // печать двумерного массива
        {
            if (IsEmptyMatr(matr)) Console.WriteLine("Массив пуст");
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write(matr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void PrintRmass(int[][] rmass) //печать рваного массива
        {
            if (IsEmptyRmass(rmass)) Console.WriteLine("Рваный массив пуст");
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0;i < rmass.GetLength(0); i++)
                {
                    for (int j = 0; j < rmass[i].GetLength(0); j++)
                    {
                        Console.Write(rmass[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static bool IsEmptyMass(int[] mass) // проверка длины одномерного массива 
        {
            if (mass == null || mass.Length == 0) return true;
            else return false;
        }
        static bool IsEmptyMatr(int[,] matr) // проверка длины двумерного массива 
        {
            if (matr == null || matr.Length == 0) return true;
            else return false;
        }
        static bool IsEmptyRmass(int[][] rmass) //проверка длины рваного массива
        {
            if (rmass == null || rmass.Length == 0) return true;
            else return false;
        }
        static void DeleteFirstNegativeElement(ref int[] mass) // удаление первого отрицательного элемента в одномерном массиве (1 задание)
        {
            if (IsEmptyMass(mass))
            {
                Console.WriteLine("Массив пуст");
            }
            else
            {
                int j = 0; //индекс минимального элемента
                int l = 0; //счётчик в temp
                int min = 0; //значение минимума
                int[] temp = new int[mass.Length - 1];
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] < 0)
                    {
                        min = mass[i];
                        break;
                    }
                    else Console.WriteLine("Отрицательного элемента в массиве нет");
                }
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] == min)
                    {
                        j = i; break;
                    }
                }
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i != j)
                    {
                        temp[l] = mass[i];
                        l++;
                    }
                }
                mass = temp;
                Console.WriteLine("Первый отрицательный элемент удалён");
            }
        }
        static int[,] AddColZero(int[,] matr) //добавление столбца с заданным номером к двумерному массиву (пустой столбец)
        {
            if (IsEmptyMatr(matr))
            {
                Console.WriteLine("Двумерный массив пуст");
            }
            else
            {
                Console.WriteLine("Укажите номер столбца, который нужно добавить");
                int number = 0;
                do
                {
                    number = InputIntNumber() - 1;
                    if (number < 0 || number > matr.GetLength(1) - 1)
                    {
                        Console.WriteLine($"Номер столбца должен начинаться с 1, но не должен быть больше, чем {matr.GetLength(1)}");
                    }
                } while (number < 0 || number > matr.GetLength(1) - 1);
                int[,] temp = new int[matr.GetLength(0), matr.GetLength(1) + 1]; // вспомогательный двумерный массив
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < temp.GetLength(1); j++)
                    {
                        if (j > number)
                        {
                            temp[i, j] = matr[i, j - 1];
                        }
                        else if (j == number)
                        {
                            temp[i, j] = 0;
                        }
                        else temp[i, j] = matr[i, j];
                    }
                }
                matr = temp;
                Console.WriteLine("Столбец добавлен");
            }
            return matr;
        }
        static int[,] AddCol(int[,] matr) //добавление столбца с заданным номером к двумерному массиву (каждый элемент вводит пользователь)
        {
            if (IsEmptyMatr(matr))
            {
                Console.WriteLine("Двумерный массив пуст");
            }
            else
            {
                Console.WriteLine("Укажите номер столбца, который нужно добавить");
                int number = 0;
                do
                {
                    number = InputIntNumber() - 1;
                    if (number < 0 || number > matr.GetLength(1) - 1)
                    {
                        Console.WriteLine($"Номер столбца должен начинаться с 1, но не должен быть больше, чем {matr.GetLength(1)}");
                    }
                } while (number < 0 || number > matr.GetLength(1) - 1);
                int[,] temp = new int[matr.GetLength(0), matr.GetLength(1)+1]; // вспомогательный двумерный массив
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        if (j > number)
                        {
                            temp[i, j] = matr[i, j - 1];
                        }
                        else if (j == number)
                        {
                            Console.WriteLine($"Введите {i+1}ый/ой элемент {j+1}го столбца");
                            temp[i, j] = InputIntNumber();
                        }
                        else temp[i, j] = matr[i, j];
                    }
                }
                matr = temp;
                Console.WriteLine("Столбец добавлен");
            }
            return matr;
        }
        static int[,] AddColRnd(int[,] matr) //добавление столбца с заданным номером к двумерному массиву (каждый элемент генерируется случайно)
        {
            if (IsEmptyMatr(matr))
            {
                Console.WriteLine("Двумерный массив пуст");
            }
            else
            {
                Random rnd = new Random();
                Console.WriteLine("Укажите номер столбца, который нужно добавить");
                int number = 0;
                do
                {
                    number = InputIntNumber() - 1;
                    if (number < 0 || number > matr.GetLength(1) - 1)
                    {
                        Console.WriteLine($"Номер столбца должен начинаться с 1, но не должен быть больше, чем {matr.GetLength(1)}");
                    }
                } while (number < 0 || number > matr.GetLength(1) - 1);
                int[,] temp = new int[matr.GetLength(0), matr.GetLength(1) + 1]; // вспомогательный двумерный массив
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < temp.GetLength(1); j++)
                    {
                        if (j > number)
                        {
                            temp[i, j] = matr[i, j - 1];
                        }
                        else if (j == number)
                        {
                            temp[i, j] = rnd.Next(-10, 10);
                        }
                        else temp[i, j] = matr[i, j];
                    }
                }
                matr = temp;
                Console.WriteLine("Столбец добавлен");
            }
            return matr;
        }
        static void DeleteShortLine(ref int[][] rmass) // удаление самой короткой строки рваного массива 
        {
            if (IsEmptyRmass(rmass)) Console.WriteLine("Рваный массив пуст");
            else
            {
                int min = 100000; //перменная для поиска короткой строки
                int index = 0; //номер короткой строки
                int[][] temp = new int[rmass.GetLength(0)-1][]; //вспомогательный массив
                for (int i = 0; i < rmass.GetLength(0); i++)
                {
                    if (rmass[i].Length < min)
                    {
                        min = rmass[i].Length;
                        index = i;
                    }
                }
                for (int i = 0; i < rmass.GetLength(0); i++)
                {
                    if (i < index)
                    {
                        temp[i] = rmass[i];
                    }
                    else if (i > index)
                    {
                        temp[i-1] = rmass[i];
                    }
                }
                rmass = temp;
                Console.WriteLine("Самая короткая строчка рваного массива удалена");
            }
        }
        static void Main(string[] args)
        {
            int ans = 0;
            do
            {
                Console.WriteLine("Выберите корректный пункт");
                Console.WriteLine("1) Работа над одномерным массивом");
                Console.WriteLine("2) Работа над двумерным массивом");
                Console.WriteLine("3) Работа над рваным массивом");
                Console.WriteLine("4) Выход");
                ans = InputIntNumber();
                switch (ans)
                {
                    case 1:
                        {
                            int[] mass = new int[0];
                            do 
                            { 
                                Console.WriteLine("Выберите корректный пункт");
                                Console.WriteLine("1) Создать одномерный массив при помощи ДСЧ");
                                Console.WriteLine("2) Создать одномерный массив вручную");
                                Console.WriteLine("3) Печать одномерного массива");
                                Console.WriteLine("4) Удаление первого отрицательного элемента в одномерном массиве");
                                Console.WriteLine("5) Назад");
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            CreateMassRnd(ref mass);
                                            break;
                                        }
                                    case 2:
                                        {
                                            CreateMass(ref mass);
                                            break;
                                        }
                                    case 3:
                                        {
                                            PrintMass(mass); 
                                            break;
                                        }
                                    case 4:
                                        {
                                            DeleteFirstNegativeElement(ref mass);
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 2:
                        {
                            int[,] matr = new int[0, 0];
                            do
                            { 
                                Console.WriteLine("Выберите корректный пункт");
                                Console.WriteLine("1) Создать двумерный массив при помощи ДСЧ");
                                Console.WriteLine("2) Создать двумерный массив вручную");
                                Console.WriteLine("3) Печать двумерного массива");
                                Console.WriteLine("4) Добавление столбца с заданным номером к двумерному массиву (пустой столбец)");
                                Console.WriteLine("5) Добавление столбца с заданным номером к двумерному массиву (каждый элемент вводит пользователь)");
                                Console.WriteLine("6) Добавление столбца с заданным номером к двумерному массиву (каждый элемент генерируется случайно)");
                                Console.WriteLine("7) Назад");
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            CreateMatrRnd(ref matr);
                                            break;
                                        }
                                    case 2:
                                        {
                                            CreateMatr(ref matr);
                                            break;
                                        }
                                    case 3:
                                        {
                                            PrintMatr(matr);
                                            break;
                                        }
                                    case 4:
                                        {
                                            matr = AddColZero(matr);
                                            break;
                                        }
                                    case 5:
                                        {
                                            matr=AddCol(matr);
                                            break;
                                        }
                                    case 6:
                                        {
                                            matr = AddColRnd(matr);
                                            break;
                                        }
                                }
                            } while (ans != 7);
                            break;
                        }
                    case 3:
                        {
                            int[][] rmass = new int[0][];
                            do
                            { 
                                Console.WriteLine("Выберите корректный пункт");
                                Console.WriteLine("1) Создать рваный массив при помощи ДСЧ");
                                Console.WriteLine("2) Создать рваный массив вручную");
                                Console.WriteLine("3) Печать рваного массива");
                                Console.WriteLine("4) Удаление самой короткой строки рваного массива");
                                Console.WriteLine("5) Назад");
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {

                                            CreateRmassRnd(ref rmass);
                                            break;
                                        }
                                    case 2:
                                        {
                                            CreateRmass(ref rmass);
                                            break;
                                        }
                                    case 3:
                                        {
                                            PrintRmass(rmass); 
                                            break;
                                        }
                                    case 4:
                                        {
                                            DeleteShortLine(ref rmass);
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Работа завершена");
                            break;
                        }
                }
            } while (ans != 4);
        }
    }
}
