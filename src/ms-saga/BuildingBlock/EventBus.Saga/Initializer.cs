using EventBus.Messages.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Saga
{
    public static class Initializer
    {
        static bool _initilized;

        public static void initialize()
        {
            if (!_initilized)
            {
                _initilized = true;
                GlobalTopology.Send.UseCorrelationId<IOrderStarted>(x => x.OrderID);
                GlobalTopology.Send.UseCorrelationId<IOrderValidate>(x => x.OrderID);
            }
            return; 
        }
    }
}
