using System;
using System.Collections.Generic;
using LeetCodeChallenges.DataStructures;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class WordSearchTests
    {
        [Test]
        public void TrieTest1()
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
                Assert.IsTrue(extractedWords.Contains(word), $"Word {word} wasn't extracted from trie");
            }
        }

        [Test]
        public void WordSearchTest2()
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
            foreach (var item in foundWords)
            {
                Console.WriteLine(item);
            }

            Assert.AreEqual(2, foundWords.Count);
            Assert.AreEqual("oath", foundWords[0]);
            Assert.AreEqual("eat", foundWords[1]);
        }
    }
}