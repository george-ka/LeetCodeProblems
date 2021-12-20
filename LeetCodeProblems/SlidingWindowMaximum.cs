using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 239. Sliding Window Maximum
    /// https://leetcode.com/problems/sliding-window-maximum/description/
    /// 
    /// This solution with Max-heap is n * log(k)
    /// is not optimal, because it uses a Heap which contains all k elements
    /// Every iteration adds an element to heap and removes one
    /// To quickly find an element in the heap we also use a Queue of
    /// k elements and each element remembers it's index in the heap
    /// So once we need to remove an element from Heap, we pop it from the
    /// queue, get it's index and remove it from Heap, which takes log(k) time
    /// We add new element to the Queue O(1) and to the Heap O(log(k))
    ///
    /// This is the first solution which I realized to be not optimal
    /// when I checked for solutions :(
    /// There is O(n) solution with a deque, which I couldn't find
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k) 
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            if (nums.Length < k)
            {
                throw new ArgumentException($"Nums length should be greater than {k}");
            }

            // |1|2|3|4|5|6|
            // |1|2|          1
            //   |_|_|        2
            //     |_|_|      3
            //       |_|_|    4
            //         |_|_|  5
            // num.Length - k + 1
            var result = new int[nums.Length - k + 1];
            // Queue for the sliding window, we add and pop elements while we move right
            var slidingWindow = new Queue<SlidingWindowElement>();
            // Max heap is to track order in the queue
            // SlidingWindowElement remembers it's index in the max-heap
            // so it can be easily found in the heap when it's time to remove it 
            var slidingWindowHeap = new MaxHeap<SlidingWindowElement>(k);
            
            // This is a callback to update element's index in max-heap
            // when it bubles up or down the heap
            slidingWindowHeap.OnElementRearrange = 
                (element, newIndex) =>
                {
                    element.HeapIndex = newIndex;
                };
            
            // Fill in the queue and heap with first k elements
            for (var i = 0; i < k; i++)
            {
                var element = new SlidingWindowElement(nums[i]);
                slidingWindow.Enqueue(element);
                slidingWindowHeap.Add(element);
            }

            var j = 0;
            result[j] = slidingWindowHeap.GetMax().Value;
            j++;
            for (var i = k; i < nums.Length; i++)
            {
                var elementToDelete = slidingWindow.Dequeue();
                var newElement = new SlidingWindowElement(nums[i]);
                slidingWindow.Enqueue(newElement);
                slidingWindowHeap.DeleteAt(elementToDelete.HeapIndex);
                slidingWindowHeap.Add(newElement);
                result[j] = slidingWindowHeap.GetMax().Value;
                j++;
                
                Console.WriteLine($"Adding {nums[i]}");
                Console.WriteLine(slidingWindowHeap.ToTreeString());
            }

            return result;
        }

        public class SlidingWindowElement : IComparable<SlidingWindowElement>
        {
            public SlidingWindowElement(int value)
            {
                Value = value;
            }

            public int CompareTo(SlidingWindowElement another)
            {
                return Value.CompareTo(another.Value);
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            public int HeapIndex { get; set; }
            public int Value { get; private set; }
        }

        public class MaxHeap<T> where T : IComparable<T>
        {
            public MaxHeap(int size)
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

            public T GetMax()
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
                    if (_backHeap[leftChildIndex].CompareTo(_backHeap[rightChildIndex]) > 0)
                    {
                        indexToSwap = leftChildIndex;
                    }
                    else
                    {
                        indexToSwap = rightChildIndex;
                    }
                }
                
                if (_backHeap[index].CompareTo(_backHeap[indexToSwap]) < 0)
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

                if (_backHeap[index].CompareTo(_backHeap[GetParentIndex(index)]) > 0)
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