using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ACM.BL
{
    /// <summary>
    /// Type of payments accepted by the system
    /// </summary>
    public enum PaymentType
    {
        CreditCard = 1,
        PayPal = 2
    }

    /// <summary>
    /// Manages a payment.
    /// </summary>
    public class Payment
    {
        public int PaymentType { get; set; }

        /// <summary>
        /// Process a payment for an order
        /// </summary>
        public void ProcessPayment()
        {
            PaymentType paymentTypeOption;
            if (!Enum.TryParse(this.PaymentType.ToString(), out paymentTypeOption))
            {
                throw new InvalidEnumArgumentException("Payment type", (int)this.PaymentType, typeof(PaymentType));
            }

            switch (paymentTypeOption)
            {

                case ACM.BL.PaymentType.CreditCard:
                    // Process credit card
                    break;

                case ACM.BL.PaymentType.PayPal:
                    // Process PayPal
                    break;

                default:
                    throw new ArgumentException();
            }

            // Open a connection
            // Set stored procedure parameters with the payment data.
            // Call the save stored procedure.

        }
    }
}
