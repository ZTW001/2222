using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcpserver
{
    /// <summary>
    /// Class1 的摘要说明。
    /// </summary>
    class server
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //
            // TODO: 在此处添加代码以启动应用程序
            //
            int recv;//用于表示客户端发送的信息长度
            byte[] data = new byte[1024];//用于缓存客户端所发送的信息,通过socket传递的信息必须为字节数组
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);//本机预使用的IP和端口
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);//绑定
            newsock.Listen(10);//监听
            Console.WriteLine("waiting for a client");
            Socket client = newsock.Accept();//当有可用的客户端连接尝试时执行，并返回一个新的socket,用于与客户端之间的通信
            IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("connect with client:" + clientip.Address + " at port:" + clientip.Port);
            string welcome = "welcome here!";
            data = Encoding.ASCII.GetBytes(welcome);
            client.Send(data, data.Length, SocketFlags.None);//发送信息
            while (true)
            {//用死循环来不断的从客户端获取信息
                data = new byte[1024];
                recv = client.Receive(data);
                Console.WriteLine("recv=" + recv);
                if (recv == 0)//当信息长度为0，说明客户端连接断开
                    break;
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                client.Send(data, recv, SocketFlags.None);
            }
            Console.WriteLine("Disconnected from" + clientip.Address);
            client.Close();
            newsock.Close();

        }
    }
}
