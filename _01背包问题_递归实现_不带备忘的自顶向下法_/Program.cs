
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace _01背包问题_递归实现_不带备忘的自顶向下法_

{
    /// <summary>
    /// 我们要求得i个物体放入容量为m(kg)的背包的最大价值（记为 c[i，m]）。
    /// 在选择物品的时候，对于每种物品i只有两种选择，即装入背包或不装入背包。
    /// 某种物品不能装入多次（可以认为每种物品只有一个），因此该问题被称为0-1背包问题
    /// 对于c[i，m]有下面几种情况：
    /// a、c[i,0]=c[0,m]=0
    /// b、c[i,m]=c[i-1,m]  w[i]>m（最后一个物品的重量大于容量，直接舍弃不用） w[i]<=m的时候有两种情况，一种是放入i，一种是不放入i, 不放入i c[i,m]=c[i-1,m], 放入i   c[i,m]=c[i-1,m-w[i]]+p[i]
    /// c[i,m]=max(不放入i，放入i)
    /// </summary>
    class Program

    {

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



            if (w[i] > m)//如果第i个重量超过剩余的重量

            {

                return UpDown(m, i - 1, w, p);

            }

            else

            {

                int maxValue1 = UpDown(m - w[i], i - 1, w, p) + p[i];//放入第i个物品

                int maxValue2 = UpDown(m, i - 1, w, p);//不放入第i个物品

                if (maxValue1 > maxValue2)

                    return maxValue1;

                else

                    return maxValue2;

            }

        }



    }

}
