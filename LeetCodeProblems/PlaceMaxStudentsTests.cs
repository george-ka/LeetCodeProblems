using System;

namespace LeetCodeChallenges
{
    public class PlaceMaxStudentsTests
    {
        public static void RunTests()
        {
            //Test0();
            //Test1();
            Test2();
        }

        public static void Test0()
        {
            var seats = new char[][]
            {
                new char[] { '#','.','#','#','.','#' },
                new char[] { '.','#','#','#','#','.' },
                new char[] { '#','.','#','#','.','#' }

            };

            var solution = new PlaceMaxStudentsSolution();
            solution.SetOnNextInteration(PrintIteration);
            solution.MaxStudents(seats);
        }

        public static void Test1()
        {
            var seats = new char[][]
            {
                new char[] { '#', '.',  '#', '.', '.' },
                new char[] { '#', '#',  '.', '.', '#' },
                new char[] { '#', '#',  '.', '.', '.' },
                new char[] { '.', '#',  '.', '#', '.' },
                new char[] { '.', '.',  '.', '.', '.' },
                new char[] { '#', '.',  '#', '.', '.' },
                new char[] { '#', '.',  '.', '.', '#' },
                new char[] { '#', '.',  '.', '.', '.' },
                new char[] { '.', '.',  '.', '#', '.' }
            };

            var solution = new PlaceMaxStudentsSolution();
            solution.SetOnNextInteration(PrintIteration);
            solution.MaxStudents(seats);
        }

        public static void Test2()
        {
            var seats = new char[][]
            {
                new char[] {'#','.','#','.','.'},
                new char[] {'.','#','#','#','#'},
                new char[] {'#','.','.','#','#'},
                new char[] {'#','.','#','.','.'},
                new char[] {'#','.','#','#','.'}
            };

            var solution = new PlaceMaxStudentsSolution();
            solution.SetOnNextInteration(PrintIteration);
            solution.MaxStudents(seats);
        }

        private static void PrintIteration(string description, char[][] seats)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(description);
            
            for (var i = 0; i < seats.Length; i++)
            {
                for (var j = 0; j < seats[i].Length; j++)
                {
                    Console.Write($"{seats[i][j]} ");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}