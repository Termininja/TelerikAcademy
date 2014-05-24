namespace Bank
{
    class Deposit : Account
    {
        // Constructor
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        // Only deposit accounts are allowed to withdraw money
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        // Override the basic InterestAmount method from Account class
        public override decimal InterestAmount(int months)
        {
            // Have interest if the balance is equal or more than 1000
            if (Balance >= 1000) return base.InterestAmount(months);

            // No interest for any other case
            return 0;
        }
    }
}