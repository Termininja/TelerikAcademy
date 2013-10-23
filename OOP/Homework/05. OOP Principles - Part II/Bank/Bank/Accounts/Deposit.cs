namespace Bank
{
    class Deposit : Account
    {
        public Deposit(string customer, decimal balance, int interestRate)
            : base(customer, balance, interestRate) { }
    }
}