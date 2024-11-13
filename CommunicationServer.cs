using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Security.Policy;


using System.Net.NetworkInformation;
using System.Management;
using System;
using System.Net;
using System.Net.Sockets;

namespace OneCRM
{
    public class CommunicationServer
    {
        private Func<string, string> savedataCallback;  
        public CommunicationServer()
        {
   
        }       
        public CommunicationServer(Func<string, string> callback)
        {
            savedataCallback = callback;
        }   
        private static int FindAvailablePort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }


        public  void StartServer()
        {
           
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);
            string Ip = ipAddresses[2].ToString();
         
            int port = 49510;

            IPAddress localIPv6Loopback = IPAddress.IPv6Loopback;

            // Convert it to a string in the [::1] format
            string ipv6LoopbackString = localIPv6Loopback.ToString();

           // TcpListener server = new TcpListener(IPAddress.Parse(ipv6LoopbackString), port);
           TcpListener server = new TcpListener(IPAddress.Any, port);

            try
            {

                server.Start();

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected to a client.");
                    NetworkStream stream = client.GetStream();

                    // Message to send to the client
                    string messageToClient = "Hello, client! This is a message from the server.";
                    byte[] messageBytes = Encoding.ASCII.GetBytes(messageToClient);

                    // Send the message to the client
                    stream.Write(messageBytes, 0, messageBytes.Length);

                    var clientHandler = new ClientHandler(client);
           
                    System.Threading.Thread clientThread = new System.Threading.Thread(clientHandler.HandleClient);
                    clientThread.Start();
                   
             
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                server.Stop();
            }

           

        }

       

        class ClientHandler
        {
            private TcpClient client;
          
            public ClientHandler(TcpClient client)
            {
                this.client = client;
            }


            public void HandleClient()
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                      
                        string[] parts = data.Split(',');
                        string PhoneNumber = parts[0].ToString();
                        string Operation = parts[1].ToString();
              

                 
                        if (Operation == "Call_Dile")
                        {
                            
                        }
                        if (Operation == "Call_HangUp")
                        {
                           // serverobj.CallDissxonnect();
                        }
                        // Echo the data back to the client
                        byte[] sendData = Encoding.ASCII.GetBytes(data);
                        stream.Write(sendData, 0, sendData.Length);
                    }

                    client.Close();
                    Console.WriteLine("Client disconnected.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        private async void StartNamedPipeServerAsync()
        {
            await Task.Run(() =>
            {
                //communicationServer.StartServer();
            });
        }
        private void savedata(string message)
        {
            //New_CTI c = new New_CTI();
            ////string result = c.savedata(message);
            //c.CallDileMethod();


            //return "Processed: " ;
        }


    }
}
