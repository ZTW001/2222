using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题_贪心算法_迭代解决_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            int startTime = 0;
            int endTime = 24;
            List<int> list = new List<int>();
            for (int number = 1; number <= 11; number++)
            {
                if (s[number] >= startTime && f[number] <= endTime)
                {
                    list.Add(number);
                    startTime = f[number];
                }
            }

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}