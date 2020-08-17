using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 钱币找零问题_贪心算法
{
    class Program
    {
        /// <summary>
        /// 这个问题在我们的日常生活中就更加普遍了。
        /// 假设1元、2元、5元、10元、20元、50元、100元的纸币分别有c0, c1, c2, c3, c4, c5, c6张。
        /// 现在要用这些钱来支付K元，至少要用多少张纸币？用贪心算法的思想，很显然，每一步尽可能用面值大的纸币即可。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] amount = { 1, 2, 5, 10, 20, 50, 100 };
            int[] count = { 3, 0, 2, 1, 0, 3, 5 };
            int[] result = Change(204, count, amount);
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadKey();

        }

        public static int[] Change(int k, int[] count, int[] amount)
        {
            if (k == 0) return new int[amount.Length + 1];
            int total = 0;
            int index = amount.Length - 1;
            int[] result = new int[amount.Length + 1];
            while (true)
            {
                if (k <= 0 || index <= -1) break;
                if (k > count[index] * amount[index])//我们有的纸币的钱的总额，比k要小
                {
                    result[index] = count[index];
                    k -= count[index] * amount[index];
                }
                else
                {
                    result[index] = k / amount[index];
                    k -= result[index] * amount[index];
                }
                index--;
            }
            result[amount.Length] = k;
            return result;
        }
    }
}