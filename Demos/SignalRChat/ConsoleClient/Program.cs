using Microsoft.AspNet.SignalR.Client;
using System;

namespace ConsoleClient
{
    class Program
    {
        private static void Main(string[] args)
        {
            string conn = "http://localhost:52464/";
            //conn = "http://daxfirstcloud.azurewebsites.net/";
            
            //Set connection
            var connection = new HubConnection(conn);
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("ChatHub");
            //Start connection

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            myHub.On<string,string>("addNewMessageToPage", (s,m) =>
            {
                Console.WriteLine("{0} sagt: {1}", s,m);
            });

            string input = "";
            while ((input = Console.ReadLine()) != "")
            {
                myHub.Invoke<string>("Send", "Console Client", input).Wait();
            }
            connection.Stop();
        }
    }
}
