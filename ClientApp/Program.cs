using System;
using System.ServiceModel;
using System.Threading;

namespace ClientApp
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var instanceContext = new InstanceContext(new CallbackHandler());
            var service = new ServiceReference.ServiceProgressClient(instanceContext);

            do
            {
                Console.WriteLine("Press any key to stop the application!");
                Console.WriteLine("Client calls Service DoProcess");
                try
                {
                    service.DoProcess();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Client exception message:" + exception.Message);
                }
                Console.WriteLine("Service returned from DoProcess");
                Thread.Sleep(1000);
            } while (!Console.KeyAvailable);
        }
    }
}
