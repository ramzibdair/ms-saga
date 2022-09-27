using EventBus.Messages.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Saga.OrderStateMachine
{
    internal class OrderStateMachine : MassTransitStateMachine<OrderInstanse>
    {
        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState, Started);

            Initially(
                When(OrderStarted)
                .Then(context =>
                {
                    context.Saga.ID = context.Message.OrderID;
                    context.Saga.UserName = context.Message.UserName;
                    context.Saga.TotalPrice = context.Message.TotalPrice;
                    context.Saga.Products = context.Message.Products;
                })
                .TransitionTo(Started));

    
                
        }
        public State Started { get; }
        public State Preparing {  get; }
        public State Completed { get; }

        public Event<IOrderStarted> OrderStarted { get; }
        public Event<IOrderValidate> OrderValidated { get; }
    }
}
