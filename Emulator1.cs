using System;
using System.Net.Sockets;
using System.Linq;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace ATSEmulator
{
    public class Emulator1
    {

     
        public Emulator1()
        {
            try
            {

                string message = Console.ReadLine();
                int port = 11000;

                IPAddress ipAddress = IPAddress.Parse("10.22.6.33");

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

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
