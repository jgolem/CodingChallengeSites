using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LeetCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRemoveElement_Click(object sender, EventArgs e)
        {
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;
            int result = RemoveElement(nums, val);
        }

        private int RemoveElement(int[] nums, int val)
        {
            if (nums == null) return 0;
            int goodValues = 0;
            int lastTargetIndex = nums.Length;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == val)
                {
                    // swap this with the last good value
                    int temp = nums[--lastTargetIndex];
                    nums[lastTargetIndex] = nums[i];
                    nums[i] = temp;
                }
                else
                {
                    goodValues++;
                }
            }

            return goodValues;
        }

        private void btnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int result = RemoveDuplicates(nums);
        }

        private int RemoveDuplicates(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            int lastValidIndex = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[lastValidIndex])
                {
                    nums[++lastValidIndex] = nums[i];
                }
            }

            return lastValidIndex + 1;
        }

        private void btnReverseInteger_Click(object sender, EventArgs e)
        {
            int result = Reverse(-2147483648);
        }

        private int Reverse(int x)
        {
            char[] numAsChar = x.ToString().ToCharArray(0, x.ToString().Length);

            int i = 0;

            if (numAsChar[0] == '-')
            {
                i = 1;
            }

            for (int j = numAsChar.Length - 1; i <= j; i++, j--)
            {
                swap(numAsChar, i, j);
            }

            string reverseAsString = new string(numAsChar);
            long numberInReverse = Convert.ToInt64(reverseAsString);
            if (numberInReverse > Int32.MaxValue || numberInReverse < Int32.MinValue) return 0;

            return (int)numberInReverse;
        }

        private void swap(char[] array, int a, int b)
        {
            char temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        private void btnAddTwoNumbers_Click(object sender, EventArgs e)
        {
            ListNode l1Head = new ListNode(2);
            l1Head.next = new ListNode(4);
            l1Head.next.next = new ListNode(3);

            ListNode l2Head = new ListNode(5);
            l2Head.next = new ListNode(6);
            l2Head.next.next = new ListNode(4);
            AddTwoNumbers(l1Head, l2Head);
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int sum = l1.val + l2.val;
            ListNode l1CurrentNode = l1.next;
            ListNode l2CurrentNode = l2.next;
            ListNode ResultRoot = new ListNode(sum % 10);
            ListNode ResultCurrentNode = ResultRoot;

            while (l1CurrentNode != null || l2CurrentNode != null)
            {
                bool hasRemainder = sum >= 10;
                if (hasRemainder)
                {
                    sum = 1;
                }
                else
                {
                    sum = 0;
                }

                if (l1CurrentNode != null)
                {
                    sum += l1CurrentNode.val;
                    l1CurrentNode = l1CurrentNode.next;
                }

                if (l2CurrentNode != null)
                {
                    sum += l2CurrentNode.val;
                    l2CurrentNode = l2CurrentNode.next;
                }

                ResultCurrentNode.next = new ListNode(sum % 10);
                ResultCurrentNode = ResultCurrentNode.next;
            }

            if (sum >= 10)
            {
                ResultCurrentNode.next = new ListNode(1);
            }

            return ResultRoot;
        }

        private Stack PushToStack(ListNode listNode)
        {
            Stack stack = new Stack();

            ListNode currentNode = listNode;

            while (currentNode != null)
            {
                stack.Push(currentNode.val);
                currentNode = currentNode.next;
            }

            return stack;
        }

        private long CreateNumFromStack(Stack stack)
        {
            string num = string.Empty;

            while (stack.Count > 0)
            {
                num += stack.Pop();
            }

            return Convert.ToInt64(num);
        }

        private Stack CreateStackFromNum(long num)
        {
            Stack stack = new Stack();

            foreach (char character in num.ToString())
            {
                stack.Push(character);
            }

            return stack;
        }

        private ListNode CreateListNodeFromStack(Stack stack)
        {
            ListNode head = new ListNode(Convert.ToInt32(stack.Pop().ToString()));
            ListNode currentNode = head;
            while (stack.Count > 0)
            {
                currentNode.next = new ListNode(Convert.ToInt32(stack.Pop().ToString()));
                currentNode = currentNode.next;
            }

            return head;
        }

        private void btnDefangIp_Click(object sender, EventArgs e)
        {
            string output = DefangIPaddr2("1.112.1.231");
        }
        public string DefangIPaddr(string address)
        {
            string output = string.Empty;

            foreach (var thisChar in address)
            {
                if (thisChar == '.')
                {
                    output += "[.]";
                }
                else
                {
                    output += thisChar;
                }
            }

            return output;
        }
        public string DefangIPaddr2(string address)
        {
            string output = address[0].ToString();

            for (var index = 1; index < address.Length; index++)
            {
                char thisChar = address[index];
                if (thisChar == '.')
                {
                    output += "[.]";
                    // next will be a number so go ahead and add that
                    index++;
                    output += address[index];
                }
                else
                {
                    output += thisChar;
                }
            }

            return output;
        }

        private void btnValidPalindrone_Click(object sender, EventArgs e)
        {
            string isThisAPalindrone = "0P";
            bool isPalindrome = IsPalindrome(isThisAPalindrone);
        }
        public bool IsPalindrome(string stringToCheck)
        {
            bool result = false;

            stringToCheck = stringToCheck.ToLower();

            // strip all but characters and numbers

            int i = 0;
            int j = stringToCheck.Length - 1;

            while (i < j)
            {
                while (!IsValidChar(stringToCheck[i]))
                {
                    i++;
                    if (i >= j) return true;
                }
                while (!IsValidChar(stringToCheck[j]))
                {
                    j--;
                    if (j <= i) return true;
                }

                if (stringToCheck[i] != stringToCheck[j]) return false;
                i++;
                j--;
            }

            return true;
        }

        private bool IsValidChar(char thisChar)
        {
            if (thisChar >= 'a' && thisChar <= 'z')
            {
                return true;
            }

            if (thisChar >= '0' && thisChar <= '9')
            {
                return true;
            }

            return false;
        }

        private void btnHappyNumbers_Click(object sender, EventArgs e)
        {
            bool isHappy = IsHappy(19);
        }
        public bool IsHappy(int n)
        {
            List<int> previousValues = new List<int>();
            int sum = n;
            while (true)
            {
                sum = SquareDigits(sum);
                if (sum == 1) return true;
                if (previousValues.Contains(sum)) return false;
                previousValues.Add(sum);
            }
        }

        private int SquareDigits(int n)
        {
            string asString = n.ToString();
            int sum = 0;
            foreach (char c in asString)
            {
                int num = Convert.ToInt32(c.ToString());
                sum += num * num;
            }

            return sum;
        }

        private void btnGuessingGame_Click(object sender, EventArgs e)
        {
            guessNumber(1);
        }
        int guessNumber(int n)
        {

            bool keepGuessing = true;
            int thisGuess = n / 2;
            int change = n / 2;

            while (keepGuessing)
            {
                int result = guess(thisGuess);
                change = change / 2;
                if (result == 0) return thisGuess;
                if (result == 1)
                {
                    if (change == 0)
                    {
                        thisGuess++;
                        change = 1;
                    }
                    else
                    {
                        thisGuess = thisGuess + change;
                    }
                }
                if (result == -1)
                {
                    if (change == 0)
                    {
                        thisGuess--;
                        change = 1;
                    }
                    else
                    {
                        thisGuess = thisGuess - change;
                    }
                }
            }
            return thisGuess;
        }

        int _guess = 1;

        private int guess(int num)
        {
            if (num < _guess) return 1;
            if (num > _guess) return -1;
            return 0;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
     }
}
