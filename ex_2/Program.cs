using System;

namespace ex_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты слона x1y1 и координаты фигуры x2y2");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            char elephantX = coordinates[0][0];
            char elephantY = coordinates[0][1];
            char pieceX = coordinates[1][0];
            char pieceY = coordinates[1][1];

            if (!(elephantX >= 'a' && elephantX <= 'h' && elephantY >= '1' && elephantY <= '8' &&
                  pieceX >= 'a' && pieceX <= 'h' && pieceY >= '1' && pieceY <= '8'))
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            if (Math.Abs(elephantX - pieceX) == Math.Abs(elephantY - pieceY))
            {
                Console.WriteLine("Слон сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Слон не сможет побить фигуру");
            }
        }
    }
}
