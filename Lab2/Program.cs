using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Evaluate("5 3 11 + -")); // -9
            Console.WriteLine(Evaluate("5 3 +")); // 8
            Console.WriteLine(Evaluate("7 5 -")); // 2
            Console.WriteLine(Evaluate("5 3 1 + -")); // 1
            Console.WriteLine(Evaluate("15 7 1 1 + - / 3 * 2 1 1 + + -")); // 5
            Console.WriteLine(Evaluate("1 + + -")); // null
            Console.WriteLine(Evaluate("1 -")); // null
            Console.WriteLine(Evaluate("-")); // null
            Console.WriteLine(Evaluate("")); // null
            Console.WriteLine(Evaluate("   ")); // null
            Console.WriteLine(Evaluate("3")); // 3
        }

        public static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                // If opening symbol, then push onto stack
                if (c == '(' || c=='[' || c=='{' || c=='<')
                {
                    stack.Push(c);
                }

                // If closing symbol, then see if it matches the top
                else if (c == ')' || c == ']' || c == '}' || c == '>')
                {
                    if (Matches(stack.Peek(), c))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                // If any other character, then continue/ignore it.
                else
                {
                    //continue;
                }
            }

            // If stack is empty, return true
            // else return false
            if (stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static bool Matches(char open, char close)
        {
            // do the matching
            if ((open == '(' && close == ')') || (open == '[' && close == ']') || (open == '{' && close == '}') || (open == '<' && close == '>'))
            {
                return true;
            }

            return false;
        }

        // Evaluate("5 3 11 + -")	// returns -9
        // 2.4 3.8 / 2.321 +
        
        public static double? Evaluate(string s)
        {
            // parse into tokens (strings)
            string[] tokens = s.Split();

            Stack<double> stack = new Stack<double>();

            // foreach token
            foreach (string token in tokens)
            {
                // If token is a number, push on stack
                if (token != "+" && token != "-" && token != "*" && token != "/" && token != "")
                {
                    stack.Push(double.Parse(token)); // convert from string to double
                }

                // If token is an operator
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    // Pop twice and save both values -- reverse order because order matters
                    if (stack.Count > 1)
                    {
                        double n2 = stack.Pop();
                        double n1 = stack.Pop();

                        // Perform operation on 2 values (in the correct order)
                        double result = DoMath(n1, n2, token);

                        // Push the result on to stack
                        stack.Push(result);
                    }
                    // (if you can't pop twice, then return null)
                    else
                    {
                        return null;
                    }
                }
            }

            if (stack.Count != 1)
            {
                return null;
            }

            return stack.Pop();
        }

        private static double DoMath(double n1, double n2, string operation)
        {
            return operation switch
            {
                "+" => n1 + n2,
                "-" => n1 - n2,
                "*" => n1 * n2,
                "/" => n1 / n2,
                _ => 0,
            };
        }
    }
}
