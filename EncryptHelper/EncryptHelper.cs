using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptHelper
{
    public static class EncryptHelper
    {
        /// <summary>
        /// 基于Md5的自定义加密字符串方法：输入一个字符串，返回一个由32个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string Md5(this string str)
        {
            //将输入字符串转换成字节数组
            var buffer = Encoding.Default.GetBytes(str);
            //接着，创建Md5对象进行散列计算
            var data = MD5.Create().ComputeHash(buffer);

            //创建一个新的Stringbuilder收集字节
            var sb = new StringBuilder();

            //遍历每个字节的散列数据
            foreach (var t in data)
            {
                //格式每一个十六进制字符串
                sb.Append(t.ToString("X2"));
            }

            //返回十六进制字符串
            return sb.ToString();
        }

        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string Sha1(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
