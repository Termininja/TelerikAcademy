namespace Bank
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal InterestAmount(int months)
        {
            // Have ½ interest for the first 12 months for companies
            if (base.Customer is Company)
            {
                return base.InterestAmount(months) / (months > 12 ? 1 : 2);
            }

            // Have interest after first 6 months for individuals
            if (base.Customer is Individual && months > 6)
            {
                return base.InterestAmount(months);
            }

            // No interest for any other case
            return 0;
        }
    }
}