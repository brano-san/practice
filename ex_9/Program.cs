using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;

namespace ex_9
{
    internal class Program
    {
        private abstract class Figure
        {
            public char X;
            public char Y;
            public string name;
            public abstract bool CanBeat(char otherX, char otherY);

            public void SetCoord(char x, char y)
            {
                X = x;
                Y = y;
            }
        }

        private class King : Figure
        {
            public override bool CanBeat(char otherX, char otherY)
            {
                return (Math.Abs(X - otherX) <= 1 && Math.Abs(Y - otherY) <= 1);
            }
        }

        private class Queen : Figure
        {
            public override bool CanBeat(char otherX, char otherY)
            {
                return ((Math.Abs(X - otherX) == Math.Abs(Y - otherY)) ||
                        (X == otherX || Y == otherY));
            }
        }

        private class Bishop : Figure
        {
            public override bool CanBeat(char otherX, char otherY)
            {
                return (Math.Abs(X - otherX) == Math.Abs(Y - otherY));
            }
        }

        private class Knight : Figure
        {
            public override bool CanBeat(char otherX, char otherY)
            {
                return (Math.Abs(X - otherX) == 2 && Math.Abs(Y - otherY) == 1 ||
                        Math.Abs(X - otherX) == 1 && Math.Abs(Y - otherY) == 2);
            }
        }

        private class Rook : Figure
        {
            public override bool CanBeat(char otherX, char otherY)
            {
                return (X == otherX || Y == otherY);
            }
        }

        private static bool InSameZone(char x, char y, char x1, char y1, char x2, char y2)
        {
            if (((x < x1 && y < y1) && (x2 < x1 && y2 < y1)) ||
                ((x > x1 && y > y1) && (x2 > x1 && y2 > y1)) ||
                ((x < x1 && y > y1) && (x2 < x1 && y2 > y1)) ||
                ((x > x1 && y > y1) && (x2 > x1 && y2 > y1)))
                return true;
            return false;
        }

        private static bool CheckCoords(char x, char y)
        {
            return !(x >= 'a' && x <= 'h' && y >= '1' && y <= '8');
        }

        private static void Start()
        {
            Console.WriteLine("Введите координаты фигуры и координаты:");
            Console.WriteLine(" 1. Фигуры: ферзь, король, ладья, слон, конь");
            Console.WriteLine(" 2. Пример ввода: ферзь d3 слон e1 d8");
            var input = Console.ReadLine()?.Split(' ');

            if (input?.Length != 5)
            {
                Console.WriteLine("Введены некорректные данные");
                return;
            }

            var figures = new List<Figure>(2);
            var figuresNames = new List<string> { input[0], input[2] };

            var endpointX = input[4][0];
            var endpointY = input[4][1];

            for (var i = 0; i < 2; i++)
            {
                switch (figuresNames[i])
                {
                    case "ферзь": // Queen
                        figures.Add(new Queen());
                        figures[i].name = "ферзь";
                        break;
                    case "король": // King
                        figures.Add(new King());
                        figures[i].name = "король";
                        break;
                    case "ладья": // Rook
                        figures.Add(new Rook());
                        figures[i].name = "ладья";
                        break;
                    case "слон": // Bishop
                        figures.Add(new Bishop());
                        figures[i].name = "слон";
                        break;
                    case "конь": // Knight
                        figures.Add(new Knight());
                        figures[i].name = "конь";
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное название фигуры");
                        return;
                }
            }

            if (!CheckCoords(input[1][0], input[1][0]) &&
                !CheckCoords(input[3][0], input[3][1]))
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            figures[0].SetCoord(input[1][0], input[1][1]);
            figures[1].SetCoord(input[3][0], input[3][1]);

            if (!figures[1].CanBeat(figures[0].X, figures[0].Y) &&
                !figures[1].CanBeat(endpointX, endpointY))
            {
                if (figures[0].name == "король" &&  
                    (figures[1].name == "ферзь" || figures[1].name == "ладья") &&
                    !InSameZone(figures[0].X, figures[0].Y, figures[1].X, figures[1].Y, endpointX, endpointY))
                {
                    Console.WriteLine($"{figures[0].name} не сможет дойти до {endpointX}{endpointY}");
                    return;
                }

                Console.WriteLine($"{figures[0].name} сможет дойти до {endpointX}{endpointY}");
            }
            else
            {
                Console.WriteLine($"{figures[0].name} не сможет дойти до {endpointX}{endpointY}");
            }
        }   

        private static void Main(string[] args)
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                Start();
                Console.WriteLine();
            }
        }
    }
}
