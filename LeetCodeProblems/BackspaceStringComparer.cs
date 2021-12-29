using System;
using System.Text;

namespace LeetCodeChallenges
{
    ///
    /// 844. Backspace String Compare
    /// https://leetcode.com/problems/backspace-string-compare/
    /// 
    /// Given two strings s and t, return true if they are equal when 
    /// both are typed into empty text editors. '#' means a backspace 
    /// character.
    /// Note that after backspacing an empty text, the text will 
    /// continue empty.
    public class BackspaceStringComparer
    {
        public bool BackspaceCompare(string s, string t) 
        {
            if (s == t)
            {
                return true;
            }

            if (s == null || t == null)
            {
                return false;
            }

            /// This solution builds two strings independently and then compares.
            // return BuildString(s) == BuildString(t);
            
            /// A better solution is to go in reverse order and fail fast if strings 
            /// are not equal
            var i = s.Length;
            var j = t.Length;

            char currentS = (char)0;
            char currentT = (char)0;

            while (i >= 0 && j >= 0)
            {
                if (i >= 0)
                {
                    i--;
                }
                
                if (j >= 0)
                {
                    j--;
                }

                currentS = GetNextChar(s, ref i);
                Console.WriteLine($"Current S = {currentS}, i={i}");
                currentT = GetNextChar(t, ref j);
                Console.WriteLine($"Current T = {currentT}, j={j}");

                if (currentS != currentT)
                {
                    return false;
                }
            }

            Console.WriteLine($"i = {i}, j = {j}");
            if (j != i)
            {
                if (i > 0 && s[i] == '#')
                {
                    currentS = GetNextChar(s, ref i);
                    if (currentS == (char)0)
                    {
                        return true;
                    }
                }

                if (j > 0 && t[j] == '#')
                {
                    currentT = GetNextChar(t, ref j);
                    Console.WriteLine($"Final char {currentT}");
                    if (currentT == (char)0)
                    {
                        return true;
                    }
                }
                
                return false; 
            }

            return true;
        }

        private char GetNextChar(string s, ref int i)
        {
            if (i < 0)
            {
                return (char)0;
            }
            
            var backspaces = 0;
            do
            {
                while (i >= 0 && s[i] == '#')
                {
                    backspaces++;
                    i--;
                }

                while (backspaces > 0 && i >= 0)
                {
                    if (i >= 0 && s[i] == '#')
                    {
                        backspaces++;
                    }
                    else if (i >= 0 && s[i] != '#')
                    {
                        backspaces--;
                    }

                    i--;
                }
            } 
            while (i >= 0 && s[i] == '#');

            return i >= 0 ? s[i] : (char)0;
        }

        private string BuildString(string s)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Length --;
                    }
                }
                else
                {
                    stringBuilder.Append(s[i]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}