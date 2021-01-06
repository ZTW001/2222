using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInfo
{
    /// <summary>
    /// 银行信息
    /// </summary>
    public class BankInfo
    {
        #region 数组形式存储银行BIN号

        /// <summary>
        /// 银行 BIN 号
        /// </summary>
        private readonly static long[] BankBin =
        {
            102033,
            103000,
            185720,
            303781,
            356827,
            356828,
            356833,
            356835,
            356837,
            356838,
            356839,
            356840,
            356885,
            356886,
            356887,
            356888,
            356889,
            356890,
        };

        /// <summary>
        /// 发卡行.卡种名称
        /// </summary>
        private static readonly string[] BankName =
        {
            "广东发展银行.广发理财通",
            "农业银行.金穗借记卡",
            "昆明农联社.金碧卡",
            "中国光大银行.阳光爱心卡",
            "上海银行.双币种申卡贷记卡个人金卡",
            "上海银行.双币种申卡贷记卡个人普卡",
            "中国银行.中银JCB卡金卡",
            "中国银行.中银JCB卡普卡",
            "中国光大银行.阳光商旅信用卡",
            "中国光大银行.阳光商旅信用卡",
            "中国光大银行.阳光商旅信用卡",
            "中国光大银行.阳光商旅信用卡",
            "招商银行.招商银行银行信用卡",
            "招商银行.招商银行银行信用卡",
            "招商银行.招商银行银行信用卡",
            "招商银行.招商银行银行信用卡",
            "招商银行.招商银行银行信用卡",
            "招商银行.招商银行银行信用卡",

        };

        #endregion

        #region public static string GetBankName：获取发卡行.卡种名称

        public static string GetBankName(char[] charBin, int offset = 0)
        {
            long longBin = 0;
            for (var i = 0; i < 6; i++)
            {
                longBin = (longBin * 10) + (charBin[i + offset] - 48);
            }

            Console.WriteLine("BankBin: " + longBin);

            var index = BinarySearch(BankBin, longBin);
            if (index == -1)
            {
                return "暂无所属发卡行信息:\n";
            }
            return BankName[index] + ":\n";
        }
        #endregion

        #region private static int BinarySearch：二分法查找

        private static int BinarySearch(IReadOnlyList<long> srcArray, long des)
        {
            int low = 0;
            int high = srcArray.Count - 1;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (des == srcArray[middle])
                {
                    return middle;
                }
                if (des < srcArray[middle])
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return -1;
        }
        #endregion
    }
}
