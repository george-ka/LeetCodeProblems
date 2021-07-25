using System;

namespace LeetCodeChallenges
{
    ///
    /// 1349. Maximum Students Taking Exam
    /// https://leetcode.com/problems/maximum-students-taking-exam/
    ///
    public class PlaceMaxStudentsSolution
    {
        Action<string, char[][]> _onNextIterationHandler;
        Tuple<int,int>[] _sortedColumnsByAvailableSeats;
        public void SetOnNextInteration(Action<string, char[][]> handler)
        {
            _onNextIterationHandler = handler;
        }

        public int MaxStudents(char[][] seats) 
        {
            if (_onNextIterationHandler != null)
            {
                _onNextIterationHandler($"Initial setting", seats);
            }
            
            /// This solution is unfortunatelly (n * m) ^ 2
            /// This is a brute force solution, where first student may choose
            /// a "random" or any spot and all others follow certain strategy
            /// In order to try all options we make n x m attempts for the first student.
            /// On each iteration the spots are cleared
            /// Then other students must occupy all spots above and below the first one 
            /// simultaneously marking other neighbouring available spots as "cheaters" spots with 'c'.
            /// Cheaters spot can't be occupied.   

            /// Initially all columns are sorted by max available seats.
            /// We try to occupy the next columns in order to maximize the number of students

            /// There is an option to make it faster by just starting from different columns
            /// making it n^2 * m

            _sortedColumnsByAvailableSeats = SortColumnsByAvailableSeats(seats);
            
            var currentMax = 0;
            for (var i = 0; i < seats.Length; i++)
            {
                for (var j = 0; j < seats[i].Length; j++)
                {
                    if (seats[i][j] != '#')
                    {
                        var numberOfSeats = TryRebuild(seats, i, j);
                        if (numberOfSeats > currentMax)
                        {
                            currentMax = numberOfSeats;
                        }

                        if (_onNextIterationHandler != null)
                        {
                            _onNextIterationHandler($"{i},{j} max = {currentMax}", seats);
                        }
                        
                        Reset(seats);
                    }
                }
            }
            
            return currentMax;
        }

        private Tuple<int,int>[] SortColumnsByAvailableSeats(char[][] seats)
        {
            var columnsByAvailableSeats = new Tuple<int, int>[seats[0].Length];
            var keys = new int[seats[0].Length];

            for (var j = 0; j < seats[0].Length; j++)
            {
                var availableSeats = 0;
                for (var i = 0; i < seats.Length; i++)
                {
                    if (seats[i][j] == '.')
                    {
                        availableSeats++;
                    }
                }

                columnsByAvailableSeats[j] = new Tuple<int, int>(j, availableSeats);
                keys[j] = availableSeats;
            }

            Array.Sort(keys, columnsByAvailableSeats);
            Array.Reverse(columnsByAvailableSeats);

            for (var i = 0; i < columnsByAvailableSeats.Length; i++)
            {
                Console.WriteLine($"col {columnsByAvailableSeats[i].Item1} maxSeats {columnsByAvailableSeats[i].Item2}");
            }

            Console.WriteLine();

            return columnsByAvailableSeats; 
        }
            
        public int TryRebuild(char[][] seats, int i, int j) {
            var occupiedSeats = 1;
            seats[i][j] = 'o';
            MarkNeighboursAsCheaters(seats, i, j);
            
            occupiedSeats += 
                TryOccupyBelowAndAbove(seats, i, j) +
                TryOccupyOtherColumnsWithMoreSeats(seats, j);
            
            return occupiedSeats;
        }
        
        public int TryOccupyBelowAndAbove(char[][] seats, int startI, int j) 
        {
            var occupied = 0;
            // go down
            for (var i = startI + 1; i < seats.Length; i++)
            {
                occupied += TryOccupyOne(seats, i, j);
            }

            // go up
            for (var i = startI - 1; i >= 0; i--)
            {
                occupied += TryOccupyOne(seats, i, j);
            }
            
            return occupied;
        }

        public int TryOccupyOtherColumnsWithMoreSeats(char[][] seats, int firstOccupiedColumn)
        {            
            var occupied = 0;
            for (var j = 0; j < _sortedColumnsByAvailableSeats.Length; j++)
            {
                var column = _sortedColumnsByAvailableSeats[j].Item1;
                if (column == firstOccupiedColumn)
                {
                    continue;
                }

                for (var i = 0; i < seats.Length; i++)
                {
                    occupied += TryOccupyOne(seats, i, column);
                }
            }

            return occupied;
        }

        public int TryOccupyToTheRight(char[][] seats, int startJ)
        {            
            var occupied = 0;
            for (var j = startJ + 1; j < seats[0].Length; j++)
            {
                for (var i = 0; i < seats.Length; i++)
                {
                    occupied += TryOccupyOne(seats, i, j);
                }
            }

            return occupied;
        }

        public int TryOccupyOne(char[][] seats, int i, int j)
        {
            if (IsInBoundaries(seats, i, j)
                && seats[i][j] == '.')
            {
                // Check neighbours not occupied
                if (IsOccupiedAndInBoundaries(seats, i, j - 1)
                    || IsOccupiedAndInBoundaries(seats, i, j + 1)
                    || IsOccupiedAndInBoundaries(seats, i + 1, j - 1)
                    || IsOccupiedAndInBoundaries(seats, i + 1, j + 1)
                    || IsOccupiedAndInBoundaries(seats, i - 1, j - 1)
                    || IsOccupiedAndInBoundaries(seats, i - 1, j + 1))
                {
                    seats[i][j] = 'c';
                    return 0;
                }
                else
                {
                    seats[i][j] = 'o';
                    return 1;
                }
            }
            
            return 0;
        }

        public bool IsOccupiedAndInBoundaries(char[][] seats, int i, int j)
        {
            return IsInBoundaries(seats, i, j) && seats[i][j] == 'o';
        }
        public bool IsInBoundaries(char[][] seats, int i, int j)
        {
            return i >= 0 
                && i < seats.Length 
                && j >= 0
                && j < seats[i].Length;
        }
        public void MarkNeighboursAsCheaters(char[][] seats, int i, int j)
        {
            MarkLeftRightNeighboursAsCheaters(seats, i, j);
            if (i > 0)
                MarkLeftRightNeighboursAsCheaters(seats, i-1, j);
            if (i < seats.Length - 1)
                MarkLeftRightNeighboursAsCheaters(seats, i+1, j);
        }
        
        public void MarkLeftRightNeighboursAsCheaters(char[][] seats, int i, int j)
        {
            if (j > 0 && seats[i][j - 1] != '#')
                seats[i][j - 1] = 'c';
            if (j < seats[i].Length - 1 && seats[i][j + 1] != '#')
                seats[i][j + 1] = 'c';
        }
        
        public void Reset(char[][] seats)
        {
            for (var i = 0; i < seats.Length; i++)
            {
                for (var j = 0; j < seats[i].Length; j++)
                {
                    if (seats[i][j] != '#')
                        seats[i][j] = '.';
                }
            }
        }
    }
}