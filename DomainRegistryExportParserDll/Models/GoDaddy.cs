using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace DomainRegistryExportParserDll.Models
{
    public class Model
    {
        [Name("Auto-renew")] public string AutoRenew { get; set; }
        [Name("Domain Name")] public string DomainName { get; set; }

        [Name("Expiration Date")] public string ExpirationDate { get; set; }
        [Name("Lock")] public string Lock { get; set; }
        [Name("Privacy")] public string Privacy { get; set; }
    }

    public class Map : ClassMap<Model>
    {
        public Map()
        {
            Map(p => p.DomainName).Index(0);
            Map(p => p.ExpirationDate).Index(1);
            Map(p => p.AutoRenew).Index(2);
            Map(p => p.Privacy).Index(3);
            Map(p => p.Lock).Index(4);
        }
    }
}