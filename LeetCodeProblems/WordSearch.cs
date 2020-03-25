using System;
using System.Linq;
using System.Collections.Generic;
using LeetCodeChallenges.DataStructures;
using System.Text;

namespace LeetCodeChallenges
{
    ///
    /// 212. Word Search II
    /// https://leetcode.com/problems/word-search-ii
    ///
    public class WordSearch
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var trie = new TrieNode();
            foreach (var word in words)
            {
                trie.Add(word.ToCharArray());
            }

            var result = new HashSet<string>(); 
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    var stringBuilder = new StringBuilder();
                    var visited = new HashSet<Tuple<int, int>>();

                    if (!CheckTheTrie(trie, board, i, j, visited, stringBuilder, result))
                    {
                        continue;
                    }
                }
            }

            return result.ToList();
        }

        private bool CheckTheTrie(
            TrieNode trie, 
            char[][] board, 
            int i, 
            int j, 
            HashSet<Tuple<int, int>> visited, 
            StringBuilder wordBuilder,
            HashSet<string> result)
        {
            var nextTrieNode = trie.GetChild(board[i][j]);
            if (nextTrieNode == null)
            {
                return false;
            }

            var currentPosition = new Tuple<int, int>(i, j);
            visited.Add(currentPosition);

            wordBuilder.Append(nextTrieNode.Value);
            if (nextTrieNode.IsAnEndOfTheWord)
            {
                result.Add(wordBuilder.ToString());
                if (nextTrieNode.IsLeaf)
                {
                    visited.Remove(currentPosition);
                    return true;
                }
            }

            if (nextTrieNode.IsLeaf)
            {
                visited.Remove(currentPosition);
                return false;
            }

            var wordFound = false;
            
            if (i > 0 && !visited.Contains(new Tuple<int, int>(i - 1, j)))
            {
                wordFound |= CheckTheTrie(nextTrieNode, board, i - 1, j, visited, new StringBuilder(wordBuilder.ToString()), result);
            }

            if (i < board.Length - 1 && !visited.Contains(new Tuple<int, int>(i + 1, j)))
            {
                wordFound |= CheckTheTrie(nextTrieNode, board, i + 1, j, visited, new StringBuilder(wordBuilder.ToString()), result);
            }

            if (j > 0 && !visited.Contains(new Tuple<int, int>(i, j - 1)))
            {
                wordFound |= CheckTheTrie(nextTrieNode, board, i, j - 1, visited, new StringBuilder(wordBuilder.ToString()), result);
            }

            if (j < board[i].Length - 1 && !visited.Contains(new Tuple<int, int>(i, j + 1)))
            {
                wordFound |= CheckTheTrie(nextTrieNode, board, i, j + 1, visited, new StringBuilder(wordBuilder.ToString()), result);
            }

            visited.Remove(currentPosition);
            return wordFound;
        }
    }
}