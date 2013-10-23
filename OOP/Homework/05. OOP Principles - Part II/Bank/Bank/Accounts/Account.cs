namespace Bank
{
    class Account
    {
        public string Customer { get; set; }
        public decimal Balance { get; set; }
        public int InterestRate { get; set; }

        public Account(string customer, decimal balance, int interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public decimal InterestAmount(int months)
        {
            return months * InterestRate;
        }
    }
}
