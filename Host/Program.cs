using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Service.SelfHostService;
using MarketPlace.Service.SelfHostService.ErrorHandler;

namespace Host
{
    public class Program
    {
        public static void Main()
        {
            using (var host = new ServiceHost(typeof(MarketPlaceService)))
            {
                host.Description.Behaviors.Add(new MainErrorHandlerBehavior());
                host.Open(); 

                Console.WriteLine("Host opened");
                Console.Read();
            }
        }
    }
}
