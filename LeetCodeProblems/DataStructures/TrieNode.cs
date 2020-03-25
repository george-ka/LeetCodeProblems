using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.DataStructures
{
    public class TrieNode
    {
        public TrieNode()
            : this(default(char))
        {
        }

        private TrieNode(char value, bool isAnEndOfTheWord = false)
        {
            Value = value;
            IsAnEndOfTheWord = isAnEndOfTheWord;            
        }

        public static TrieNode CreateRoot()
        {
            return new TrieNode(default(char));
        }

        public void Add(char[] word)
        {
            if (word == null || word.Length == 0)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (Childen == null)
            {
                Childen = new TrieNode[26];
            }

            var index = CharToIndex(word[0]);
            if (Childen[index] == null)
            {
                Childen[index] = new TrieNode(word[0]);
            }
            
            if (word.Length == 1)
            {
                Childen[index].IsAnEndOfTheWord = true;
            }
            else
            {
                Childen[index].Add(GetShorternedWord(word));
            }
        }

        public TrieNode GetChild(char character)
        {
            if (IsLeaf)
            {
                return null;
            }
            
            return Childen[CharToIndex(character)];
        }

        public static List<string> GetAllWords(TrieNode trie)
        {
            if (trie == null)
            {
                throw new ArgumentNullException(nameof(trie));
            }

            var result = new List<string>();

            for (var i = 0; i < trie.Childen.Length; i++)
            {
                if (trie.Childen[i] != null)
                {
                    trie.Childen[i].BuildWordsList(new StringBuilder(), result);
                }
            }
            
            return result;
        }

        private void BuildWordsList(StringBuilder stringBuilder, List<string> result)
        {
            stringBuilder.Append(Value);
            if (IsAnEndOfTheWord)
            {
                result.Add(stringBuilder.ToString());
            }

            if (Childen == null)
            {
                return;
            }

            for (var i = 0; i < Childen.Length; i++)
            {
                if (Childen[i] != null)
                {
                    Childen[i].BuildWordsList(new StringBuilder(stringBuilder.ToString()), result);
                }
            }
        }

        public bool IsRoot => Value == default(char);

        public char Value {get; private set;}

        public TrieNode[] Childen { get; private set;}

        public bool IsLeaf => Childen == null || Childen.Length == 0;

        public bool IsAnEndOfTheWord {get; private set;}

        private int CharToIndex(char c)
        {
            if (c < 'a' || c > 'z')
            {
                throw new Exception("Characters in word should be between a and z");
            }

            return c - 'a';
        }

        private static char[] GetShorternedWord(char[] word)
        {
            var shorternedWord = new char[word.Length - 1];
            Array.Copy(word, 1, shorternedWord, 0, word.Length - 1);
            return shorternedWord;
        }
    }
}