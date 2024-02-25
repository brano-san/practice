using System;

namespace ex_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты Короля x1y1 и координаты фигуры x2y2");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            char kingX = coordinates[0][0];
            char kingY = coordinates[0][1];
            char pieceX = coordinates[1][0];
            char pieceY = coordinates[1][1];

            if (!(kingX >= 'a' && kingX <= 'h' && kingY >= '1' && kingY <= '8' &&
                  pieceX >= 'a' && pieceX <= 'h' && pieceY >= '1' && pieceY <= '8'))
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            if (Math.Abs(kingX - pieceX) <= 1 && Math.Abs(kingY - pieceY) <= 1)
            {
                Console.WriteLine("Король сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Король не сможет побить фигуру");
            }
        }
    }
}
