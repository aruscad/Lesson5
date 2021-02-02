/*Разработать статический класс Message, содержащий следующие статические методы для
обработки текста:
+а) Вывести только те слова сообщения, которые содержат не более n букв.
+б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
+в) Найти самое длинное слово сообщения.
+г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в
него передается массив слов и текст, в качестве результата метод возвращает сколько раз
каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.*/

using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask5._2
{
	public static class Message
	{
		public static void Analis(string[] words, string message)
		{
			char[] dev = { ' ', '.', ',', '!', '?' };
			string[] s = message.Split(dev);
			int n = 0;

			Dictionary<string, int> count = new Dictionary<string,int> (words.Length);
			for(int i = 0; i < words.Length; ++i)
			{
				count.Add(words[i], 0);
			}
			for (int i = 0; i < words.Length; ++i)
			for (int j = 0; j < s.Length; ++j)
				if(words[i]==s[j])
				{
						count[words[i]] += 1;
				}
			foreach(string c in count.Keys)
			Console.WriteLine($"{c}:  {count[c]}");
		}
		public static StringBuilder LongString(string message)
		{
			StringBuilder sb = new StringBuilder();
			char[] dev = { ' ', '.', ',', '!', '?' };
			string[] s = message.Split(dev);

			int max = s[0].Length;
			for (int i = 0; i < s.Length; ++i)
			{
				if (max < s[i].Length)
				{
					max = s[i].Length;
				}
			}
			
			for(int j = 0; j < s.Length; ++j)
			{
				if (s[j].Length == max) sb.Append(s[j]+" ");
			}

			return sb;
		}
		public static string LongWord(string message)
		{
			char[] dev = { ' ', '.', ',', '!', '?' };
			string[] s = message.Split(dev);

			int max = s[0].Length, index=0;
			for(int i = 0; i < s.Length; ++i)
			{
				if (max < s[i].Length)
				{
					max = s[i].Length;
					index = i;
				}
			}

			return s[index];
		}
		public static string Delete(string message, char a)
		{
			char[] dev = { ' ', '.', ',', '!', '?' };
			string[] s = message.Split(dev);

			string[] temp=new string[s.Length];
			for (int i = 0; i < s.Length; ++i)
			{
				if (s[i][s.Length-1] != a)
					temp[i] = s[i];
			}
			return string.Join(" ",temp);

		}
		public static void WriteN(string message, int n)
		{
			char[] dev = { ' ', '.', ',', '!', '?' };
			string[] s = message.Split(dev);
			for(int i = 0; i < s.Length; ++i)
			{
				if (s[i].Length <= n) Console.WriteLine(s[i]);
			}
			
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string sentence = "Hello gooooooos gooppooos woes gotroouys Hello Hello";
			//			Message.WriteN(sentence, 5);
			//			Console.WriteLine(Message.Delete(sentence,'s'));
			//			Console.WriteLine(Message.LongString(sentence));
			string[] words = { "Hello", "woes" };
			Message.Analis(words, sentence);

//			Console.ReadKey();
		}
	}
}
