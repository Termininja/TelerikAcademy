using System;
using System.Drawing;

namespace Bank
{
    abstract class Account
    {
        #region Properties
        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; protected set; }
        #endregion

        #region Constructor
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        #endregion

        #region Methods
        // All accounts are allowed to deposit money
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        // Interest amount for a given period
        public virtual decimal InterestAmount(int months)
        {
            return this.Balance * months * this.InterestRate;
        }

        // Override to string method
        public override string ToString()
        {
            return
                "Type: " + this.Customer.GetType().Name +
                "\nCustomer: " + this.Customer.ToString() +
                "\nBalance: " + this.Balance +
                "\nInterest rate: " + this.InterestRate;
        }
        #endregion
    }
}
