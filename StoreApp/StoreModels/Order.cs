using System;
namespace StoreModels
{
    /// <summary>
    /// This class contains all the necessary fields and properties for customer orders 
    /// </summary>
    public class Order
    {
        //Fields
        private int orderID;
        private double total;
        private DateTime date;
        private Customer customer;
        private Location location;

        //Constructor(s)
        public Order()
        {
            this.date = DateTime.Now;
        }
        public Order(DateTime date)
        {
            this.date = date;
        }
        

        //Properties
        public int OrderID
        {
            get {return orderID;}
            set {orderID = value;}
        }
        public double Total
        {
            get {return Math.Round(total,2);}
            set { total = Math.Round(value, 2); }
        }
        public DateTime Date
        {
            get{return date;}
            set{date = value;}
        }
        public Customer Customer
        {
            get {return customer;}
            set {customer = value;}
        }
        public Location Location
        {
            get {return location;}
            set {location = value;}
        }
        public int CustomerCustID { get; set; }
        public int LocationID { get; set; }
        //Methods
        public override string ToString()
        {
            return $"Order ID: {this.OrderID} \n\tTotal: ${this.Total}\n\tDate: {this.Date}";
        }
    }
}