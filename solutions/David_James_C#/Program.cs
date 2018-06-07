using System;
using System.Collections.Generic;

namespace Befunge
{
    class Program
    {
        enum Direction
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }

        static void Main(string[] args)
        {

            const int width = 20;
            const int height = 20;

            var playBoard = new char[width, height];
            var stack = new Stack<int>();
            var currentX = 0;
            var currentY = 0;
            var currentDirection = Direction.Right;

            // Calculate42(playBoard);
            CountDownAndLiftOff(playBoard);

            while (playBoard[currentX, currentY] != '@')
            {
                var current = playBoard[currentX, currentY];
                switch (current)
                {
                    case '"':

                        while (true)
                        {
                            MoveToNextSquare(ref currentX, ref currentY, currentDirection);
                            var c = playBoard[currentX, currentY];
                            if (c == '"')
                            {
                                break;
                            }
                            else
                            {
                                stack.Push(c);
                            }
                        }

                        break;

                    case '+':
                        Add(stack);
                        break;

                    case '-':
                        Subtract(stack);
                        break;

                    case '*':
                        Multiply(stack);
                        break;

                    case '/':
                        Divide(stack);
                        break;

                    case '%':
                        Modulo(stack);
                        break;

                    case ':':
                        Duplicate(stack);
                        break;

                    case '\\':
                        Swap(stack);
                        break;

                    case '$':
                        Discard(stack);
                        break;

                    case '.':
                        Print(stack);
                        break;

                    case ',':
                        PrintAscii(stack);
                        break;

                    case '>':
                        currentDirection = Direction.Right;
                        break;

                    case '<':
                        currentDirection = Direction.Left;
                        break;

                    case '^':
                        currentDirection = Direction.Up;
                        break;

                    case 'v':
                        currentDirection = Direction.Down;
                        break;

                    case '#':
                        MoveToNextSquare(ref currentX, ref currentY, currentDirection);
                        break;

                    case '!':
                        Not(stack);
                        break;

                    case '`':
                        GreaterThan(stack);
                        break;

                    case '_':
                        currentDirection = (PopInt(stack) == 0) ? Direction.Right : Direction.Left;
                        break;

                    case '|':
                        currentDirection = (PopInt(stack) == 0) ? Direction.Down : Direction.Up;
                        break;

                    case 'p':
                        var y = PopInt(stack);
                        var x = PopInt(stack);
                        var v = stack.Pop();
                        playBoard[x, y] = (char)v;
                        break;

                    case 'g':
                        var y1 = PopInt(stack);
                        var x1 = PopInt(stack);
                        stack.Push(playBoard[x1, y1]);
                        break;

                    default:
                        if (char.IsDigit(current))
                        {
                            stack.Push(current);
                        }
                        break;
                }

                MoveToNextSquare(ref currentX, ref currentY, currentDirection);
            }

            Console.WriteLine("");
            Console.WriteLine("All done");
            Console.ReadKey(true);
        }

        private static void CalcFactorial(char[,] playBoard)
        {
            //    playBoard[0,0] = 
        }




        private static void Calculate42(char[,] playBoard)
        {
            playBoard[0, 0] = '3';
            playBoard[1, 0] = '2';
            playBoard[2, 0] = '*';
            playBoard[3, 0] = '8';
            playBoard[4, 0] = '1';
            playBoard[5, 0] = '-';
            playBoard[6, 0] = '*';
            playBoard[7, 0] = '.';
            playBoard[8, 0] = '@';
        }

        private static void CountDownAndLiftOff(char[,] playBoard)
        {
            playBoard[0, 0] = 'v';
            playBoard[1, 0] = ' ';
            playBoard[2, 0] = 'v';
            playBoard[3, 0] = ' ';
            playBoard[4, 0] = '-';
            playBoard[5, 0] = '1';
            playBoard[6, 0] = '<';
            playBoard[7, 0] = '<';
            playBoard[8, 0] = '<';

            playBoard[0, 1] = '>';
            playBoard[1, 1] = '9';
            playBoard[2, 1] = '>';
            playBoard[3, 1] = ':';
            playBoard[4, 1] = '.';
            playBoard[5, 1] = ':';
            playBoard[6, 1] = '1';
            playBoard[7, 1] = '`';
            playBoard[8, 1] = '|';

            playBoard[8, 2] = '0';  //Dummy bottom of stack token
            playBoard[8, 3] = '"';
            playBoard[8, 4] = 'f';
            playBoard[8, 5] = 'f';
            playBoard[8, 6] = 'o';
            playBoard[8, 7] = 't';
            playBoard[8, 8] = 'f';
            playBoard[8, 9] = 'i';
            playBoard[8, 10] = 'L';
            playBoard[8, 11] = '"';

            playBoard[8, 12] = 'v';
            playBoard[8, 13] = ',';
            playBoard[8, 14] = ':';
            playBoard[8, 15] = '_';

            playBoard[7, 12] = '>';
            playBoard[7, 13] = '^';
            playBoard[7, 14] = '^';
            playBoard[7, 15] = '^';

            playBoard[9, 15] = '@';
        }


        private static void MoveToNextSquare(ref int currentX, ref int currentY, Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentY--;
                    break;
                case Direction.Down:
                    currentY++;
                    break;
                case Direction.Left:
                    currentX--;
                    break;
                case Direction.Right:
                    currentX++;
                    break;
                default:
                    break;
            }
        }

        private static void Print(Stack<int> stack)
        {
            var b = PopInt(stack);
            Console.Write(b + " ");
        }

        private static void PrintAscii(Stack<int> stack)
        {
            var b = (char)stack.Pop();
            Console.Write(b);
        }

        private static void Subtract(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            var total = b - a;
            PushInt(stack, total);
        }

        private static void Add(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            var total = b + a;
            PushInt(stack, total);
        }

        private static void Not(Stack<int> stack)
        {
            var a = PopInt(stack);
            if (a == 0)
            {
                stack.Push('1');
            }
            else
            {
                stack.Push('0');
            }

        }

        private static void GreaterThan(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);

            if (b > a)
            {
                stack.Push('1');
            }
            else
            {
                stack.Push('0');
            }
        }

        private static void Discard(Stack<int> stack)
        {
            PopInt(stack);
        }
        private static void Swap(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            PushInt(stack, a);
            PushInt(stack, b);
        }
        private static void Duplicate(Stack<int> stack)
        {
            var a = PopInt(stack);
            PushInt(stack, a);
            PushInt(stack, a);
        }
        private static void Modulo(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            var total = b % a;
            PushInt(stack, total);
        }
        private static void Divide(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            var total = b / a;
            PushInt(stack, total);
        }

        private static void Multiply(Stack<int> stack)
        {
            var a = PopInt(stack);
            var b = PopInt(stack);
            var total = a * b;
            PushInt(stack, total);
        }

        private static int PopInt(Stack<int> stack) => stack.Pop() - '0';
        private static void PushInt(Stack<int> stack, int value)
        {
            stack.Push(value + '0');
        }
    }
}
