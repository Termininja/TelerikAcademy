namespace Bank
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal InterestAmount(int months)
        {
            // Have interest after first 3 months for individuals and after first 2 months for a company
            if (base.Customer is Individual && months > 3 || base.Customer is Company && months > 2)
            {
                return base.InterestAmount(months);
            }

            // No interest for any other case
            return 0;
        }
    }
}