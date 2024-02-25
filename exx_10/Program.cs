using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exx_10
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

        private static void Start()
        {
            Console.WriteLine("Введите координаты фигур:");
            Console.WriteLine(" 1. Фигуры: ферзь, король, ладья, слон, конь");
            Console.WriteLine(" 2. Пример ввода: ферзь");
            var input = Console.ReadLine().Split(' ');

            if (input.Length != 1)
            {
                Console.WriteLine("Введены некорректные данные");
                return;
            }

            var inputFigure = input[0];
            Figure figure;
            switch (inputFigure)
            {
                case "ферзь": // Queen
                    figure = new Queen();
                    figure.name = "ферзь";
                    break;
                case "король": // King
                    figure = new King();
                    figure.name = "король";
                    break;
                case "ладья": // Rook
                    figure = new Rook();
                    figure.name = "ладья";
                    break;
                case "слон": // Bishop
                    figure = new Bishop();
                    figure.name = "слон";
                    break;
                case "конь": // Knight
                    figure = new Knight();
                    figure.name = "конь";
                    break;
                default:
                    Console.WriteLine("Вы ввели неверное название фигуры");
                    return;
            }

            Random rnd = new Random();
            figure.SetCoord(sym[rnd.Next(sym.Length)], nums[rnd.Next(sym.Length)]);
            
            var x = sym[rnd.Next(sym.Length)];
            var y = nums[rnd.Next(sym.Length)];
            while (figure.CanBeat(x, y))
            {
                x = sym[rnd.Next(sym.Length)];
                y = nums[rnd.Next(sym.Length)];
            }

            Console.WriteLine($"{figure.name} на позиции {figure.X}{figure.Y}");
            Console.WriteLine($"фигура на позиции {x}{y}");
        }

        private static char[] sym = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        private static char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8' };

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
