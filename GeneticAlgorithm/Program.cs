﻿using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    /// <summary>
    /// 计算函数为y = -x*x+ 5的最大值，-32<=x<=31.
    /// 采用轮盘赌算法作为选择算子的算法
    /// </summary>
    class Program
    {
        /// <summary>
        /// 染色体;
        /// </summary>
        class chromosome
        {
            /// <summary>
            /// 用6bit对染色体进行编码;
            /// </summary>
            public int[] bits = new int[6];
            /// <summary>
            /// 适应值;
            /// </summary>
            public int fitValue;
            /// <summary>
            /// 选择概率;
            /// </summary>
            public double fitValuePercent;
            /// <summary>
            /// 累积概率;
            /// </summary>
            public double probability;
        }

        /// <summary>
        /// 染色体组;
        /// </summary>
        static List<chromosome> chromosomes = new List<chromosome>();
        enum ChooseType
        {
            Bubble,//冒泡;
            Roulette,//轮盘赌;
        }
        static ChooseType chooseType = ChooseType.Roulette;
        /// <summary>
        /// Main入口函数;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("遗传算法");
            Console.WriteLine("下面举例来说明遗传算法用以求函数最大值函数为y = -x*x+ 5的最大值，-32<=x<=31");
            // f(x)=-x2+ 5
            // 迭代次数;
            int totalTime = 15;
            Console.WriteLine("迭代次数为: " + totalTime);
            //初始化;
            Console.WriteLine("初始化: ");
            Init();
            // 输出初始化数据;
            Print();
            for (int i = 0; i < totalTime; i++)
            {
                Console.WriteLine("当前迭代次数: " + i);

                //重新计算fit值;;
                UpdateFitValue();

                // 挑选染色体;
                Console.WriteLine("挑选:");

                switch (chooseType)
                {
                    case ChooseType.Bubble:
                        // 排序;
                        Console.WriteLine("排序:");
                        ChooseChromosome();
                        break;
                    default:
                        //轮盘赌;
                        Console.WriteLine("轮盘赌:");
                        UpdateNext();
                        break;
                }
                Print(true);

                //交叉得到新个体;
                Console.WriteLine("交叉:");
                CrossOperate();
                Print();

                //变异操作;
                Console.WriteLine("变异:");
                VariationOperate();
                Print();

            }

            int maxfit = chromosomes[0].fitValue;
            for (int i = 1; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].fitValue > maxfit)
                {
                    maxfit = chromosomes[i].fitValue;
                }
            }
            Console.WriteLine("最大值为: " + maxfit);
            Console.ReadLine();
        }

        /// <summary>
        /// 打印;
        /// </summary>
        static void Print(bool bLoadPercent = false)
        {
            Console.WriteLine("=========================");
            for (int i = 0; i < chromosomes.Count; i++)
            {
                Console.Write("第" + i + "条" + " bits: ");
                for (int j = 0; j < chromosomes[i].bits.Length; j++)
                {
                    Console.Write(" " + chromosomes[i].bits[j]);
                }
                int x = DeCode(chromosomes[i].bits);
                Console.Write(" x: " + x);
                Console.Write(" y: " + chromosomes[i].fitValue);
                if (bLoadPercent)
                {
                    Console.Write(" 选择概率: " + chromosomes[i].fitValuePercent);
                    //Console.Write(" 累积概率: " + chromosomes[i].probability);
                }
                Console.WriteLine();
            }
            Console.WriteLine("=========================");
        }

        /// <summary>
        /// 初始化;
        /// </summary>
        static void Init()
        {
            chromosomes.Clear();
            // 染色体数量;
            int length = 4;
            int totalFit = 0;
            for (int i = 0; i < length; i++)
            {
                chromosome chromosome = new chromosome();
                for (int j = 0; j < chromosome.bits.Length; j++)
                {
                    // 随机出0或者1;
                    int seed = (i + j) * 100 / 3;//种子;
                    Random random = new Random(seed);
                    int bitValue = random.Next(0, 2);
                    chromosome.bits[j] = bitValue;
                }
                //获得十进制的值;
                int x = DeCode(chromosome.bits);
                int y = GetFitValue(x);
                chromosome.fitValue = y;
                chromosomes.Add(chromosome);
                //算出total fit;
                if (chromosome.fitValue <= 0)
                {
                    totalFit += 0;
                }
                else
                {
                    totalFit += chromosome.fitValue;
                }
            }

            for (int i = 0; i < chromosomes.Count; i++)
            {
                //计算适应值得百分比，该参数是在用轮盘赌选择法时需要用到的;
                if (chromosomes[i].fitValue <= 0)
                {
                    chromosomes[i].fitValuePercent = 0;
                }
                else
                {
                    chromosomes[i].fitValuePercent = chromosomes[i].fitValue / totalFit;
                }
                //
                chromosomes[i].probability = 0;
            }
        }

        /// <summary>
        /// 解码,二进制装换;
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        static int DeCode(int[] bits)
        {
            int result = bits[4] * 16 + bits[3] * 8 + bits[2] * 4 + bits[1] * 2 + bits[0] * 1;
            //正数;
            if (bits[5] == 0)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }

        /// <summary>
        /// 获取fit值;
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static int GetFitValue(int x)
        {
            //目标函数：y= - ( x^ 2 ) +5;
            return -(x * x) + 5;
        }

        /// <summary>
        /// 更新下一代;
        /// 基于轮盘赌选择方法，进行基因型的选择;
        /// </summary>
        static void UpdateNext()
        {
            // 获取总的fit;
            double totalFitValue = 0;
            for (int i = 0; i < chromosomes.Count; i++)
            {
                //适应度为负数的取0;
                if (chromosomes[i].fitValue <= 0)
                {
                    totalFitValue += 0;
                }
                else
                {
                    totalFitValue += chromosomes[i].fitValue;
                }
            }
            Console.WriteLine("totalFitValue " + totalFitValue);

            //算出每个的fit percent;
            for (int i = 0; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].fitValue <= 0)
                {
                    chromosomes[i].fitValuePercent = 0;
                }
                else
                {
                    chromosomes[i].fitValuePercent = chromosomes[i].fitValue / totalFitValue;
                }
                Console.WriteLine("fitValuePercent " + i + " " + chromosomes[i].fitValuePercent);
            }
            //计算累积概率;
            // 第一个的累计概率就是自己的概率;
            chromosomes[0].probability = chromosomes[0].fitValuePercent;
            for (int i = 1; i < chromosomes.Count; i++)
            {
                // 上一个的累计概率加上自己的概率,得到自己的累计概率;
                chromosomes[i].probability = chromosomes[i - 1].probability + chromosomes[i].fitValuePercent;
            }
            //轮盘赌选择方法,用于选出前两个;
            for (int i = 0; i < chromosomes.Count; i++)
            {

                //产生0-1之前的随机数;
                int seed = i * 100 / 3;
                double rand = new Random(seed).NextDouble();//0.0-1.0
                Console.WriteLine("挑选的rand " + rand);
                if (rand < chromosomes[0].probability)
                {
                    chromosomes[i] = chromosomes[0];
                }
                else
                {
                    for (int j = 0; j < chromosomes.Count - 1; j++)
                    {
                        if (chromosomes[j].probability <= rand && rand <= chromosomes[j + 1].probability)
                        {
                            chromosomes[i] = chromosomes[j + 1];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择染色体;
        /// </summary>
        static void ChooseChromosome()
        {
            // 从大到小排序;
            chromosomes.Sort((a, b) => { return b.fitValue.CompareTo(a.fitValue); });
        }

        /// <summary>
        /// 交叉操作;
        /// </summary>
        static void CrossOperate()
        {
            /**         bit[5]~bit[0]   fit
             * 4        000 110         12
             * 3        001 010         9
             * child1   000 010         14
             * child2   001 110         5
             */
            int rand = new Random().Next(0, 6);//0-5;
            Console.WriteLine("交叉的rand " + rand);
            for (int i = 0; i < rand; i++)
            {
                //将第0个给第2个;
                chromosomes[2].bits[i] = chromosomes[0].bits[i];//第一条和第三条交叉;
                chromosomes[3].bits[i] = chromosomes[1].bits[i];//第二条和第四条交叉;
            }

            for (int i = rand; i < 6; i++)
            {
                chromosomes[2].bits[i] = chromosomes[1].bits[i];//第一条和第三条交叉;
                chromosomes[3].bits[i] = chromosomes[0].bits[i];//第二条和第四条交叉;
            }
        }

        /// <summary>
        /// 变异操作;
        /// </summary>
        static void VariationOperate()
        {
            int rand = new Random(DateTime.Now.Millisecond).Next(0, 50);
            Console.WriteLine("变异的rand " + rand);
            if (rand == 25)//1/50 = 0.02的概率进行变异;rand==25;
            {
                Console.WriteLine("开始变异");

                int col = new Random(DateTime.Now.Millisecond * 10).Next(0, 6);
                int row = new Random(DateTime.Now.Millisecond * 10).Next(0, 4);

                // 0变为1,1变为0;
                if (chromosomes[row].bits[col] == 0)
                {
                    chromosomes[row].bits[col] = 1;
                }
                else
                {
                    chromosomes[row].bits[col] = 0;
                }
            }
        }

        /// <summary>
        /// 重新计算fit值;
        /// </summary>
        static void UpdateFitValue()
        {
            for (int i = 0; i < chromosomes.Count; i++)
            {
                chromosomes[i].fitValue = GetFitValue(DeCode(chromosomes[i].bits));
            }
        }
    }
}
