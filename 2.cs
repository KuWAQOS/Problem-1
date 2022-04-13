using System;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Maxim\Desktop\TEXT.txt";       //Путь к текстовому документу
            StreamReader sr = new StreamReader(filename);
            string text = sr.ReadToEnd();
            sr.Close();

            char[] separators = new char[] { ' ', ',', '.', '!', '?', '!', '-', '&', '"', ':',';','<','>' };     //Убираем из текста знаки препинания

            string[] subs = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            char[] word;

            List<char> letters= new List<char> {'a','A','e','E','i','I','o','O','u','U','y','Y' };

            for (int i = 0; i < subs.Length; i++)
            {
                word = new char[subs[i].Length-1];
                word = subs[i].ToCharArray();

                if (letters.Contains(word[0]) & letters.Contains(word[word.Length - 1]))       //Проверка на гласность
                {
                    Console.WriteLine(subs[i]);                         //Вывод всех подходящих слов
                }
            }
        }
    }
}