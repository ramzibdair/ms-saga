using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Order
{
    public interface IOrderCompleted
    {
         Guid OrderID { get; set; }
    }
}
