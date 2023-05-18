/* C#, lesson_43  13.05.2023
 * 
Task № 1:
Файл містить 100000 цілих чисел. Додаток має проаналізувати файл і відобразити статистику по ньому: 
1.	Кількість додатних чисел. 
2.	Кількість від'ємних чисел. 
3.	Кількість двозначних чисел. 
4.	Кількість п'ятизначних чисел. Крім того, додаток має створити файли з цими числами (додатні, від'ємні і т. д.).
*/
//--------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

namespace Lesson_43_task_1
{
    //--------------------------------------------------------------------------------------------------------
    class Program_1
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_43 \"task 1\"\n");

            int positive = 0, negative = 0, doubleDigit = 0, fifthDigit = 0;
            List <int> arr = new List<int> ();
            string filePath = "Random_numbers.txt";
            using (StreamReader myFile = new StreamReader(filePath))
            {
                while (!myFile.EndOfStream)
                {
                    string temp = myFile.ReadLine();
                    arr.Add(Convert.ToInt32(temp));
                }

                foreach (var index in arr)
                {
                    if (index > 0)
                        positive++;
                    if (index < 0)
                        negative++;
                    if ((index >= 10 && index < 100) || (index > -100 && index <= -10))
                        doubleDigit++;
                    if ((index >= 10000 && index < 100000) || (index > -100000 && index <= -10000))
                        fifthDigit++;
                }

                Console.WriteLine($"Count positive numbers: {positive}");
                Console.WriteLine($"Count negative numbers: {negative}");
                Console.WriteLine($"Count two-digits numbers: {doubleDigit}");
                Console.WriteLine($"Count five-digits numbers: {fifthDigit}");

            }

            filePath = "Results.txt";
            using (StreamWriter myFile = new StreamWriter(filePath))
            {
                myFile.WriteLine($"Count positive numbers: {positive}");
                myFile.WriteLine($"Count negative numbers: {negative}");
                myFile.WriteLine($"Count two-digits numbers: {doubleDigit}");
                myFile.WriteLine($"Count five-digits numbers: {fifthDigit}");
            }

            Console.WriteLine("\n\nThe results also were written to the file \'Results.txt\'\n\n");
            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
