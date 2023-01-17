using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tests
{
    [TestClass()]
    public class LeetcodeTests
    {
        Leetcode test = new Leetcode();
        // CollectionAssert.AreEqual(testfunction, ans);
        // Assert.AreEqual(testfunciton, ans);

        [TestMethod()]
        public void PermuteTest()
        {
            int[] parameter = new int[] { 0, 1 };
            IList<IList<int>> ans = new List<IList<int>>() { new List<int> { 1, 2, 3 },
                                                            new List<int> { 1,3,2 },
                                                            new List<int> { 2,1,3 },
                                                            new List<int> { 2,3,1 },
                                                            new List<int> { 3,1,2 },
                                                            new List<int> { 3,2,1 } };
            var testfunciton = test.Permute(parameter);

            Assert.AreEqual(testfunciton, ans);
        }

        [TestMethod()]
        public void FindMedianSortedArraysTest()
        {
            int[] a = new int[] { 1, 2 };
            int[] b = new int[] { 3, 4 };

            var testfunciton = test.FindMedianSortedArrays(a, b);

            Assert.AreEqual(testfunciton, 2.50000);
        }

        [TestMethod()]
        public void FindFinalValueTest()
        {
            int[] nums = new int[] { 2, 7, 9 };
            int original = 4;
            var testfunciton = test.FindFinalValue(nums, original);
            Assert.AreEqual(testfunciton, 4);
        }

        [TestMethod()]
        public void RobTest()
        {
            int[] values = new int[] { 2, 1, 1, 2 };
            var testfunciton = test.Rob(values);
            //CollectionAssert.AreEqual(testfunciton.ToList(), ans);
            Assert.AreEqual(testfunciton, 4);
        }

        [TestMethod()]
        public void LongestPalindromeTest()
        {
            var testfunciton = test.LongestPalindrome("babad");
            Assert.AreEqual(testfunciton, "bab");
        }

        [TestMethod()]
        public void ThreeSumTest()
        {
            var testfunciton = test.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            var ans = new List<IList<int>>();
            ans.Add(new int[] { -1, -1, 2 });
            ans.Add(new int[] { -1, 0, 1 });
            Assert.ReferenceEquals(testfunciton, ans);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            var testfunciton = test.RomanToInt("LVIII");
            Assert.AreEqual(testfunciton, 58);
        }

        [TestMethod()]
        public void MaxAreaTest()
        {
            var testfunciton = test.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            Assert.AreEqual(testfunciton, 49);
        }
    }
}