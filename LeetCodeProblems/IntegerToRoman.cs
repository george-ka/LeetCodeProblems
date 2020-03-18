using System;
using System.Text;

namespace LeetCodeChallenges
{
	///
	/// 12. Integer to Roman
	/// https://leetcode.com/problems/integer-to-roman/
	///
    public class IntegerToRoman
    {
        public string IntToRoman(int num) 
		{
			if (num > 9999 || num <= 0)
			{
				throw new ArgumentException("num should be greater than 0 and less than 9999");
			}

			var remainer = num;
			var result = new StringBuilder();

			if (num >= 1000)
			{
				int thousands = remainer / 1000;
				remainer -=  thousands * 1000;

				for (var i = 0; i < thousands; i++)
				{
					result.Append("M");
				}
			}

			if (remainer >= 900)
			{
				result.Append("CM");
				remainer -= 900;
			}

			if (remainer >= 500)
			{
				result.Append("D");
				remainer -= 500;
			}

			if (remainer >= 400)
			{
				result.Append("CD");
				remainer -= 400;
			}

			if (remainer >= 100)
			{
				int hundreds = remainer / 100;
				remainer -= hundreds * 100;

				for (var i = 0; i < hundreds; i++)
				{
					result.Append("C");
				}
			}

			if (remainer >= 90)
			{
				result.Append("XC");
				remainer -= 90;
			}

			if (remainer >= 50)
			{
				result.Append("L");
				remainer -= 50;
			}

			if (remainer >= 40)
			{
				result.Append("XL");
				remainer -= 40;
			}

			if (remainer >= 10)
			{
				int tens = remainer / 10;
				remainer -= tens * 10;

				for (var i = 0; i < tens; i++)
				{
					result.Append("X");
				}
			}

			if (remainer >= 9)
			{
				result.Append("IX");
				remainer -= 9;
			}

			if (remainer >= 5)
			{
				result.Append("V");
				remainer -= 5;
			}

			if (remainer >= 4)
			{
				result.Append("IV");
				remainer -= 4;
			}

			for (var i = 0; i < remainer; i++)
			{
				result.Append("I");
			}

			return result.ToString();
		}
    }
}