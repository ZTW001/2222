
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace 钢条切割问题_递归实现

{

    class Program

    {

        static void Main(string[] args)

        {
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表 钢条的长度，值代表价格

            Console.WriteLine(UpDown(0, p));

            Console.WriteLine(UpDown(1, p));

            Console.WriteLine(UpDown(2, p));

            Console.WriteLine(UpDown(3, p));

            Console.WriteLine(UpDown(4, p));

            Console.WriteLine(UpDown(5, p));

            Console.WriteLine(UpDown(6, p));

            Console.WriteLine(UpDown(7, p));

            Console.WriteLine(UpDown(8, p));

            Console.WriteLine(UpDown(9, p));

            Console.WriteLine(UpDown(10, p));

            Console.ReadKey();



        }



        public static int UpDown(int n, int[] p)//求得长度为n的最大收益

        {

            if (n == 0) return 0;

            int tempMaxPrice = 0;

            for (int i = 1; i < n + 1; i++)

            {

                int maxPrice = p[i] + UpDown(n - i, p);

                if (maxPrice > tempMaxPrice)

                    tempMaxPrice = maxPrice;

            }

            return tempMaxPrice;

        }

    }

}
