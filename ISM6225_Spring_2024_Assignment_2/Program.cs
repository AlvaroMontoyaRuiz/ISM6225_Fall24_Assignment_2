using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            //int[] nums2 = { 0, 1, 2, };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = -33;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            //int[] nums5 = { 4, 5, 6, 0, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {   //Copilot Provided me with a better solution to handle the edge case of null or empty array.
                if (nums == null || nums.Length == 0)
                {
                    return new List<int>(); // Return an empty list if the input array is null or empty
                }

                int n = nums.Length;
                List<int> missingNumbers = new List<int>();
                bool[] present = new bool[n + 1];

                // Edge case Identified, array could have either neagtive numbers of numbers greater than n
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] <= 0 || nums[i] > n)
                    {
                        // Copilot improved the code for throwing an ArgumentException. Original solution was throwing an Exception. 
                        throw new ArgumentException("Array must only contain positive integers within the range 1 to n.");
                    }
                    present[nums[i]] = true;
                }

                // Find missing numbers
                for (int i = 1; i <= n; i++)
                {
                    if (!present[i])
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while finding missing numbers.", ex);
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {   //Copilot Provided me with a better solution to handle the edge case of null or empty array.
                if (nums == null || nums.Length == 0)
                {
                    return new int[0]; // Return an empty array if the input array is null or empty
                }

                int[] result = new int[nums.Length];
                int index = 0;

                // Copilot approach is now to look for even numbers first and then odd numbers.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        result[index++] = nums[i];
                    }
                }

                // Second pass: add all odd numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        result[index++] = nums[i];
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                //Copilot improved the code for throwing an exception with a more descriptive message.
                throw new Exception("An error occurred while sorting the array by parity.", ex);
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {   // copilot provided me with a better solution to handle the edge case , array has less than 2 elements or null or empty array.
                if (nums == null || nums.Length < 2)
                {
                    throw new ArgumentException("Input array must contain at least two elements.");
                }

                Dictionary<int, int> dict1 = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int number2 = target - nums[i];

                    if (dict1.ContainsKey(number2))
                    {
                        return new int[] { dict1[number2], i };
                    }

                    if (!dict1.ContainsKey(nums[i]))
                    {
                        dict1[nums[i]] = i;
                    }
                }
                // if no solution found, throw an exception
                throw new InvalidOperationException("No two sum solution found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while finding the two sum solution.", ex);
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    throw new ArgumentException("Array must contain at least three numbers.");
                //Copilot solution offers a O(n) solution to find the maximum product of 3 numbers. by using MinValue and MaxValue
                //other approaches would need to sort the array and then find the maximum product of 3 numbers. and in some edge cases also consider the product of 2 negative numbers and 1 positive number.
                //Copilot solution create max and min variables for testing the edge cases of negative numbers.
                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;

                foreach (int num in nums)
                {
                    // Update max1, max2, max3
                    if (num > max1)
                    {
                        max3 = max2;
                        max2 = max1;
                        max1 = num;
                    }
                    else if (num > max2)
                    {
                        max3 = max2;
                        max2 = num;
                    }
                    else if (num > max3)
                    {
                        max3 = num;
                    }

                    // Update min1, min2
                    if (num < min1)
                    {
                        min2 = min1;
                        min1 = num;
                    }
                    else if (num < min2)
                    {
                        min2 = num;
                    }
                }

                //Copilot solution offers the option of having a product of 2 negative numbers and 1 positive number.
                // and a product of 3 positive numbers.
                int product1 = max1 * max2 * max3;
                int product2 = min1 * min2 * max1;

                return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    return "0";

                bool isNegative = decimalNumber < 0;
                int absValue = Math.Abs(decimalNumber);

                // Convert absolute value to binary since either positive or negative numbers are represented in binary
                string binary = "";
                while (absValue > 0)
                {
                    binary = (absValue % 2) + binary;
                    absValue /= 2;
                }

                
                int bits = binary.Length;

                // If the number is negative, add bit for the sign (two's complement)
                if (isNegative)
                {
                    bits++;  // Add 1 more bit for the two's complement representation
                }

                // Copilot proposed to used the padding to add the missing bits to the binary number.
                binary = binary.PadLeft(bits, '0');

                if (isNegative)
                {
                    // Invert bits
                    char[] invertedBinary = binary.ToCharArray();
                    for (int i = 0; i < invertedBinary.Length; i++)
                    {
                        invertedBinary[i] = invertedBinary[i] == '0' ? '1' : '0';
                    }

                    // Add 1 to the inverted binary (two's complement)
                    bool carry = true;
                    for (int i = invertedBinary.Length - 1; i >= 0; i--)
                    {
                        if (carry)
                        {
                            if (invertedBinary[i] == '0')
                            {
                                invertedBinary[i] = '1';
                                carry = false;
                            }
                            else
                            {
                                invertedBinary[i] = '0';
                            }
                        }
                    }

                    binary = new string(invertedBinary);
                }

            
                return binary;
            }
            catch (Exception ex)
            {
                //Copilot proposed to throw an exception with a more descriptive message.
                throw new Exception("An error occurred while converting decimal to binary.", ex);
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                //Using binary search approach to find the minimum element in the rotated sorted array.
                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return Convert.ToInt32(nums[left]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Use standard approach to check if the number is a palindrome.
            try
            {
                if (x < 0) return false; 

                int original = x, reversed = 0;

                while (x > 0)
                {   
                    //Compute digit of number by performing mod 10
                    int digit = x % 10;

                    //build the reversed number by multiplying by 10 and adding the digit
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }

                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            // Standard finobacci series calculation using recursion.
            try
            {   // Using the constraint indicated on the instructions document
                if (n < 0 || n > 30)
                    throw new ArgumentOutOfRangeException("n needs to be in range 0 <= n <= 30");

                // Base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                //Recursive case 
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            catch (Exception ex)
            {
                throw new Exception("Error at time of Fibonacci calculation", ex);
            }
        }
    }
}
