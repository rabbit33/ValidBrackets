using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ValidParantheses
{
    class Program
    {
        //https://www.hackerrank.com/challenges/balanced-brackets/problem

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader reader = new StreamReader(@"test.txt"))
            {
                int testCases = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < testCases; i++)
                {
                    string s = reader.ReadLine();
                    result.AppendLine(isBalanced(s));
                }
            }

            using (StreamWriter writer = new StreamWriter("results.txt"))
            {
                writer.Write(result);
            }

            Console.ReadLine();
        }

        // Complete the isBalanced function below.
        static string isBalanced(string s)
        {
            string openingBrackets = "([{";
            string closingBrackets = ")]}";

            Dictionary<char,char> dict = new Dictionary<char, char>();
            dict.Add('(', ')');
            dict.Add('[', ']');
            dict.Add('{', '}');

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (openingBrackets.Contains(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (closingBrackets.Contains(s[i]))
                    {
                        if (stack.Count == 0)
                        {
                            return "NO";
                        }
                        else
                        {
                            var value = stack.Pop();
                            if (dict[value] == s[i])
                            {
                                continue;
                            }
                            return "NO";
                        }
                    }
                }
            }

            return stack.Count > 0 ? "NO" : "YES";
        }
    }

}
