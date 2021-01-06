using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string s = "123456";
            Console.WriteLine("密码：" + s);

            Console.WriteLine("Md5：" + s.Md5());
            Console.WriteLine("长度：" + s.Md5().Length);

            Console.WriteLine("Sha1：" + s.Sha1());
            Console.WriteLine("长度：" + s.Sha1().Length);

            Console.Read();
        }
    }
}
