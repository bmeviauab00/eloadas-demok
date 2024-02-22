using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public partial class Customer
    {
        private int id;
        private string name;
        private List<Order> orders;

        public void SubmitOrder(Order order)
        {
            orders.Add(order);
        }
    }

    public class Order { }

}
