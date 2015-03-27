namespace Bank
{
    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public void Withdraw(decimal amount)
        {
            base.Balance -= amount;
        }

        public override decimal InterestAmount(int months)
        {
            // Have interest if the balance is equal or more than 1000
            if (base.Balance >= 1000)
            {
                return base.InterestAmount(months);
            }

            // No interest for any other case
            return 0;
        }
    }
}