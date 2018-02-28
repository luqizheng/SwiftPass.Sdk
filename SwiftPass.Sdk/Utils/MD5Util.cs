using System;
using System.Security.Cryptography;
using System.Text;

namespace SwiftPass.Sdk.Utils
{
    /// <summary>
    /// MD5Util 的摘要说明。
    /// </summary>
    public class Md5Util
    {
        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr">需要签名的串</param>
        /// <param name="charset">编码</param>
        /// <returns>返回大写的MD5签名结果</returns>
        public static string GetMd5(string encypStr, string charset)
        {
            //创建md5对象
            byte[] inputBye;
            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
                Console.WriteLine(ex);
            }
            var m5 = MD5.Create();// new  MD5CryptoServiceProvider();
            var outputBye = m5.ComputeHash(inputBye);

            var retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
    }
}
