using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking_algorithm
{
    /// <summary>
    /// 回溯法从开始结点出发，以深度优先的方式搜索整个解空间。
    /// 这个开始结点成为一个活结点，同时也成为当前的扩展结点。
    /// 在当前的扩展结点处，搜索向纵深方向移至一个新结点成为一个新的活结点，
    /// 成为当前扩展结点，如果当前扩展结点不能向纵深移动，则这个当前结点成为死结点。
    /// 此时应往回移动“回溯”到最近的一个活结点处，并使这个活结点成为当前的扩展结点。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = { 11, 21, 31, 33, 43, 53, 55, 65 };   //物品的价值数组；
            int[] weights = { 1, 11, 21, 23, 33, 43, 45, 55 };   //物品的重量数组；
            double[] VW = { 11, 1.909, 1.476, 1.435, 1.303, 1.232, 1.222, 1.182 };  //物品的单位价值数组；
            int n = 8;
            int W = 110;
            int[] result = Kanpsack(values, weights, VW, n, W);  //求解空间；
            for (int i = 0; i < 8; i++)
            {
                Console.Write(result[i]);
            }

            Console.Read();
        }
        #region Bound+算出01后的背包部分的最大价值+田成荣--2017年9月28日15:04:30
        /// <summary>
        /// 算出01后的背包部分的最大价值
        /// </summary>
        /// <param name="Values">价值数组</param>
        /// <param name="Weights">重量数组</param>
        /// <param name="VW">单位价值数组</param>
        /// <param name="n">物品的个数</param>
        /// <param name="W">背包的总容量</param>
        /// <param name="Profit_Gained">当前的价值</param>
        /// <param name="Weight_Used">背包的重量</param>
        /// <param name="k">已经确定的物品</param>
        /// <returns>总价值</returns>
        public static double Bound(double[] Values, int[] Weights, double[] VW, int n, int W, double Profit_Gained, int Weight_Used, int k)
        {
            int i;
            for (i = k + 1; i < n; i++)
            {
                if (Weight_Used + Weights[i] <= W)
                {
                    Profit_Gained += Values[i];
                    Weight_Used += Weights[i];
                }
                else
                {
                    Profit_Gained += VW[i] * (W - Weight_Used);
                    Weight_Used = W;
                    return Profit_Gained;
                }
            }

            return Profit_Gained;
        }
        #endregion

        #region Knapsack+遍历树+田成荣--2017年9月28日15:37:13
        /// <summary>
        /// 遍历树
        /// </summary>
        /// <param name="Values">价值数组</param>
        /// <param name="Weights">重量数组</param>
        /// <param name="VW">单位价值数组</param>
        /// <param name="n">物品个数</param>
        /// <param name="W">背包总容量</param>
        /// <returns>物品状态</returns>
        public static int[] Kanpsack(double[] Values, int[] Weights, double[] VW, int n, int W)
        {
            int current_weight = 0;    //当前背包的重量；
            double currnet_profit = 0;  //当前背包的价值；
            int Weight = 0;            //遍历到最后时背包的重量；
            double Profit = -1;         //价值标签，为-1或到最后一个能完整放进的总价值。
            int index = 0;
            int[] X = new int[9];
            int[] Y = new int[9];
            while (true)
            {
                //不到最后一个或背包重量加上物品的重量大于背包的总容量
                while (index < n && current_weight + Weights[index] <= W)
                {
                    currnet_profit += Values[index];
                    current_weight += Weights[index];
                    Y[index] = 1;
                    index++;
                }
                if (index >= n)
                {
                    Weight = current_weight;
                    Profit = currnet_profit;
                    index = n;
                    int i;
                    for (i = 0; i < n; i++)
                    {
                        X[i] = Y[i];
                    }
                }
                else
                {
                    Y[index] = 0;   //不能全部放进去的状态为0；
                }
                //判断是否需要回溯；
                while (Bound(Values, Weights, VW, n, W, currnet_profit, current_weight, index) <= Profit)
                {
                    while (index != 0 && Y[index] != 1)  //回溯过程；
                    {
                        index--;
                    }
                    if (index == 0)
                    {
                        return X;
                    }
                    Y[index] = 0;
                    currnet_profit -= Values[index];
                    current_weight -= Weights[index];
                }
                index++;
            }

        }
        #endregion

    }
}
