
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace 钢条切割问题_带备忘的自顶向下法_动态规划_

{
    /// <summary>
    /// 我们从钢条的左边切下长度为i的一段，
    /// 只对右边剩下长度为n-i的一段继续进行切割，
    /// 对左边的不再切割。
    /// 这样，不做任何切割的方案就是：
    /// 当第一段长度为n的时候，收益为pn，剩余长度为0，对应的收益为0。
    /// 如果第一段长度为i，收益为pi
    /// </summary>
    class Program

    {
        /// <summary>
        /// 假定我们知道sering公司出售一段长度为I英寸的钢条的价格为pi(i=1,2,3….)钢条长度为整英寸如图给出价格表的描述（任意长度的钢条价格都有）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {

            //int n = 5;//我们要切割售卖的钢条的长度

            int[] result = new int[11];

            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表 钢条的长度，值代表价格

            Console.WriteLine(UpDown(0, p, result));

            Console.WriteLine(UpDown(1, p, result));

            Console.WriteLine(UpDown(2, p, result));

            Console.WriteLine(UpDown(3, p, result));

            Console.WriteLine(UpDown(4, p, result));

            Console.WriteLine(UpDown(5, p, result));

            Console.WriteLine(UpDown(6, p, result));

            Console.WriteLine(UpDown(7, p, result));

            Console.WriteLine(UpDown(8, p, result));

            Console.WriteLine(UpDown(9, p, result));

            Console.WriteLine(UpDown(10, p, result));

            Console.ReadKey();



        }



        //带备忘的自顶向下

        public static int UpDown(int n, int[] p, int[] result)//求得长度为n的最大收益

        {

            if (n == 0) return 0;

            if (result[n] != 0)

            {

                return result[n];

            }

            int tempMaxPrice = 0;

            for (int i = 1; i < n + 1; i++)

            {

                int maxPrice = p[i] + UpDown(n - i, p, result);

                if (maxPrice > tempMaxPrice)

                    tempMaxPrice = maxPrice;

            }

            result[n] = tempMaxPrice;

            return tempMaxPrice;

        }

    }

}


