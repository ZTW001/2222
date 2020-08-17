using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题_贪心算法_递归解决_
{
    class Program
    {

        static int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
        static int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public static List<int> ActivitySelection(int startActivityNumber, int endActivityNumber, int startTime, int endTime)
        {
            if (startActivityNumber > endActivityNumber || startTime >= endTime)
                return new List<int>();
            //找到结束时间最早的活动
            int tempNumber = 0;
            for (int number = startActivityNumber; number <= endActivityNumber; number++)
            {
                if (s[number] >= startTime && f[number] <= endTime)
                {
                    tempNumber = number;
                    break;
                }
            }
            List<int> list = ActivitySelection(tempNumber + 1, endActivityNumber, f[tempNumber], endTime);
            list.Add(tempNumber);
            return list;
        }

        static void Main(string[] args)
        {
            List<int> list = ActivitySelection(1, 11, 0, 24);
            foreach (int temp in list)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}