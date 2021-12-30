using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 547. Number of Provinces
    /// https://leetcode.com/problems/number-of-provinces/
    /// 
    /// There are n cities. Some of them are connected, while some are not. 
    /// If city a is connected directly with city b, and city b is connected 
    /// directly with city c, then city a is connected indirectly with city c.
    /// A province is a group of directly or indirectly connected cities and 
    /// no other cities outside of the group.
    /// You are given an n x n matrix isConnected where 
    /// isConnected[i][j] = 1 if the ith city and the jth city are directly 
    /// connected, and isConnected[i][j] = 0 otherwise.
    /// Return the total number of provinces.

    /// Same as Number of islands
    public class NumberOfProvinces
    {
        public int FindCircleNum(int[][] connectivityMatix)
        {
            // Step 1 
            // Convert to adjacency list
            var adjacencyList = new Dictionary<int, HashSet<int>>();
            for (var i = 0; i < connectivityMatix.Length; i++)
            {
                adjacencyList[i] = new HashSet<int>();
                for (var j = 0; j < connectivityMatix[i].Length; j++)
                {
                    if (connectivityMatix[i][j] == 1)
                    {
                        adjacencyList[i].Add(j);
                    }
                }
            }

            // Step 2 
            // Search islands       
            return CountNumberOfIslands(adjacencyList);
        }

        private int CountNumberOfIslands(Dictionary<int, HashSet<int>> adjacencyList)
        {
            var visited = new Dictionary<int, bool>();
            foreach (var key in adjacencyList.Keys)
            {
                visited[key] = false;
            }

            var numberOfIslands = 0;
            foreach (var key in adjacencyList.Keys)
            {
                if (visited[key])
                {
                    continue;
                }

                numberOfIslands++;
                var visitQueue = new Queue<int>();
                visitQueue.Enqueue(key);

                while (visitQueue.Count > 0)
                {
                    var visitKey = visitQueue.Dequeue();
                    if (visited[visitKey])
                    {
                        continue;
                    }

                    visited[visitKey] = true;
                    foreach (var toVisit in adjacencyList[visitKey])
                    {
                        visitQueue.Enqueue(toVisit);
                    }
                }
            }

            return numberOfIslands;
        }
    }
}