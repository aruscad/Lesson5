/*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.*/

using System;
using System.IO;

namespace HomeTask5._4
{
	class School
	{
		string name;
		string surname;
		double average;
		static int count;
		public School()
		{
			name = "";
			surname = "";
			average = 0;
		}
		public School(string name, string surname, double average)
		{
			this.name = name;
			this.surname = surname;
			this.average = average;
		}
		public static int Count
		{
			get { return count; }
			set { count = value; }
		}
		public string GetName
		{
			get { return name; }
		}
		public string GetSurname
		{
			get { return surname; }
		}
		public double GetAverage
		{
			get { return average; }
		}
		public static void Print(School[]students)
		{
			for (int i = 0; i < count; ++i)
			Console.WriteLine($"{i}:  surname: {students[i].GetSurname}, name: {students[i].GetName}, average: {students[i].GetAverage}");
		}
		public static void Print(School student)
		{
			Console.WriteLine($"surname: {student.GetSurname}, name: {student.GetName}, average: {student.GetAverage}");
		}
		public static void Worst(School[] students1)
		{
			//сортировка массива студентов
			School temp = new School();
			for (int i = 0; i < count - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < count; j++)
				{
					if (students1[j].average < students1[min].average)
					{
						min = j;
					}
				}
				temp = students1[i];
				students1[i] = students1[min];
				students1[min] = temp;
			}
			
			//выбор 3 худших средних значений
			double[] worst = { students1[0].average, students1[0].average, students1[0].average };
			int k = 1;
			int l = 1;
			for (int i = 0; i < count; ++i)
			{
				if (worst[k] == students1[i].average) continue;
				worst[k] = students1[i].average;
				k++;
				if (k >= 3) break;
			}
	
			Console.WriteLine("The worst average marks:");
			
			for (int i = 0; i < count; ++i) 
			for(int j = 0; j < 3; ++j)
			{
				if (students1[i].average == worst[j]) Print(students1[i]);
			}
			
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string[] ss = File.ReadAllLines("data.txt");
			int count = Int32.Parse(ss[0]);
			School[] students = new School[count];
			School.Count = count;

			for (int i = 0; i < count; ++i)
			{
				string[] sss = ss[i + 1].Split(' ');
				double ave = (double)(Double.Parse(sss[2]) + Double.Parse(sss[3]) + Double.Parse(sss[4])) / 3;
				students[i] = new School(sss[1], sss[0], ave);
			}
			School.Print(students);
			Console.WriteLine();
			School.Worst(students);
		}
	}
}