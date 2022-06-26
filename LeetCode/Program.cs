using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var main = new Leetcode();
            int[][] s = {   new int[] {1, 1, 1},
                            new int[] {2,2,2},
                            new int[] {3,3,3}};

            int[] nums = new int[] { 2, 5, 3, 4, 1 };
            string[] str = new string[] {"X++", "++X", "--X", "X--"};
            var ans = main.NumTeams(nums);
            Console.WriteLine(ans);

            //foreach (var x in str)
            //{
            //    Console.WriteLine(x);
            //}
            Console.ReadLine();

        }
    }

    public class Leetcode
    {

        public int NumTeams1(int[] rating)
        {
            int n = rating.Length, count = 0;
            for (int middle = 1; middle < n - 1; middle++)
            {
                int curr = rating[middle];
                var leftSmaller = 0;
                var leftBigger = 0;
                var rightSmaller = 0;
                var rightBigger = 0;

                for (int start = 0; start < middle; start++)
                {
                    if (rating[start] < curr)
                    {
                        leftSmaller++;
                    }

                    if (rating[start] > curr)
                    {
                        leftBigger++;
                    }
                }

                for (int start = middle + 1; start < n; start++)
                {
                    if (rating[start] < curr)
                    {
                        rightSmaller++;
                    }

                    if (rating[start] > curr)
                    {
                        rightBigger++;
                    }
                }

                count += (leftSmaller * rightBigger) + (leftBigger * rightSmaller);
            }
            return count;
        }
        public int NumTeams(int[] rating)
        {
            int ans = 0 ;
            for (int i = 0; i <= rating.Length - 3; i++)
            {
                bool BS = rating[i] > rating[i + 1];
                ans += TeamsAdd(2, rating, BS);
            }
            return ans;
        }

        public int TeamsAdd (int i, int[] rating,bool bs)
        {
            int len = 1;
            for (int x = i; x < rating.Length-1; x++)
            {
                if (bs)
                    if(rating[x] < rating[x + 1] ) continue;
                if (!bs)
                    if(rating[x] > rating[x + 1] ) continue;
                len++;
                if (len == 3)
                {
                    return 1;
                }
            }
            return 0;
        }

    }
}
