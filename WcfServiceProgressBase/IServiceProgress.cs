using System.ServiceModel;

namespace WcfServiceProgress
{
    /// <summary>
    /// Service with progress callback
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceProgressCallback))]
    public interface IServiceProgress
    {

        /// <summary>
        /// Does the process.
        /// </summary>
        [OperationContract]
        int DoProcess();
    }

    /// <summary>
    /// Callback interface for progress indication
    /// </summary>
    public interface IServiceProgressCallback
    {
        /// <summary>
        /// Delivers the progress.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>true, if process needs to be cancelled</returns>
        [OperationContract]
        bool DeliverProgress(string message);
    }
}
