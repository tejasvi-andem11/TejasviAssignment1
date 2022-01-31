/*
 * Name: Andem Tejasvi Reddy
 * Date: 01/30/2022
 * Description: Solution for questions in Assignment 1
 * Self Reflection: I have taken around 13 hours to finish the assignment. With this assignment I got the opportunity to dive deeper into C# programming and make myself familiar with the syntaxes
*/

using System;
using System.Linq;

namespace TejasviAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();


            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is {0} ", rotated_string);
            Console.WriteLine();

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
            Console.WriteLine();

        }

        /* 
        <summary>
        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:
        Input: s = "MumaCollegeofBusiness"
        Output: "MmCllgfBsnss"
        Example 2:
        Input: s = "aeiou"
        Output: ""
        Constraints:
        •	0 <= s.length <= 10000
        s consists of uppercase and lowercase letters
        </summary>
        */

        private static string RemoveVowels(string s)
        {
            try
            {
                // write your code here
                int len = s.Length;
                if (len > 10000) //Custom exception
                {
                    throw new MaxLengthExceeded(len);
                }
                String finalString = "";
                foreach (char v in s)
                {
                    if (v != 'a' && v != 'e' && v != 'i' && v != 'o' && v != 'u' && v != 'A' && v != 'E' && v != 'I' && v != 'O' && v != 'U') //checking for vowels in the input string
                    {
                        finalString = finalString + v;
                    }
                }
                return finalString;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* 
        <summary>
       Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
       A string is represented by an array if the array elements concatenated in order forms the string.
       Example 1:
       Input: : bulls_string1 = ["Marshall", "Student",”Center”], : bulls_string2 = ["MarshallStudent ", "Center"]
       Output: true
       Explanation:
       word1 represents string "marshall" + "student" + “center” -> "MarshallStudentCenter "
       word2 represents string "MarshallStudent" + "Center" -> "MarshallStudentCenter"
       The strings are the same, so return true.
       Example 2:
       Input: word1 = ["Zimmerman", "School", ”of Advertising”, ”and Mass Communications”], word2 = ["Muma", “College”,"of”, “Business"]
       Output: false
       Example 3:
       Input: word1  = ["University", "of", "SouthFlorida"], word2 = ["UniversityofSouthFlorida"]
       Output: true
       </summary>
       */

        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                string b1 = "";
                foreach (string s in bulls_string1)
                {
                    b1 = b1 + s; // concatenate all the strings in the first array
                }
                string b2 = "";
                foreach (string s in bulls_string2)
                {
                    b2 = b2 + s; // concat all the strings in second array
                }
                if (b1 == b2) // comparing the concatenated strings
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
        <summary> 
       You are given an integer array bull_bucks. The unique elements of an array are the elements that appear exactly once in the array.
       Return the sum of all the unique elements of nums.
       Example 1:
       Input: bull_bucks = [1,2,3,2]
       Output: 4
       Explanation: The unique elements are [1,3], and the sum is 4.
       Example 2:
       Input: bull_bucks = [1,1,1,1,1]
       Output: 0
       Explanation: There are no unique elements, and the sum is 0.
       Example 3:
       Input: bull_bucks = [1,2,3,4,5]
       Output: 15
       Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.
       </summary>
        */

        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                int len = bull_bucks.Length;
                if (len > 100)//throwing custom exceptions
                {
                    throw new MaxLengthExceeded(len);
                }
                foreach (int i in bull_bucks)//throwing custom exceptions
                {
                    if (i > 100)
                    {
                        throw new MaxValueExceeded(i);
                    }
                }
                int[] newArray = new int[len]; //creating new array
                int count = 0;
                for (int i = 0; i < len; i++)
                {
                    int n = bull_bucks[i];
                    if (newArray.Contains(n))
                    {
                        count = count - n; //subtracting repeating indices
                    }
                    else
                    {
                        count = count + n;//adding unique elements
                        newArray[i] = bull_bucks[i];//adding all unique elements to the new array
                    }
                }
                return count;
            }
            catch
            {
                throw;
            }
        }

        /*
        <summary>
       Given a square matrix bulls_grid, return the sum of the matrix diagonals.
       Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.
       Example 1:
       Input: bulls_grid = [[1,2,3],[4,5,6], [7,8,9]]
       Output: 25
       Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
       Notice that element mat[1][1] = 5 is counted only once.
       Example 2:
       Input: bulls_grid = [[1,1,1,1], [1,1,1,1],[1,1,1,1], [1,1,1,1]]
       Output: 8
       Example 3:
       Input: bulls_grid = [[5]]
       Output: 5
       </summary>
        */

        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                // write your code here.
                int len = Convert.ToInt32(Math.Sqrt(bulls_grid.Length)); //get the matrix size
                int sum = 0;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++) // iterating through the diagonal elements
                    {
                        if (i == j)
                        {
                            sum = sum + bulls_grid[i, j]; //adding all left diagonal elements
                        }
                        else if (i + j == (len - 1))
                        {
                            sum = sum + bulls_grid[i, j]; //adding the right diagonal elements
                        }
                    }
                }
                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*
         
        <summary>
        Given a string bulls_string  and an integer array indices of the same length.
        The string bulls_string  will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.
        Example 3:
        Input: bulls_string  = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int len = indices.Length;
                if (len > 100) //custom exceptions
                {
                    throw new MaxLengthExceeded(len);
                }
                if (bulls_string.Length != indices.Length) //custom exceptions
                {
                    throw new LengthDifferent();
                }
                if (bulls_string.Any(char.IsUpper)) //custom exceptions
                {
                    throw new UpperCaseLetter();
                }
                if (indices.Distinct().Count() != indices.Length) //custom exceptions
                {
                    throw new DuplicateValue();
                }
                foreach (int i in indices)
                {
                    if (i > bulls_string.Length)
                    {
                        throw new LengthExceeded();
                    }
                }
                string result = "";
                for (int i = 0; i < len; i++)
                {
                    int n = Array.IndexOf(indices, i);
                    result = result + bulls_string[n]; //adding the char from the bull_string to the final string at the index fetched from above
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
         <summary>
        Given a 0-indexed string bulls_string   and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). If the character ch does not exist in word, do nothing.
        For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). The resulting string will be "dcbaefd".
        Return the resulting string.
        Example 1:
        Input: bulls_string   = "mumacollegeofbusiness", ch = "c"
        Output: "camumollegeofbusiness"
        Explanation: The first occurrence of "c" is at index 4. 
        Reverse the part of word from 0 to 4 (inclusive), the resulting string is "camumollegeofbusiness".
        Example 2:
        Input: bulls_string   = "xyxzxe", ch = "z"
        Output: "zxyxxe"
        Explanation: The first and only occurrence of "z" is at index 3.
        Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".
        Example 3:
        Input: bulls_string   = "zimmermanschoolofadvertising", ch = "x"
        Output: "zimmermanschoolofadvertising"
        Explanation: "x" does not exist in word.
        You should not do any reverse operation, the resulting string is "zimmermanschoolofadvertising".
        */

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int len = bulls_string6.Length;
                if (bulls_string6.Any(char.IsUpper)) //custom exceptions
                {
                    throw new UpperCaseLetter();
                }
                if (len > 250) //custom exceptions
                {
                    throw new MaxLengthExceeded(len);
                }
                int n = bulls_string6.IndexOf(ch, 0, len); //getting the index of the input character
                for (int i = n; i >= 0; i--)
                {
                    prefix_string = prefix_string + bulls_string6[i]; //reversing the string
                }
                for (int i = n + 1; i < len; i++)
                {
                    prefix_string = prefix_string + bulls_string6[i]; //concatenate the remaining string
                }
                return prefix_string; //return string
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
[Serializable]
public class MaxLengthExceeded : Exception
{
    public MaxLengthExceeded(int l)
    {
        Console.WriteLine($"Length of input string should be less than {l}");
    }
}
public class MaxValueExceeded : Exception
{
    public MaxValueExceeded(int i)
    {
        Console.WriteLine($"Input value should not exceed 100, current value: {i}");
    }
}
public class UpperCaseLetter : Exception
{
    public UpperCaseLetter()
    {
        Console.WriteLine("Input string should not contain Upper case letters");
    }
}

public class DuplicateValue : Exception
{
    public DuplicateValue()
    {
        Console.WriteLine("Duplicate values should not be entered in the input array");
    }
}

public class LengthDifferent : Exception
{
    public LengthDifferent()
    {
        Console.WriteLine("Indices length and bull_string length are not same");
    }
}
public class LengthExceeded : Exception
{
    public LengthExceeded()
    {
        Console.WriteLine("Value in indices is exceeding the number of characters in the string");
    }
}
