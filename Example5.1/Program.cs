/*Вывести все слова сообщения, которые начинаются и
заканчиваются на одну и ту же букву.*/

using System;
using System.Text;

namespace Example5._1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter string: ");
			StringBuilder a = new StringBuilder(Console.ReadLine());
			Console.WriteLine("Origin string: " + a);
			for (int i = 0; i < a.Length;)
				if (char.IsPunctuation(a[i])) a.Remove(i, 1);
				else ++i;
			string str = a.ToString();
			string[] s = str.Split(' ');
			Console.WriteLine("Words: ");
			for (int i = 0; i < s.Length; ++i)
				if (s[i][0] == s[i][s[i].Length - 1]) Console.WriteLine(s[i]);
		}
	}
}
