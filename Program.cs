using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace ATSEmulator
{
    class Program
    {
      
        static void Main(string[] args)
        {
           
            try
            {
                string ip = ConfigurationManager.AppSettings["IPAddress"];
                int portNo = Int32.Parse(ConfigurationManager.AppSettings["PortNo"]);
                string message = Console.ReadLine();
                Console.WriteLine(message);
                //int port = 11000;

                IPAddress ipAddress = IPAddress.Parse(ip);

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, portNo);

                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);

                int bytesSent = sender.Send(msg);

                Console.WriteLine("Message sent to the server : {0}", message);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
