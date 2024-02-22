using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public partial class Customer
    {
        public bool HasOutstandingOrders()
        {
            return orders.Count > 0;
        }
    }
}
