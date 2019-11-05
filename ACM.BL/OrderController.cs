using Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    /// <summary>
    /// Manages all order processing features.
    /// </summary>
    public class OrderController
    {
        private CustomerRepository customerRepository { get; set; }
        private OrderRepository orderRepository { get; set; }
        private InventoryRepository inventoryRepository { get; set; }
        private EmailLibrary emailLibrary { get; set; }

        /// <summary>
        /// Constructs an instance of the order controller
        /// </summary>
        public OrderController()
        {
            customerRepository = new CustomerRepository();
            orderRepository = new OrderRepository();
            inventoryRepository = new InventoryRepository();
            emailLibrary = new EmailLibrary();
        }

        /// <summary>
        /// Places a customer's order.
        /// </summary>
        public OperationResult PlaceOrder(Customer customer, 
                                Order order, 
                                Payment payment, 
                                bool allowSplitOrders, bool emailReceipt)
        {
            Debug.Assert(customerRepository!=null, "Missing customer respository instance");
            Debug.Assert(orderRepository != null, "Missing order repository instance");
            Debug.Assert(inventoryRepository != null, "Missing inventory repository instance");
            Debug.Assert(emailLibrary != null, "Missing email library instance");

            if (customer == null) throw new ArgumentNullException("Customer instance is null");
            if (order == null) throw new ArgumentNullException("Order instance is null");
            if (payment == null) throw new ArgumentNullException("Payment instance is null");

            var op = new OperationResult();
           
            customerRepository.Add(customer);
            orderRepository.Add(order);
            inventoryRepository.OrderItems(order, allowSplitOrders);
            payment.ProcessPayment();

            if (emailReceipt)
            {
                var result = customer.ValidateEmail();
                if (result.Success)
                {
                    emailLibrary.SendEmail(customer.EmailAddress,
                                            "Here is your receipt");
                }
                else
                {
                    // log the messages
                    if (result.MessageList.Any())
                    {
                        op.AddMessage(result.MessageList[0]);
                    }
                }
            }
            return op;
        }
    }
}
