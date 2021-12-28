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
            var i = 0;
            var j = 0;
            var curS = 'a';
            var curT = 'a';

            while (i < s.Length && j < t.Length)
            {
                // ##1##
                // 123
                // 123######
                var curI = i;
                while (s[i] == '#')
                {
                    curI--;
                    i++;
                }

                if (curS != curT)
                {
                    return false;
                }

                i++;
                j++;
            }

            return true;
        }

        private string BuildString(string s)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {

            }

            return stringBuilder.ToString();
        }
    }
}