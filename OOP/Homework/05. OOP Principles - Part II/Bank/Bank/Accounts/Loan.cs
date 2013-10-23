namespace Bank
{
    class Loan : Account
    {

        public Loan(string customer, decimal balance, int interestRate)
            : base(customer, balance, interestRate) { }

    }
}