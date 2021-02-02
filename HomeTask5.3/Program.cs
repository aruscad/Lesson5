/**Для двух строк написать метод, определяющий, является ли одна строка перестановкой
другой.
Например:
badc являются перестановкой abcd .*/

using System;

namespace HomeTask5._3
{
	class Program
	{
		static string Sort(string s)
		{
			char[] res = s.ToCharArray();
			char temp = s[0];
			for(int i = 0; i < s.Length-1; ++i)
			{
				if (res[i] > res[i+1])
				{
					temp = res[i];
					res[i] = res[i + 1];
					res[i + 1] = temp;
					
				}
			}
			string ress = new string(res);
			return ress;
		}
		static bool Check(string s1, string s2)
		{
			if(s1.Length!=s2.Length) 
				return false;

			string Sorts1 = Sort(s1);
			string Sorts2 = Sort(s2);
			for(int i = 0; i < s1.Length; ++i)
			{
				if (Sorts1[i] != Sorts2[i]) return false;
			}
			return true;
		}
		static void Main(string[] args)
		{
			Console.WriteLine(Check("badc", "abcd"));
		}
	}
}
