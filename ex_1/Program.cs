﻿using System;

namespace ex_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты ладьи x1y1 и координаты фигуры x2y2");
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

            if (rookX == pieceX || rookY == pieceY)
            {
                Console.WriteLine("Ладья сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ладья не сможет побить фигуру");
            }
        }
    }
}
