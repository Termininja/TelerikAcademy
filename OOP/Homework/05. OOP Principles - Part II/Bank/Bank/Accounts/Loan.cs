namespace Bank
{
    class Loan : Account
    {
        // Constructor
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        // Override the basic InterestAmount method from Account class
        public override decimal InterestAmount(int months)
        {
            // Have interest after first 3 months for individuals and after first 2 months for a company
            if (Customer is Individual && months > 3 || Customer is Company && months > 2)
            {
                return base.InterestAmount(months);
            }

            // No interest for any other case
            return 0;
        }
    }
}