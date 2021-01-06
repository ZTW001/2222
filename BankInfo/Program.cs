using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("输入银行卡号：\n");
                var cardStr = Console.ReadLine();
                if (cardStr == null) continue;

                var cardNumber = cardStr.ToCharArray();
                var name = BankInfo.GetBankName(cardNumber); //获取银行卡的信息
                Console.WriteLine(name);
            }
        }
    }
}
