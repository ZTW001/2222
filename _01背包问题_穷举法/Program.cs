
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace _01背包问题_穷举法

{
    /// <summary>
    /// 假设现有容量m kg的背包，另外有i个物品，
    /// 重量分别为w[1] w[2] ... w[i] （kg）,
    /// 价值分别为p[1] p[2] ... p[i] （元）,
    /// 将哪些物品放入背包可以使得背包的总价值最大？最大价值是多少？
    /// </summary>
    class Program

    {
        /// <summary>
        /// 穷举法（把所有情况列出来，比较得到 总价值最大的情况）
        /// 如果容量增大，物品增多，这个方法的运行时间将成指数增长
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {

            int m;

            int[] w = { 0, 3, 4, 5 };

            int[] p = { 0, 4, 5, 6 };

            Console.WriteLine(Exhaustivity(10, w, p));

            Console.WriteLine(Exhaustivity(3, w, p));

            Console.WriteLine(Exhaustivity(4, w, p));

            Console.WriteLine(Exhaustivity(5, w, p));

            Console.WriteLine(Exhaustivity(7, w, p));

            Console.ReadKey();

        }



        public static int Exhaustivity(int m, int[] w, int[] p)

        {

            int i = w.Length - 1;//物品的个数



            int maxPrice = 0;

            for (int j = 0; j < Math.Pow(2, m); j++)

            {

                //取得j上某一个位的二进制值

                int weightTotal = 0;

                int priceTotal = 0;

                for (int number = 1; number <= i; number++)

                {

                    int result = Get2(j, number);

                    if (result == 1)

                    {

                        weightTotal += w[number];

                        priceTotal += p[number];

                    }

                }

                if (weightTotal <= m && priceTotal > maxPrice)

                {

                    maxPrice = priceTotal;

                }

            }

            return maxPrice;

        }



        //取得j上第number位上的二进制值，是1还是0

        //比如85的二进制为1010101.

        //w我们要求第五位二进制位数上是0还是1，那么我们可以通过位运算符的移位操作来进行

        //比如我们可以将85的二进制1010101与1向左移4位来做与运算

        //就是1010101 与 0010000做与运算，看第五位是0还是1，

        //得出这个结果，我们可以将结果0010000右移4位然后将结果与1进行比较即可



        public static int Get2(int j, int number)

        {

            int A = j;

            int B = (int)Math.Pow(2, number - 1);

            int result = A & B;

            if (result == 0)

                return 0;

            return 1;

        }

    }

}
