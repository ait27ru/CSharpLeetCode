/*
    https://leetcode.com/problems/add-two-numbers/description/
    You are given two non-empty linked lists representing two non-negative integers.
    The digits are stored in reverse order, and each of their nodes contains a single digit.
    Add the two numbers and return the sum as a linked list.
    You may assume the two numbers do not contain any leading zero, except the number 0 itself.
*/

namespace CSharpLeetCode.MediumProblems
{
    public class AddTwoNumbersSolution
    {
        public static ListNode? AddTwoNumbers(ListNode? list1, ListNode? list2)
        {
            var root = new ListNode(0);
            var curr = root;
            var carry = 0;

            while (list1 != null || list2 != null || carry != 0)
            {
                var val1 = list1?.Value ?? 0;
                var val2 = list2?.Value ?? 0;

                // Work out the new digit
                var sum = val1 + val2 + carry;
                carry = sum / 10;
                sum %= 10;

                // Create a new node
                curr.Next = new ListNode(sum);

                // Update pointers
                curr = curr.Next;
                list1 = list1?.Next;
                list2 = list2?.Next;
            }
            return root.Next;
        }
    }

    public class ListNode
    {
        public ListNode(int value) => Value = value;

        public static ListNode? createOf(params int[] values)
        {
            ListNode? first = null;
            ListNode? current = null;

            foreach (int value in values)
            {
                if (first == null || current == null)
                {
                    first = new ListNode(value);
                    current = first;
                }
                else
                {
                    current.Next = new ListNode(value);
                    current = current.Next;
                }
            }
            return first;
        }

        public override string? ToString()
        {
            if (Next == null)
                return $"{Value}";
            else
                return $"{Value} -> {Next}";
        }

        public int Value { get; set; }
        public ListNode? Next { get; set; }
    }
}
