using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Musicalog.API.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8000/Musicalog.API/");
            var selfHost = new ServiceHost(typeof(AlbumService), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IAlbumService), new WSHttpBinding(), "AlbumService");

                // Step 4: Enable metadata exchange.
                selfHost.Description.Behaviors.Add(new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                });

                // Step 5: Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine($"An exception occurred: {e.Message}");
                selfHost.Abort();
            }
        }
    }
}
