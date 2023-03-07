using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Reflection;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Leetcode
    {
        //https://leetcode.com/problems/permutations/
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            //var tempList = new List<int>();

            //if (nums.Length == 1) 
            //{
            //    ans.Add(nums);
            //    return ans;
            //} 
            //else
            //{
            //    var List = new List<int>(nums);
            //    var RList = new List<int>(List);
            //    nums.
            //    RList.Reverse();

            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        bool have = false;
            //        var temp = List[0];
            //        List.Remove(temp);
            //        List.Add(temp);
                    
            //        foreach(var item in ans)
            //        {
            //            if
            //        }

            //        temp = RList[0];
            //        RList.Remove(temp);
            //        RList.Add(temp);
            //        if (!ans.Contains(RList))
            //        {
            //            ans.Add(new List<int>(RList));
            //        }
            //    }
                return ans;
         }

        //https://leetcode.com/problems/median-of-two-sorted-arrays/
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var marge = nums1.Concat(nums2).ToList();
            marge.Sort();
            double half = marge.Count / 2;
            if (marge.Count % 2 == 0)
            {
                var a = marge[(int)half];
                var b = marge[(int)half - 1];
                return ((double)marge[(int)half] + (double)marge[(int)half - 1]) / 2;
            }
            else
            {
                return marge[(int)half];
            }
        }
        //https://leetcode.com/problems/keep-multiplying-found-values-by-two/
        public int FindFinalValue(int[] nums, int original)
        {
            while (true)
            {
                if (!nums.Contains(original)) return original;
                else original *= 2;
            }
        }
        //https://leetcode.com/problems/house-robber/
        public int Rob(int[] nums)
        {
            return 0;
        }
        //https://leetcode.com/problems/longest-palindromic-substring/
        public string LongestPalindrome(string s)
        {
            List<string> ans = new List<string>();
            List<string> Ltemp = new List<string>();
            List<string> Rtemp = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                var temp = new List<char>(s);
                Rtemp.Clear();
                Ltemp.Clear();
                temp.RemoveAt(i);
                if (temp.Contains(s[i]))
                {
                    int pos = temp.IndexOf(s[i])+1;
                    int now = i; 
                    while (pos > i)
                    {
                        if (s[now] == s[pos] && pos != now)
                        {
                            Ltemp.Add(s[now].ToString());
                            Rtemp.Add(s[pos].ToString());
                            now++;
                            pos--;
                        }
                        else break;
                    }
                    if (now == pos)
                    {
                        Ltemp.Add(s[pos].ToString());
                    }
                    if(Ltemp.Count > 0)
                    {
                        Rtemp.Reverse();
                        Ltemp.AddRange(Rtemp);
                        if (Ltemp.Count > ans.Count)
                        {
                            ans.Clear();
                            ans.AddRange(Ltemp);
                        }
                    }
                }
            }
            string joinedNames = String.Join("", ans.ToArray());
            return joinedNames;
        }
        //https://leetcode.com/problems/3sum/
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int xtemp = int.MaxValue;
            int ytemp = int.MaxValue;
            var ans = new List<IList<int>>();
            Array.Sort(nums);
            var numsList = nums
                .Where(o => o <= 0 - (nums[0] + nums[1]) && o >= 0 - (nums[nums.Length - 1] + nums[nums.Length - 2]))
                .ToList();
            for (int x = 0; x < numsList.Count - 2; x++)
            {
                if (numsList[x] == xtemp) continue;
                xtemp = numsList[x];
                for (var y = x + 1; y < numsList.Count - 1; y++)
                {
                    if (numsList[y] == ytemp) continue;
                    ytemp = numsList[y];
                    var temp = new List<int>(numsList.Skip(y + 1));
                    if (temp.Contains(0 - (numsList[x] + numsList[y])))
                    {
                        ans.Add(new int[] { numsList[x], numsList[y], 0 - (numsList[x] + numsList[y]) }.ToList());
                        break;
                    }
                }
            }
            return ans;
        }
        //https://leetcode.com/problems/roman-to-integer/
        public int RomanToInt(string s)
        {
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        if (i > 0 && s[i - 1] == 'C')
                            ans -= 200;
                        ans+=1000;
                        break;
                    case 'D':
                        if (i > 0 && s[i - 1] == 'C')
                            ans -= 200;
                        ans += 500;
                        break;
                    case 'C':
                        if (i > 0 && s[i - 1] == 'X')
                            ans -= 20;
                        ans +=100;
                        break;
                    case 'L':
                        if (i > 0 && s[i - 1] == 'X')
                            ans -= 20;
                        ans +=50;
                        break;
                    case 'X':
                        if (i > 0 && s[i - 1] == 'I')
                            ans -=2;
                        ans +=10;
                        break;
                    case 'V':
                        if (i > 0 && s[i - 1] == 'I')
                            ans-=2;
                        ans +=5;
                        break;
                    case 'I':
                        ans++;
                        break;
                }
            }
            return ans;
        }
        //https://leetcode.com/problems/container-with-most-water/
        public int MaxArea(int[] height)
        {
            int w = 0;
            int left = 0;
            int right = height.Length - 1;
            int ans = 0;
            while(left < right)
            {
                w = right - left;
                ans = Math.Max(ans,w * Math.Min(height[left], height[right]));
                if(height[left] > height[right]) right--;
                else left++;
            }
            return ans;
        }
        //https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
        public int CountStudents(int[] students, int[] sandwiches)
        {
            var Qstudents = new Queue<int>();
            var Qsandwiches = new Queue<int>();

            for(int i = 0; i < students.Length;i++)
            {
                Qstudents.Enqueue(students[i]);
                Qsandwiches.Enqueue(sandwiches[i]);
            }
            int num = 0;
            while (Qstudents.Count > 0) {
                if (num == Qstudents.Count) break;
                if (Qstudents.Peek() == Qsandwiches.Peek())
                {
                    Qstudents.Dequeue();
                    Qsandwiches.Dequeue();
                    num = 0;
                }
                else
                {
                    Qstudents.Enqueue(Qstudents.Dequeue());
                    num++;
                }
            }
            return Qstudents.Count;
        }
    }
}
