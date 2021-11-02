/// Week 10 Lab 1
///
/// @author: Julian Trupe
/// Date:  October 31, 2021
///
/// Problem Statement: Create a Payment class and two derived classes, test derived clasees in the main method
//
/// Overall Plan:
/// 1) Create Payment class with ammount property, getter/setter, PaymentDetails method
/// 2) Create derived CashPayment class with and override PaymentDetails method
/// 3) Create derived CreditCardPayment class with properties for name, card number, and override PaymentDetails method
/// 4) Test CashPayment and CreditCardPayment classes, display results to console


using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We will test a few classes:");
            CashPayment cash1 = new CashPayment(20);
            CashPayment cash2 = new CashPayment(30);
            CreditCardPayment card1 = new CreditCardPayment(50, "Julian Trupe", "5510 2312 1514 9089");
            CreditCardPayment card2 = new CreditCardPayment();
            card2.Amount = 40;
            cash1.PaymentDetails();
            cash2.PaymentDetails();
            card1.PaymentDetails();
            card2.PaymentDetails();
        }
    }

    class Payment
    {
        double amount;

        public Payment()
        {
            amount = 0;
        }

        public Payment(double money)
        {
            this.Amount = money;
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public void PaymentDetails()
        {
            Console.WriteLine("Payment is $" + Amount);
        }
    }

    class CashPayment : Payment
    {
        public CashPayment(double money)
        {
            this.Amount = money;
        }
        public void PaymentDetails()
        {
            Console.WriteLine("Payment is $" + Amount + " in cash");
        }
    }

    class CreditCardPayment : Payment
    {
        string cardHolderName;
        string cardNo;

        public CreditCardPayment(double money, string name, string cardNum)
        {
            this.cardHolderName = name;
            this.cardNo = cardNum;
            this.Amount = money;
        }
        
        public CreditCardPayment()
        {
            cardHolderName = "John Doe";
            cardNo = "1234 5678 9011 1213";
        }

        public void PaymentDetails()
        {
            Console.WriteLine(cardHolderName + " paid $" + Amount + " using credit card number " + cardNo);
        }
    }
}
