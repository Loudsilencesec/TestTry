using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaximTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string notvalid;
            while (true)
            {

                input = Console.ReadLine();
                notvalid = task2(input);


                if (notvalid.Length == 0)
                {
                    string result = task1(input);
                    Console.WriteLine(result);
                    task3(result);


                    string processedInput = task1(input);
                    Console.WriteLine(task4(result));
                    string sortstr;
                    Console.WriteLine(task6(result));
                    Console.WriteLine("Выберите сортировку \n 1. Быстрая \n 2. Деревом ");


                    switch (Console.ReadLine())
                    {
                        case "1":
                            sortstr = QuickSort(result);
                            break;
                        case "2":
                            sortstr = TreeSort(result);
                            break;
                        default:
                            sortstr = "Сортировка не указана";
                            break;
                    }

                    Console.WriteLine(sortstr);

                }
                else
                {

                    Console.WriteLine("Вы используете недопустимые символы: " + notvalid);

                }

            }

        }

        static string task1(string str)
        {

            if (str.Length % 2 == 0)
            {
                string half1 = str.Substring(0, str.Length / 2);
                string life2 = str.Substring(str.Length / 2);

                half1 = new string(half1.Reverse().ToArray());
                life2 = new string(life2.Reverse().ToArray());

                return half1 + life2;
            }

            string reversstr = new string(str.Reverse().ToArray());

            return reversstr + str;



        }

        static string task2(string str)
        {
            string validsymbol = "abcdefghijklmnopqrstuvwxyz ";
            string notvalidsymbol = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (!validsymbol.Contains(str[i]))
                {
                    notvalidsymbol += str[i];


                }

            }

            return notvalidsymbol;
        }
        static void task3(string str)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }

            Console.WriteLine("Количество повторений каждого символа в строке:");
            foreach (KeyValuePair<char, int> kvp in charCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }



        static string task4(string str)
        {
            string vowels = "aeiouy";
            string maxSubstr = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i]))
                {
                    for (int j = str.Length - 1; j > i; j--)
                    {
                        if (vowels.Contains(str[j]))
                        {
                            string substr = str.Substring(i, j - i + 1);
                            if (substr.Length > maxSubstr.Length)
                            {
                                maxSubstr = substr;
                            }
                            i = j;
                            break;
                        }
                    }
                }
            }

            return maxSubstr;
        }

        static string QuickSort(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char pivot = str[str.Length / 2];
            string left = "";
            string middle = "";
            string right = "";

            foreach (char c in str)
            {
                if (c < pivot)
                {
                    left += c;
                }
                else if (c == pivot)
                {
                    middle += c;
                }
                else
                {
                    right += c;
                }
            }

            return QuickSort(left) + middle + QuickSort(right);
        }

        class TreeNode
        {
            public char Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(char value)
            {
                Value = value;
            }

            public void Insert(char value)
            {
                if (value < Value)
                {
                    if (Left == null)
                    {
                        Left = new TreeNode(value);
                    }
                    else
                    {
                        Left.Insert(value);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new TreeNode(value);
                    }
                    else
                    {
                        Right.Insert(value);
                    }
                }
            }

            public void Traverse(StringBuilder sb)
            {
                if (Left != null)
                {
                    Left.Traverse(sb);
                }

                sb.Append(Value);

                if (Right != null)
                {
                    Right.Traverse(sb);
                }
            }
        }

        static string TreeSort(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            TreeNode root = new TreeNode(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                root.Insert(str[i]);
            }

            StringBuilder sb = new StringBuilder();
            root.Traverse(sb);

            return sb.ToString();
        }

        static string task6(string inputString)
        {

            int randomNumber;
            int strLength = inputString.Length - 1;

            try
            {
                WebClient client = new WebClient();
                string url = "http://www.randomnumberapi.com/api/v1.0/randomnumber?max=" + strLength;
                string response = client.DownloadString(url);
                randomNumber = int.Parse(response.Trim('[', ']'));
            }
            catch (WebException ex)
            {
                Console.WriteLine("Произошла ошибка при получении числа с API! Генерирую число локально");
                Random random = new Random();
                randomNumber = random.Next(strLength);
            }

            Console.WriteLine("случайное число - " + (randomNumber + 1));

            return inputString.Remove(randomNumber, 1);
        }
    }
}
