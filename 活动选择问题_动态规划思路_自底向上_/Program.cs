
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace 活动选择问题_动态规划思路_自底向上_

{
    /// <summary>
    /// 有n个需要在同一天使用同一个教室的活动a1,a2,…,an，
    /// 教室同一时刻只能由一个活动使用。每个活动ai都有一个开始时间si和结束时间fi 。
    /// 一旦被选择后，活动ai就占据半开时间区间[si,fi)。如果[si,fi]和[sj,fj]互不重叠，ai和aj两个活动就可以被安排在这一天。
    /// 该问题就是要安排这些活动使得尽量多的活动能不冲突的举行（最大兼容活动子集）。
    /// </summary>
    class Program

    {
        /// <summary>
        /// 我们使用Sij代表在活动ai结束之后，且在aj开始之前的那些活动的集合，我们使用c[i,j]代表Sij的最大兼容活动子集的大小，对于上述问题就是求c[0,12]的解
        /// a, 当i>=j-1或者Sij 中没有任何活动元素的时候， c[i,j]=0
        /// b，当i<j-1
        /// 1，Sij不存在活动,c[i,j]=0
        /// 2，Sij存在活动的时候，c[i,j]= max{c[i,k]+c[k,j]+1}  ak属于Sij,这里是遍历Sij的集合，然后求得最大兼容子集
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {

            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };

            int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };



            List<int>[,] result = new List<int>[13, 13];//默认值null

            for (int m = 0; m < 13; m++)

            {

                for (int n = 0; n < 13; n++)

                {

                    result[m, n] = new List<int>();

                }

            }//默认值是空list集合



            for (int j = 0; j < 13; j++)

            {

                for (int i = 0; i < j - 1; i++)

                {

                    //S[ij] i结束之后 j开始之前的活动集合

                    //f[i] s[j]这个时间区间内的所有活动

                    List<int> sij = new List<int>();

                    for (int number = 1; number < s.Length - 1; number++)

                    {

                        if (s[number] >= f[i] && f[number] <= s[j])

                            sij.Add(number);

                    }



                    if (sij.Count > 0)

                    {

                        //result[i,j] = max{ result[i,k]+result[k,j]+1}

                        int maxCount = 0;

                        List<int> tempList = new List<int>();

                        foreach (int number in sij)

                        {

                            int count = result[i, number].Count + result[number, j].Count + 1;

                            if (maxCount < count)

                            {

                                maxCount = count;

                                tempList = result[i, number].Union<int>(result[number, j]).ToList<int>();

                                tempList.Add(number);

                            }

                        }

                        result[i, j] = tempList;

                    }

                }

            }



            List<int> l = result[0, 12];

            foreach (int temp in l)

            {

                Console.WriteLine(temp);

            }

            Console.ReadKey();

        }

    }

}
