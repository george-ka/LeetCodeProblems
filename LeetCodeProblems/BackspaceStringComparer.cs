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
            return BuildString(s) == BuildString(t);
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