
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace _01背包问题_递归实现_带备忘的自顶向下法_

{
    /// <summary>
    /// 此方法依然是按照自然的递归形式编写过程，
    /// 但过程中会保存每个子问题的解（通常保存在一个数组中）。
    /// 当需要计算一个子问题的解时，过程首先检查是否已经保存过此解。
    /// 如果是，则直接返回保存的值，从而节省了计算时间；
    /// 如果没有保存过此解，按照正常方式计算这个子问题。我们称这个递归过程是带备忘的。
    /// </summary>
    class Program

    {

        //用来存储已经计算的最大价值

        //第一个是背包的容量m，第二个是物品的个数i

        public static int[,] result = new int[11, 4];



        static void Main(string[] args)

        {

            int[] w = { 0, 3, 4, 5 };

            int[] p = { 0, 4, 5, 6 };

            Console.WriteLine(UpDown(10, 3, w, p));

            Console.WriteLine(UpDown(3, 3, w, p));

            Console.WriteLine(UpDown(4, 3, w, p));

            Console.WriteLine(UpDown(5, 3, w, p));

            Console.WriteLine(UpDown(7, 3, w, p));

            Console.ReadKey();

        }



        /// <summary>

        /// 返回值是m可以存储的最大值

        /// </summary>

        /// <param name="m">背包容量</param>

        /// <param name="i">物品个数</param>

        /// <param name="w">物品的重量</param>

        /// <param name="p">物品的价值</param>

        /// <returns></returns>

        public static int UpDown(int m, int i, int[] w, int[] p)

        {



            if (i == 0 || m == 0) return 0;



            if (result[m, i] != 0)

                return result[m, i];



            if (w[i] > m)//如果第i个重量超过剩余的重量

            {

                result[m, i] = UpDown(m, i - 1, w, p);

                return result[m, i];

            }

            else

            {

                int maxValue1 = UpDown(m - w[i], i - 1, w, p) + p[i];//放入第i个物品

                int maxValue2 = UpDown(m, i - 1, w, p);//不放入第i个物品

                if (maxValue1 > maxValue2)

                    result[m, i] = maxValue1;

                else

                    result[m, i] = maxValue2;

                return result[m, i];

            }

        }

    }

}


