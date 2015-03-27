namespace Bank
{
    public abstract class Account
    {
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; protected set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual decimal InterestAmount(int months)
        {
            var amount = this.Balance * months * this.InterestRate;

            return amount;
        }

        public override string ToString()
        {
            var result = string.Format("Type: {0}\nCustomer: {1}\nBalance: {2}\nInterest rate: {3}",
                this.Customer.GetType().Name, this.Customer.ToString(), this.Balance, this.InterestRate);

            return result;
        }
    }
}
