namespace Bank
{
    class Mortgage : Account
    {
        // Constructor
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        // Override the basic InterestAmount method from Account class
        public override decimal InterestAmount(int months)
        {
            // Have ½ interest for the first 12 months for companies
            if (Customer is Company)
            {
                if (months > 12) return base.InterestAmount(months);
                else return base.InterestAmount(months) / 2;
            }

            // Have interest after first 6 months for individuals
            if (Customer is Individual && months > 6)
            {
                return base.InterestAmount(months);
            }
            
            // No interest for any other case
            return 0;
        }
    }
}