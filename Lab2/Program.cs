using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsBalanced("{ int a = new int[ ] ( ( ) ) }")); // true
            Console.WriteLine(IsBalanced("{ [ ] ) ) ( ( }")); // false
            Console.WriteLine(IsBalanced("int a = 5")); // true

            //Evaluate("5 3 11 + -");
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
                // If token is an integer
                // Push on stack

                // If token is an operator
                    // Pop twice and save both values
                    // (if you can't pop twice, then return null)
                    // Perform operation on 2 values (in the correct order)
                    // Push the result on to stack


            if( stack.Count != 1)
            {
                return null;
            }

            return stack.Pop();
        }



    }
}
