namespace Bank
{
    class Mortgage : Account
    {
        public Mortgage(string customer, decimal balance, int interestRate)
            : base(customer, balance, interestRate) { }
    }
}