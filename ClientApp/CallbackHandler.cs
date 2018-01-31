using System;
using ClientApp.ServiceReference;

namespace ClientApp
{
    /// <summary>
    /// Callback handler
    /// </summary>
    /// <seealso cref="ClientApp.ServiceReference.IServiceProgressCallback" />
    public class CallbackHandler : IServiceProgressCallback
    {

        /// <summary>
        /// Deliver progress.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public bool DeliverProgress(string message)
        {
            Console.WriteLine("Client receives Message: " + message);
            return Console.KeyAvailable;
        }
    }
}