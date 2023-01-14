using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLife.Data;
using NewLife.Remoting;

namespace RpcTest
{
    /// <summary>自定义业务客户端</summary>
    class MyClient : ApiClient
    {
        public MyClient(String uri) : base(uri) { }

        /// <summary>添加，标准业务服务，走Json序列化</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public async Task<Int32> AddAsync(Int32 x, Int32 y)
        {
            return await InvokeAsync<Int32>("My/Add", new { x, y });
        }

        /// <summary>RC4加解密，高速业务服务，二进制收发不经序列化</summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public async Task<Packet> RC4Async(Packet pk)
        {
            return await InvokeAsync<Packet>("My/RC4", pk);
        }
        public async Task<Packet> TestString(Packet inParam)
        {
            return await InvokeAsync<Packet>("My/TestString", inParam);
        }

        public async Task<string> TestString1()
        {
            return await InvokeAsync<string>("My/TestString1");
        }
        public async Task<string> TestString2()
        {
            return await InvokeAsync<string>("My/TestString1");
        }
        public async Task<string> TestString3(string param1)
        {
            var result = await InvokeAsync<Packet>("My/TestString3", new { param1 });
            var resultstring = System.Text.Encoding.UTF8.GetString(result.ToArray()).TrimEnd('\0');
            return resultstring;
        }
        public async Task<string> TestString4(string param1, string param2, User paramUser, bool paramBool)
        {
            var result = await InvokeAsync<Packet>("My/TestString4", new { param1, param2, paramUser, paramBool });
            var resultstring = System.Text.Encoding.UTF8.GetString(result.ToArray()).TrimEnd('\0');
            return resultstring;
        }

        public async Task<User> FindUserAsync(Int32 uid, Boolean enable)
        {
            return await InvokeAsync<User>("User/FindByID", new { uid, enable });
        }
    }
}