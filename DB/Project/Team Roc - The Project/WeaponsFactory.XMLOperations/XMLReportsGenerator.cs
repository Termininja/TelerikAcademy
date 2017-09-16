﻿namespace WeaponsFactory.XMLOperations
{
    using System.Linq;
    using System.Xml.Linq;

    using WeaponsFactory.Data;

    public static class XMLReportsGenerator
    {
        public static void GenerateSalesReport(IWeaponsFactoryData db, string fullFilePath)
        {
            var sales = db.Sales.All().ToList();

            var xdoc = new XDocument(new XElement("Sales",
                    from sale in sales
                    select new XElement("sale",
                        new XAttribute("VendorId", sale.VendorId),
                        new XElement("summary",
                            new XAttribute("date", sale.Date),
                            new XAttribute("weaponId", sale.WeaponId),
                            new XAttribute("quantity", sale.Quantity),
                            new XAttribute("unit-price", sale.UnitPrice)))));

            xdoc.Save(fullFilePath);
        }
    }
}
