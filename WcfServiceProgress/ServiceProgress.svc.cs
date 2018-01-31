
using System;
using System.ServiceModel;
using System.Threading;

namespace WcfServiceProgress
{
    /// <summary>
    /// Service with progress callback
    /// </summary>
    /// <seealso cref="WcfServiceProgress.IServiceProgress" />
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServiceProgress : IServiceProgress
    {

        /// <summary>
        /// Does the process.
        /// </summary>
        public int DoProcess()
        {
            int i;
            for (i=0; i<10; i++)
            {
                try
                {
                    if (OperationContext.Current.GetCallbackChannel<IServiceProgressCallback>()
                        .DeliverProgress(DateTime.Now.ToLongTimeString()))
                    {
                        Console.WriteLine("Client requested stop");
                        break;
                    }
                    Thread.Sleep(1000);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Server DoProcess Exception: " + exception.Message);                    
                }
            }

            return i;
        }

    }
}
