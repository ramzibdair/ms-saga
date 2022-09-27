using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Saga
{
    internal class OrderInstanse : SagaStateMachineInstance
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string Products { get; set; }
        public Guid CorrelationId { get; set; }
        public int CurrentState { get; set; }
    }
}
