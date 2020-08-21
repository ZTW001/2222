using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大子数组问题_暴力求解
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] priceFluctuationArray = new int[priceArray.Length - 1];//价格波动的数组
            for (int i = 1; i < priceArray.Length; i++)
            {
                priceFluctuationArray[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            int total = priceFluctuationArray[0];//默认数组的第一个元素是最大子数组
            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < priceFluctuationArray.Length; i++)
            {
                //取得以i为子数组起点的 所有子数组
                for (int j = i; j < priceFluctuationArray.Length; j++)
                {
                    //由ij就确定了一个子数组
                    int totalTemp = 0;//临时最大子数组的和
                    for (int index = i; index < j + 1; index++)
                    {
                        totalTemp += priceFluctuationArray[index];
                    }
                    if (totalTemp > total)
                    {
                        total = totalTemp;
                        startIndex = i;
                        endIndex = j;
                    }

                }
            }
            Console.WriteLine("startindex:" + startIndex);
            Console.WriteLine("endindex:" + endIndex);
            Console.WriteLine("购买时期是第" + startIndex + "天 出售是第" + (endIndex + 1) + "天");
            Console.ReadKey();
        }
    }
}