using System;

namespace ex_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты Коня x1y1 и координаты фигуры x2y2");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            char horseX = coordinates[0][0];
            char horseY = coordinates[0][1];
            char pieceX = coordinates[1][0];
            char pieceY = coordinates[1][1];

            if (!(horseX >= 'a' && horseX <= 'h' && horseY >= '1' && horseY <= '8' &&
                  pieceX >= 'a' && pieceX <= 'h' && pieceY >= '1' && pieceY <= '8'))
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            if (Math.Abs(horseX - pieceX) == 2 && Math.Abs(horseY - pieceY) == 1 ||
                Math.Abs(horseX - pieceX) == 1 && Math.Abs(horseY - pieceY) == 2)
            {
                Console.WriteLine("Коня сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Коня не сможет побить фигуру");
            }
        }
    }
}
