using System;
using NewLife;
using NewLife.Data;

namespace RpcTest
{
    /// <summary>自定义控制器。包含多个服务</summary>
    class MyController
    {
        /// <summary>添加，标准业务服务，走Json序列化</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Int32 Add(Int32 x, Int32 y) => x + y;

        /// <summary>RC4加解密，高速业务服务，二进制收发不经序列化</summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public Packet RC4(Packet pk)
        {
            var data = pk.ToArray();
            var pass = "NewLife".GetBytes();

            return data.RC4(pass);
        }

        public Packet TestString(Packet inParam)
        {
            var inString = System.Text.Encoding.UTF8.GetString(inParam.ToArray()).TrimEnd('\0');
            var result = inString + inString;
            return result.GetBytes();
        }

        /// <summary>
        /// Test1: 一个string类型返回参数 12345---89789， 返回结果变成
        /// </summary>
        /// <returns></returns>
        public string TestString1()
        {
            string result = "12345---89789";
            // string result = "中文字符串";
            return result;
        }
        /// <summary>
        /// Test2: 一个string类型返回参数, 中文字符串，返回报错
        /// </summary>
        /// <returns></returns>
        public string TestString2()
        {
            string result = "中文字符串";
            return result;
        }
        /// <summary>
        /// Test3: 两个输入string参数
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public Packet TestString3(string param1, string param2)
        {
            string result = param1+ param2;
            return result.GetBytes();
        }
        /// <summary>
        /// Test3: 两个输入string参数
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public Packet TestString4(string param1, string param2, User paramUser, bool paramBool)
        {
            string result = param1 + param2 + paramUser.Name+ paramBool.ToString();
            return result.GetBytes();
        }
    }
}