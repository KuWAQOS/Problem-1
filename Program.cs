using System;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(", ");              //Массив строк состоящий из слов
            
            int K = 0;

            for (int i = 0; i < words.Length; i++)          //Определяем длину самого большого слова
            {
                if (words[i].Length>K)
                {
                    K = words[i].Length;
                }
                if (i==words.Length-1)                      //Вычитаем точку из значения длины последнего слова
                {
                    K -= 1;
                }
            }

            char[] symb;                                    //Массив слов

            int s;

            for (int i = 0; i < words.Length; i++)
            {
                symb = new char[words[i].Length];
                for (int j = 0; j < words[i].Length; j++) 
                {
                    symb = words[i].ToCharArray();
                }
                for (int j = 0; j < symb.Length; j++)
                {
                    if (((int)symb[j] != 90) & ((int)symb[j] != 122) &((int)symb[j]!=46))   //Заменяем все символы, кроме Z и z
                    {
                        s = (int)symb[j];
                        symb[j] = (char)++s;
                    }
                    else if ((int)symb[j] == 90)                        //Заменяем Z на А
                    {
                        symb[j] = 'A';
                    }
                    else if((int)symb[j] == 122)
                    {
                        symb[j] = 'a';                                  //Заменяем z на а
                    }

                    Console.Write(symb[j]);
                }
                if (i != words.Length-1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("\nКоличество слов в самом длинном слове: " + K);
        }
    }
}