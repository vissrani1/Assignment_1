using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = Question1.JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = Question2.CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] nums = { 1, 2, 3, 1, 1, 3 };
            int gp = Question3.NumIdenticalPairs(nums);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);

            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = Question4.PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = Question5.MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = Question6.ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        class Question1
            //Logic
            //R: Increase x by +1 L ; L: Increase x by -1
            //U: Increase y by +1 ; D: Increase y by -1
        {
            public static bool JudgeCircle(string moves)
            {
                try
                {
                    int x = 0;
                    int y = 0;

                    char[] array = moves.ToCharArray();

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == 'R')
                            x++;
                        else if (array[i] == 'L')
                            x--;
                        else if (array[i] == 'U')
                            y++;
                        else if (array[i] == 'D')
                            y--;
                    }
                    return (x == 0 && y == 0);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        class Question2
            //Logic
            //Create a table of characters that are present in the string and iterate over the characters
            //to create an index.
            //If total is <=25, result is false or else, true
        {
            public static bool CheckIfPangram(string str)
            {
                try
                {     
                    bool[] mark = new bool[26];
                    int index = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if ('A' <= str[i] && str[i] <= 'Z')
                            index = str[i] - 'A';
                        else if ('a' <= str[i] && str[i] <= 'z')
                            index = str[i] - 'a';
                        else
                            continue;

                        mark[index] = true;
                    }
                    for (int i = 0; i <= 25; i++)
                        if (mark[i] == false)
                            return (false);
                    return (true);
                }

                catch (Exception)
                {
                    throw;
                }

            }
        }

        public class Question3
            //Logic
            //Iterate over the array to check for any good pair of indices in the given array
        {
            public static int NumIdenticalPairs(int[] nums)
            {
                try
                {
                    int count = 0;
                    int l = nums.Length;

                    for (int i = 0; i < l; i++)
                    {
                        for (int j = i + 1; j < l; j++)
                        {
                            if (nums[i] == nums[j])
                                count++;
                        }
                    }
                    return count;
                }
                catch (Exception)
                {

                throw;
                }
            }
        }

        public class Question4
            //Logic
            //Need to find total sum first then iterate through the given number array to find the Pivot Index
        {
            public static int PivotIndex(int[] nums)
            {
                try
                {
                    int totalSum = 0;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        totalSum += nums[i];
                    }

                    int leftSideSum = 0;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        int rightSideSum = (totalSum - leftSideSum - nums[i]);

                        if (rightSideSum == leftSideSum)
                        {
                            return i;
                        }

                        leftSideSum = leftSideSum + nums[i];
                    }

                    return -1;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured: " + e.Message);
                    throw;
                }

            }
        }

        public class Question5
            //Logic
            //Define the i and j variables first then conduct an iteration on the given characters.
            //If one word is longer than the other, then additional characters will be added at the end of the result.
        {
            public static string MergeAlternately(string word1, string word2)
            {
                try
                {

                    string result = "";
                    int i = 0, j = 0;
                    while (i < word1.Length || j < word2.Length)
                    {

                        if (i < word1.Length)
                            result = result + word1[i];

                        if (j < word2.Length)
                            result = result + word2[j];

                        i++;
                        j++;
                    }
                    return result;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
        public class Question6
        //Logic
        //Specify the vowels
        //Specify all the conditions for Goat Latin
        //Need to split the sentences by removing white spaces then
        //Iterate on the words in the given sentence to satisfy conditions for Goat Latin
        //then merge the words together for the final solution.

        {
            public static string ToGoatLatin(string sentence)
            {
                try
                {
                    var words = sentence.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                    string letter = "a", solution = "";
                    var vowels = new List<char>() { 'A', 'a', 'E', 'e', 'I','i', 'O', 'o', 'U', 'u'};
                    foreach (var word in words)
                    {
                        if (vowels.Any(x => x == word[0]))
                        {
                            solution += word + "ma" + letter + " ";
                        }
                        else
                        {
                            solution += word.Substring(1) + word[0] + "ma" + letter + " ";
                        }
                        letter += "a";
                    }
                    return solution.Substring(0, solution.Length - 1);
                }
                catch (Exception)
                {
                    throw;
                }


            }


        }
    }
}
//Self-Reflection

//While I learnt some new concepts, I felt that that this assignment was challenging. I had to research alot of these concepts
//since I have limited coding experience. I felt like I was thrown in the deep end with this assignment.


