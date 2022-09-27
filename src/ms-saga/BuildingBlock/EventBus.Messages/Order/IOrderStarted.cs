﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Order
{
    public interface IOrderStarted
    {
        public Guid OrderID { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string Products { get; set; }
    }
}
