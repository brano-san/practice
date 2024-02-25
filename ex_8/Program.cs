using System;

namespace ex_8
{
    internal class Program
    {
        private static bool IsBlack(char x, char y)
        {
            return ((x + y) % 2 != 0);
        }

        static void Main(string[] args)
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                Console.WriteLine("Введите координаты первой фигуры x1y1 и координаты второй фигуры x2y2");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(' ');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Введены некорректные координаты");
                    return;
                }

                char rookX = coordinates[0][0];
                char rookY = coordinates[0][1];
                char pieceX = coordinates[1][0];
                char pieceY = coordinates[1][1];

                if (!(rookX >= 'a' && rookX <= 'h' && rookY >= '1' && rookY <= '8' &&
                      pieceX >= 'a' && pieceX <= 'h' && pieceY >= '1' && pieceY <= '8'))
                {
                    Console.WriteLine("Введены некорректные координаты");
                    return;
                }

                if (IsBlack(rookX, rookY) == !IsBlack(pieceX, pieceY))
                {
                    Console.WriteLine("Ячейки разных цветов");
                }
                else
                {
                    Console.WriteLine("Ячейки одного цвета");
                } 
            }
        }
    }
}
