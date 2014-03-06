namespace FurnitureManufacturer
{
    public class CompanyFactory : ICompanyFactory
    {
        // Method
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}
