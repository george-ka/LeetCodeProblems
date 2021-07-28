using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class PlaceMaxStudentsTests
    {
        [Test]
        public void Test0()
        {
            var seats = new char[][]
            {
                new char[] { '#','.','#','#','.','#' },
                new char[] { '.','#','#','#','#','.' },
                new char[] { '#','.','#','#','.','#' }

            };

            var result = CalculateMaxStudents(seats);
            Assert.AreEqual(4, result);
        }

        [Test]
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

            var result = CalculateMaxStudents(seats);
            Assert.AreEqual(17, result);
        }

        [Test]
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

            var result = CalculateMaxStudents(seats);
            Assert.AreEqual(7, result);
        }

        private static int CalculateMaxStudents(char[][] seats)
        {
            var solution = new PlaceMaxStudentsSolution();
            solution.SetOnNextInteration(PrintIteration);
            return solution.MaxStudents(seats);
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

            // Console.ReadLine();
        }
    }
}