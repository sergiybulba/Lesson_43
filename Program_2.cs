/* C#, lesson_43  13.05.2023	
 * 	
Task № 2:
Користувач вводить з клавіатури слово для пошуку у файлі, шлях до файлу і слово для заміни. 
Додаток має змінити усі входження шуканого слова на слово для заміни. Статистику роботи додатку виведіть на екран.
*/
//--------------------------------------------------------------------------------------------------------	
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

namespace Lesson_43_task_2
{
    //--------------------------------------------------------------------------------------------------------
    class Program_2
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_43 \"task 2\"\n");

            string filePath = "text.txt";
            int count_change = 0;

            Console.Write("Enter the word to search for: ");
            string search_word = Console.ReadLine();
            Console.Write("Enter the word to change for: ");
            string change_word = Console.ReadLine();

            string text = File.ReadAllText(filePath);

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower().Contains(search_word.ToLower()))
                {
                    if (Char.IsUpper(words[i], words[i].ToLower().IndexOf(search_word.ToLower())))
                    {
                        string temp1 = search_word[0].ToString().ToUpper() + search_word.Substring(1);
                        string temp2 = change_word[0].ToString().ToUpper() + change_word.Substring(1);
                        words[i] = words[i].Replace(temp1, temp2);
                    }
                    else
                    {
                        words[i] = words[i].Replace(search_word, change_word);
                    }
                    count_change++;
                }
            }

            filePath = "edit_text.txt";
            text = "";

            foreach (var word in words)
            {
                text = text + " " + word;
            }

            File.WriteAllText(filePath, text);

            Console.WriteLine($"Count changes of the words: {count_change}");

            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
