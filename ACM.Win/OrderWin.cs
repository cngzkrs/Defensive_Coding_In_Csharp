using ACM.BL;
using System;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class OrderWin : Form
    {

        public OrderWin()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                button.Text = "Processing ...";
            }

            PlaceOrder();
        }

        private void PlaceOrder()
        {
            var customer = new Customer();
            // Populate the customer instance

            var order = new Order();
            // Populate the order instance

            var payment = new Payment();
            // Populate the payment info from the UI

            var orderController = new OrderController();

            try
            {
                var op = orderController.PlaceOrder(customer, order, payment, 
                    allowSplitOrders:false, 
                    emailReceipt:true);
            }
            catch (ArgumentNullException ex)
            {
                // log the issue
                // display a message to the user
                // that the order was not successful
            }
        }

    }
}