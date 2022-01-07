using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 797. All Paths From Source to Target
    /// https://leetcode.com/problems/all-paths-from-source-to-target/
    /// 
    /// Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, 
    /// find all possible paths from node 0 to node n - 1 and return them in any order.
    /// The graph is given as follows: graph[i] is a list of all nodes you can visit from 
    /// node i (i.e., there is a directed edge from node i to node graph[i][j]).    
    public class AllPaths
    {
        // Since the graph is acyclic, there is no need to check for cycles
        //             0
        //         1      2
        //       3   4      5
        //      6     7   
        //       8   9
        //         10
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            return FindAllPathsTo(graph, graph.Length - 1, 0, new List<int>());
        }

        private IList<IList<int>> FindAllPathsTo(int[][] graph, int target, int current, List<int> currentPath)
        {
            if (current == target)
            {
                currentPath.Add(target);
                return new IList<int>[] { currentPath };
            }

            currentPath.Add(current);

            var result = new List<IList<int>>();
            // for all children of a current node
            for (var i = 0; i < graph[current].Length; i++)
            {
                var thisLevelResult = FindAllPathsTo(graph, target, graph[current][i], currentPath.ToList());
                result.AddRange(thisLevelResult);
            }

            return result;
        }
    }
}