using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;

namespace MarketPlace.Service.SelfHostService.ErrorHandler
{
    public class MainErrorHandler: IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            var fltEx = new FaultException(error.Message, new FaultCode("InnerServiceException"));
            var msg = fltEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msg, "null");
        }

        public bool HandleError(Exception error)
        {
            Console.WriteLine(error.Message);
            return true;
        }

    }
}
