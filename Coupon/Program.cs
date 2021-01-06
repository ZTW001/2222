using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Coupon
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"demo1.txt";
            //var coupon = new Coupon(10000, 0.2f, 1, "TiAmoZhang");

            //判断该文件是否存在
            if (!File.Exists(fileName))
            {
                return;
            }

            //判断该文件是否存在
            using (var stream = File.Create(fileName))
            {
                var deserializer = new BinaryFormatter();  //二进制格式序列化器
                var coupon = deserializer.Deserialize(stream) as Coupon;    //反序列化

                if (coupon == null)
                {
                    return;
                }

                Console.WriteLine($"{nameof(Coupon)}:");
                Console.WriteLine($"{nameof(coupon.Amount)}: {coupon.Amount}");
                Console.WriteLine($"{nameof(coupon.InterestRate)}: {coupon.InterestRate}%");
                Console.WriteLine($"{nameof(coupon.Term)}: {coupon.Term}");
                Console.WriteLine($"{nameof(coupon.Name)}: {coupon.Name}");
            }
            Console.Read();
        }
    }
}
