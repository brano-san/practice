using System;

namespace ex_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты Ферзя x1y1 и координаты фигуры x2y2");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            char queenX = coordinates[0][0];
            char queenY = coordinates[0][1];
            char pieceX = coordinates[1][0];
            char pieceY = coordinates[1][1];

            if (!(queenX >= 'a' && queenX <= 'h' && queenY >= '1' && queenY <= '8' &&
                  pieceX >= 'a' && pieceX <= 'h' && pieceY >= '1' && pieceY <= '8'))
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            if ((Math.Abs(queenX - pieceX) == Math.Abs(queenY - pieceY)) ||
                (queenX == pieceX || queenY == pieceY))
            {
                Console.WriteLine("Ферзь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру");
            }
        }
    }
}
