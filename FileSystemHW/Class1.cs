using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemHW
{
    public class Class1
    {
        static void Main(string[] args)
        {
            string path = @"C:\Visual Studio 2019\Code Snippets\Visual C#\My Code Snippets\";
            string[] words;
            List<int> numbers = new List<int>();
            using (StreamReader stream = new StreamReader(path + "input.txt"))
            {
                string text = stream.ReadLine();
                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            bool isInt = false;
            foreach (string item in words)
            {
                int number;
                isInt = int.TryParse(item, out number);
                if (isInt)
                    numbers.Add(number);
            }
            int result = numbers[0] + numbers[1];
            Console.WriteLine(numbers[0] + " + " + numbers[1] + " = " + result);
            using (FileStream stream = new FileStream(path + "output.txt", FileMode.Create))
            {
                string data = result.ToString();
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);
            }
            Console.ReadLine();
        }
    }
}
