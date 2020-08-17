
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace 钢条切割问题_自底向上法_动态规划算法_

{

    class Program

    {

        static void Main(string[] args)

        {

            int[] result = new int[11];

            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表 钢条的长度，值代表价格



            Console.WriteLine(BottomUp(1, p, result));

            Console.WriteLine(BottomUp(2, p, result));

            Console.WriteLine(BottomUp(3, p, result));

            Console.WriteLine(BottomUp(4, p, result));

            Console.WriteLine(BottomUp(5, p, result));

            Console.WriteLine(BottomUp(6, p, result));

            Console.WriteLine(BottomUp(7, p, result));

            Console.WriteLine(BottomUp(8, p, result));

            Console.WriteLine(BottomUp(9, p, result));

            Console.WriteLine(BottomUp(10, p, result));

            Console.ReadKey();

        }



        public static int BottomUp(int n, int[] p, int[] result)

        {

            for (int i = 1; i < n + 1; i++)

            {

                //下面取得 钢条长度为i时最大的收益

                int tempMaxPrice = -1;

                for (int j = 1; j <= i; j++)

                {

                    int maxPrice = p[j] + result[i - j];

                    if (maxPrice > tempMaxPrice)

                        tempMaxPrice = maxPrice;

                }

                result[i] = tempMaxPrice;

            }

            return result[n];

        }

    }

}
