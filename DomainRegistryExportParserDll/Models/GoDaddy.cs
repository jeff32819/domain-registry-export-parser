using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace DomainRegistryExportParserDll.Models
{
    /// <summary>
    /// NOT tested, since I don't use GoDaddy. At one time it worked.
    /// </summary>
    public class Model
    {
        [Name("Auto-renew")] public string AutoRenew { get; set; } = string.Empty;
        [Name("Domain Name")] public string DomainName { get; set; } = string.Empty;

        [Name("Expiration Date")] public string ExpirationDate { get; set; } = string.Empty;
        [Name("Lock")] public string Lock { get; set; } = string.Empty;
        [Name("Privacy")] public string Privacy { get; set; } = string.Empty;
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