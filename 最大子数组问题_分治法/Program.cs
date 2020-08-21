using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大子数组问题_分治法
{
    class Program
    {
        /// <summary>
        /// 最大子数组结构体
        /// </summary>
        struct SubArray
        {
            public int startIndex;
            public int endIndex;
            public int total;
        }

        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] pf = new int[priceArray.Length - 1];//价格波动的数组
            for (int i = 1; i < priceArray.Length; i++)
            {
                pf[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            SubArray subArray = GetMaxSubArray(0, pf.Length - 1, pf);
            Console.WriteLine(subArray.startIndex);
            Console.WriteLine(subArray.endIndex);
            Console.WriteLine(subArray.total);
            Console.WriteLine("购买时期是第" + subArray.startIndex + "天 出售是第" + (subArray.endIndex + 1) + "天");
            Console.ReadKey();

        }

        /// <summary>
        /// 这方法是取得array 这个数组 从low到high之间的最大子数组
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="array"></param>
        static SubArray GetMaxSubArray(int low, int high, int[] array)
        {
            if (low == high)
            {
                SubArray subArray;
                subArray.startIndex = low;
                subArray.endIndex = high;
                subArray.total = array[low];
                return subArray;
            }

            int mid = (low + high) / 2;//低区间[low,middle] 高区间[middle+1,high]

            SubArray s1 = GetMaxSubArray(low, mid, array);
            SubArray s2 = GetMaxSubArray(mid + 1, high, array);
            //从[low,mid]找到最大子数组[i,mid]
            int total1 = array[mid];
            int startIndex = mid;
            int totalTemp = 0;
            for (int i = mid; i >= low; i--)
            {
                totalTemp += array[i];
                if (totalTemp > total1)
                {
                    total1 = totalTemp;
                    startIndex = i;
                }
            }

            //从[mid+1,high]找到最大子数组[mid+1,j]
            int total2 = array[mid + 1];
            int endIndex = mid + 1;
            totalTemp = 0;
            for (int j = mid + 1; j <= high; j++)
            {
                totalTemp += array[j];
                if (totalTemp > total2)
                {
                    total2 = totalTemp;
                    endIndex = j;
                }
            }
            SubArray s3;
            s3.startIndex = startIndex;
            s3.endIndex = endIndex;
            s3.total = total1 + total2;

            if (s1.total >= s2.total && s1.total >= s3.total)
                return s1;
            else if (s2.total >= s1.total && s2.total >= s3.total)
                return s2;
            else
                return s3;
        }
    }
}