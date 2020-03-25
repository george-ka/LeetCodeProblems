using System;
using System.Collections.Generic;
using LeetCodeChallenges.DataStructures;

namespace LeetCodeChallenges
{
    public class WordSearchTests
    {
        public static void TrieTest()
        {
            var trie = new TrieNode();
            var words = new List<string> 
            {
                "word", "hello", "weird", "wordo", "hell",
                "oath","pea","eat","rain"
            };

            foreach (var word in words)
            {
                trie.Add(word.ToCharArray());
            }

            var extractedWords = TrieNode.GetAllWords(trie);
            foreach (var word in words)
            {
                if (!extractedWords.Contains(word))
                {
                    Console.WriteLine($"Word {word} wasn't extracted from trie");
                }
            }
        }

        public static void Test()
        {
            var board = new char[][] {
                new char[] {'o','a','a','n'},
                new char[] {'e','t','a','e'},
                new char[] {'i','h','k','r'},
                new char[] {'i','f','l','v'}
            };

            var words = new [] {"oath","pea","eat","rain"};

            var search = new WordSearch();
            var foundWords = search.FindWords(board, words);
        }
    }
}