using System;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Maxim\Desktop\shops.txt";       //Путь к исходному файлу
            string fileoutname = @"C:\Users\Maxim\Desktop\newtext.txt";     //Путь к готовому файлу

            int NumLines = System.IO.File.ReadAllLines(filename).Length;  //Узнаём количество строк в файле

            StreamReader sr = new StreamReader(filename);

            string text = sr.ReadToEnd().Replace("\r\n", " ");
            sr.Close();

            string[] subs = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //Создаём массивы строк, для названия магазина, специфика товара, адрес магазина
            string[] ShopName=new string[NumLines];        //Название магазина
            string[] ShopSpecific=new string[NumLines];    //специфика товара
            string[] AddressType=new string[NumLines];     //тип адреса (улица, проспект)
            string[] AddressName = new string[NumLines];   //тип адреса (Название)
            string[] AddressBuild = new string[NumLines];  //тип строения (дом, здание)
            string[] AddressNum=new string[NumLines];      //номер строения

            string[] ShopAddress=new string[NumLines];   //Полный адрес
            
            Console.WriteLine(text.Length);

            int sn = 0;
            int ss = 0;
            int at = 0;
            int an = 0;
            int ab = 0;
            int adn = 0;

            for (int i = 0; i < subs.Length; i++)
            {
                if ((i % 6 == 0)||(i==0))
                {
                    ShopName[sn++] = subs[i];
                }
                if (((i-1) % 6 == 0) || (i == 1)) 
                {
                    ShopSpecific[ss++]=subs[i];
                }
                if (((i - 2) % 6 == 0) || (i == 2))
                {
                    AddressType[at++]=subs[i];
                }
                if (((i - 3) % 6 == 0) || (i == 3))
                {
                    AddressName[an++]=subs[i];
                }
                if (((i - 4) % 6 == 0) || (i == 4))
                {
                    AddressBuild[ab++]=subs[i];
                }
                if (((i - 5) % 6 == 0) || (i == 5))
                {
                    AddressNum[adn++]=subs[i];
                }
            }

            for (int i = 0; i < NumLines; i++)
            {
                ShopAddress[i] = AddressType[i] + " " + AddressName[i] + " " + AddressBuild[i] + " " + AddressNum[i];
                Console.WriteLine(ShopAddress[i]);
            }

            StreamWriter sw = new StreamWriter(fileoutname);      //Адрес выходного файла
            sw.WriteLine("Специфика"+"\tНаименование"+"\tАдрес");

            List<string> Specific = new List<string>();     //Создаём список специфик

            for (int i = 0; i < NumLines; i++)
            {
                if (!Specific.Contains(ShopSpecific[i]))    //Если специфики ещё нет, то записываем её в файл,
                {
                    Specific.Add(ShopSpecific[i]);
                    sw.WriteLine(ShopSpecific[i]);
                    for (int j = 0; j < ShopSpecific.Length; j++)   //и в цикле пробегаем до конца, записывая данные, сравниявая специфики
                    {
                        if (ShopSpecific[i] == ShopSpecific[j])
                        {
                            sw.WriteLine("\t\t" + ShopName[j] + "\t" + ShopAddress[j]);
                        }
                    }
                }
            }

            sw.Close();
        }
    }
}