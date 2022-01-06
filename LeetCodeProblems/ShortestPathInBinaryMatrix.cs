using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace LeetCodeChallenges
{
    ///
    /// 1091. Shortest Path in Binary Matrix
    /// https://leetcode.com/problems/shortest-path-in-binary-matrix/
    /// 
    /// Given an n x n binary matrix grid, return the length of the 
    /// shortest clear path in the matrix. If there is no clear path, 
    /// return -1.
    /// A clear path in a binary matrix is a path from the top-left cell 
    /// (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such 
    /// that:
    /// All the visited cells of the path are 0.
    /// All the adjacent cells of the path are 8-directionally connected 
    /// (i.e., they are different and they share an edge or a corner).
    /// The length of a clear path is the number of visited cells of this path.
    public class ShortestPathInBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid) 
        {
            if (grid == null
            || grid[0][0] == 1
            || grid[grid.Length - 1][grid[grid.Length - 1].Length - 1] == 1)
            {
                return -1;
            }

            var priorityQueue = new MinHeap<CoordinatesWithDistance>(grid.Length * grid.Length);
            var previousCoords = new Dictionary<Coordinates, Coordinates>();
            var pathLength = new Dictionary<Coordinates, int>();

            var seed = new CoordinatesWithDistance(new int[2], 0);
            priorityQueue.Add(seed);
            previousCoords[seed.Coords] = null;
            pathLength[seed.Coords] = 1;
            var target = new Coordinates(grid.Length - 1, grid.Length - 1);
            var maximumHeuristicDistance = 0;
            var targetFound = false;

            while (!priorityQueue.IsEmpty)
            {
                var current = priorityQueue.Pop();
                Console.WriteLine($"Current {current}");

                if (targetFound && current.Distance > maximumHeuristicDistance)
                {
                    Console.WriteLine($"Skip {current} as distance is greater than {maximumHeuristicDistance}");
                    continue;
                }

                var directionsWithDistance = Directions
                    .Where(d => CanMakeNextMove(grid, current.Coords.X, current.Coords.Y, d))
                    .Select(d => current.Coords + new Coordinates(d))
                    .Where(c => !previousCoords.ContainsKey(c) || pathLength[current.Coords] + 1 < pathLength[c])
                    .Select(c => new CoordinatesWithDistance(c, pathLength[current.Coords] + 1 + c.Distance(target)))
                    .ToArray();
                
                foreach (var newCord in directionsWithDistance)
                {
                    Console.WriteLine($"New cord {newCord}");
                    priorityQueue.Add(newCord);
                    previousCoords[newCord.Coords] = current.Coords;
                    pathLength[newCord.Coords] = pathLength[current.Coords] + 1;

                    if (newCord.Coords.Equals(target))
                    {
                        var curCords = newCord.Coords;
                        Console.WriteLine($"Path to {curCords}");
                        while (previousCoords[curCords] != null)
                        {
                            Console.WriteLine(previousCoords[curCords]);
                            curCords = previousCoords[curCords];
                        }

                        targetFound = true;
                        // trying other options within current max + 1 to improve our result
                        maximumHeuristicDistance = pathLength[newCord.Coords] + 1;
                        Console.WriteLine($"Target found. Current best distance is {pathLength[newCord.Coords]}. Exploring other options with distance within {maximumHeuristicDistance}");
                    }
                }
            }

            if (targetFound)
            {
                return pathLength[target];
            }
            
            return -1; 
        }
        private bool CanMakeNextMove(int[][] grid, int i, int j, int[] nextMoveDirection)
        {
            return IsValidCordinates(grid, i + nextMoveDirection[0], j + nextMoveDirection[1])
                 && grid[i + nextMoveDirection[0]][j + nextMoveDirection[1]] == 0;
        }

        private bool IsValidCordinates(int[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }

        private static int[][] Directions = new []
        {
            /// [-1 -1] [-1 0] [-1 +1]
            /// [ 0 -1] [ 0 0] [ 0 +1]
            /// [+1 -1] [+1 0] [+1 +1]
            /// Third coordinate is weight of a step
            new [] { 1, 1 },
            new [] { 1, 0 },
            new [] { 0, 1 },
            new [] { -1, 1 },
            new [] { 1, -1 },
            new [] { 0, -1 },
            new [] { -1, 0 },
            new [] { -1, -1 }
        };

        public class Coordinates : IEquatable<Coordinates>
        {
            public Coordinates(int[] cords)
            {
                if (cords == null)
                {
                    throw new ArgumentNullException(nameof(cords));
                }

                if (cords.Length < 2)
                {
                    throw new ArgumentException("Cords length must be 2 or greater", nameof(cords));
                }

                InnerArray = cords;
                X = cords[0];
                Y = cords[1];
            }

            public Coordinates(int x, int y)
                : this(new [] { x, y })
            {
            }

            public int X { get; private set; }
            public int Y { get; private set; }

            public int[] InnerArray { get; private set;}

            public static Coordinates operator +(Coordinates a, Coordinates b) 
                => new Coordinates(a.X + b.X, a.Y + b.Y);

            public double Distance(Coordinates target)
            {
                if (target == null)
                {
                    throw new ArgumentNullException(nameof(target));
                }

                return Math.Sqrt(Math.Pow(target.X - X, 2) + Math.Pow(target.Y - Y, 2));
            }

            public bool Equals(Coordinates other)
            {
                return X == other.X && Y == other.Y;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                
                return Equals((Coordinates)obj);
            }

            public override int GetHashCode()
            {
                int hash = 17;
                unchecked // Overflow is fine, just wrap
                {
                    hash = hash * 23 + X.GetHashCode();
                    hash = hash * 23 + Y.GetHashCode();
                }

                return hash;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        public class CoordinatesWithDistance : IComparable<CoordinatesWithDistance>
        {
            public CoordinatesWithDistance(Coordinates coordinates, double distance)
            {
                Coords = coordinates;
                Distance = distance;
            }

            public CoordinatesWithDistance(int[] coordinates, double distance)
                : this(new Coordinates(coordinates), distance)
            {
            }

            public Coordinates Coords { get; set; }

            public double Distance { get; set; }

            public int CompareTo(CoordinatesWithDistance another)
            {
                return Distance.CompareTo(another.Distance);
            }

            public override string ToString()
            {
                return Coords.ToString() + " " + Distance;
            }
        }

        public class MinHeap<T> where T : IComparable<T>
        {
            public MinHeap(int size)
            {
                _backHeap = new T[size + 1];
                _lastIndex = 1;
            }

            public Action<T, int> OnElementRearrange = (e, i) => { };

            public void Add(T element)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(nameof(element));
                }

                if (_lastIndex >= _backHeap.Length)
                {
                    throw new HeapOverflowException();
                }

                _backHeap[_lastIndex] = element;
                OnElementRearrange(element, _lastIndex);
                BubleUp(_lastIndex);
                _lastIndex++;
            }

            public bool IsEmpty
            {
                get => _lastIndex == 1;
            }

            public T Pop()
            {
                if (IsEmpty)
                {
                    return default(T);
                }

                var result = GetMin();
                DeleteAt(1);
                return result;
            }

            public T GetMin()
            {
                return _backHeap[1];
            }

            public void DeleteAt(int index)
            {
                if (index >= _lastIndex)
                {
                    throw new ArgumentException("Index exceeds current right bound. There are no elements.");
                }

                if (index == _lastIndex - 1)
                {
                    _backHeap[index] = default(T);
                    _lastIndex -= 1;
                    return;
                }

                Swap(index, _lastIndex - 1);
                DeleteAt(_lastIndex - 1);
                BubleUp(index); // just in case it can be bubled up
                BubleDown(index);
            }

            public override string ToString()
            {
                var stringBuilder = new StringBuilder();
                for (var i = 1; i < _lastIndex; i++)
                {
                    stringBuilder.AppendFormat("{0}, ", _backHeap[i]);
                }
                
                return stringBuilder.ToString();
            }

            public string ToTreeString()
            {
                var currentLevel = new Queue<int>();
                Queue<int> nextLevel = null;
                var stringBuilder = new StringBuilder();

                currentLevel.Enqueue(1);
                
                do 
                {
                    nextLevel = new Queue<int>();
                    while (currentLevel.Count > 0)
                    {
                        var value = currentLevel.Dequeue();
                        stringBuilder.AppendFormat("{0}, ", _backHeap[value]);

                        var leftChildIndex = GetLeftChildIndex(value);
                        if (leftChildIndex < _lastIndex)
                        {
                            nextLevel.Enqueue(leftChildIndex);
                        }

                        var rightChildIndex = GetRightChildIndex(value);
                        if (rightChildIndex < _lastIndex)
                        {
                            nextLevel.Enqueue(rightChildIndex);
                        }
                    }

                    currentLevel = nextLevel;
                    stringBuilder.Append(Environment.NewLine);
                }
                while (nextLevel.Count > 0);
                return stringBuilder.ToString();
            } 

            private void BubleDown(int index)
            {
                var leftChildIndex = GetLeftChildIndex(index);
                var rightChildIndex = GetRightChildIndex(index);
                
                var indexToSwap = 0;

                if (leftChildIndex >= _lastIndex)
                {
                    return;
                }

                if (rightChildIndex >= _lastIndex)
                {
                    indexToSwap = leftChildIndex;
                }
                else
                {
                    if (_backHeap[leftChildIndex].CompareTo(_backHeap[rightChildIndex]) < 0)
                    {
                        indexToSwap = leftChildIndex;
                    }
                    else
                    {
                        indexToSwap = rightChildIndex;
                    }
                }
                
                if (_backHeap[index].CompareTo(_backHeap[indexToSwap]) > 0)
                {
                    Swap(index, indexToSwap);
                    BubleDown(indexToSwap);
                }
            }

            private void BubleUp(int index)
            {
                if (index == 1)
                {
                    return;
                }

                if (_backHeap[index].CompareTo(_backHeap[GetParentIndex(index)]) < 0)
                {
                    Swap(index, GetParentIndex(index));
                    BubleUp(GetParentIndex(index));
                }
            }

            private int GetParentIndex(int index)
            {
                return index / 2;
            }

            private int GetLeftChildIndex(int index)
            {
                return index * 2;
            }

            private int GetRightChildIndex(int index)
            {
                return (index * 2) + 1;
            }

            private void Swap(int index1, int index2)
            {
                var buffer = _backHeap[index1];
                _backHeap[index1] = _backHeap[index2];
                _backHeap[index2] = buffer;
                OnElementRearrange(_backHeap[index1], index1);
                OnElementRearrange(_backHeap[index2], index2);
            }

            private int _lastIndex; 
            private T[] _backHeap;
        }

        [Serializable]
        public class HeapOverflowException : Exception 
        {
            public HeapOverflowException()
            {
            } 
            
            public HeapOverflowException(string message)
                : base(message)
            {
            } 

            public HeapOverflowException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }
    }
}