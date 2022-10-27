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
            When(OrderStarted).Then(context =>
            {
                context.Saga.ID = context.Message.OrderID;
                context.Saga.UserName = context.Message.UserName;
                context.Saga.TotalPrice = context.Message.TotalPrice;
                context.Saga.Products = context.Message.Products;
            })
            .TransitionTo(Started)) ;

            When(OrderValidate).Then(context =>
            {
                context.Saga.ID = context.Message.OrderID;
                context.Saga.OrderID = context.Message.OrderID;
            }).TransitionTo(inValidateProcess);

            When(OrderCanceled).Then(context =>
            {
                context.Saga.ID = context.Message.OrderID;
                context.Saga.OrderID = context.Message.OrderID;
            }).TransitionTo(canceled);

            When(OrderCompleted).Then(context =>
            {
                context.Saga.ID = context.Message.OrderID;
                context.Saga.OrderID = context.Message.OrderID;
            }).TransitionTo(Completed);

        }
        public State Started { get; }
        public State inValidateProcess {  get; }
        public State canceled { get; }
        public State Completed { get; }
        

        public Event<IOrderStarted> OrderStarted { get; }
        public Event<IOrderValidate> OrderValidate { get; }
        public Event<IOrderCanceled> OrderCanceled { get; }
        public Event<IOrderCompleted> OrderCompleted { get; }
    }
}
