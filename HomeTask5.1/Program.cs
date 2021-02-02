/*Создать программу, которая будет проверять корректность ввода логина. Корректным
логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита
или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.*/

using System;
using System.Text.RegularExpressions;

namespace HomeTask5._1
{
	class Program
	{
		static bool Check(string login)
		{
			Regex reg = new Regex("/D/w{1,9}]");
			return reg.IsMatch(login);
		}
		static bool CheckWithoutRegular(string login)
		{
			string numbers = "0123456789";

			if (login.Length < 2 || login.Length > 10) { return false; }

			for(int i=0;i<numbers.Length;i++)
			if (login[0] == numbers[i])
				{
					return false;
				}
			return true;
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Enter login: ");
			Console.WriteLine(Check(Console.ReadLine() ));
			Console.WriteLine(CheckWithoutRegular(Console.ReadLine()));
		}
	}
}
