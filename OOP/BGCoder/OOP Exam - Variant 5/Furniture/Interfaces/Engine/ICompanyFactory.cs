namespace FurnitureManufacturer
{
    public interface ICompanyFactory
    {
        ICompany CreateCompany(string name, string registrationNumber);
    }
}
