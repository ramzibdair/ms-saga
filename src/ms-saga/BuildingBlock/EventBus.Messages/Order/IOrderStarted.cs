using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Order
{
    public interface IOrderStarted
    {
         Guid OrderID { get; set; }
         string UserName { get; set; }
         decimal TotalPrice { get; set; }
         string Products { get; set; }
    }
}
