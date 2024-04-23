using System.Text.RegularExpressions;

/*
    https://leetcode.com/problems/valid-parentheses/description
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
    determine if the input string is valid.
    An input string is valid if:
      - Open brackets must be closed by the same type of brackets.
      - Open brackets must be closed in the correct order.
      - Every close bracket has a corresponding open bracket of the same type.
*/

namespace CSharpLeetCode.EasyProblems
{
    public class ValidParentheses
    {
        public bool IsValid(string inputString)
        {
            var stack = new Stack<char>();

            foreach (var ch in inputString)
            {
                if (IsOpeningParenthesis(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count == 0 || !IsMatchingParenthesis(stack.Pop(), ch))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        private bool IsMatchingParenthesis(char opening, char closing)
        {
            return (opening == '{' && closing == '}')
                || (opening == '[' && closing == ']')
                || (opening == '(' && closing == ')');
        }
        private bool IsOpeningParenthesis(char ch) => Regex.IsMatch(ch.ToString(), "[{([]");
    }
}
