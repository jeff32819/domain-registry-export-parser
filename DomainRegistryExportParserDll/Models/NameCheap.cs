using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace DomainRegistryExportParserDll.Models
{
    public class NameCheap
    {
        public class Model
        {
            [Name("Domain Name")] public string DomainName { get; set; } = string.Empty;
            [Name("Domain privacy protection status")] public string DomainPrivacyProtectionStatus { get; set; } = string.Empty;
            [Name("Domain status at NC")] public string DomainStatusAtNC { get; set; } = string.Empty;
            [Name("Domain auto-renew status")] public string DomainAutoRenewStatus { get; set; } = string.Empty;
            [Name("Domain expiration date")] public string DomainExpirationDate { get; set; } = string.Empty;
            /// <summary>
            /// Calculated DateTime from imported string
            /// </summary>
            public DateTime ExpirationDate => DateTime.ParseExact(
                DomainExpirationDate,
                "MMM dd yyyy",
                CultureInfo.InvariantCulture
            );

        }

        public class Map : ClassMap<Model>
        {
            public Map()
            {
                Map(p => p.DomainName).Index(0);
                Map(p => p.DomainPrivacyProtectionStatus).Index(1);
                Map(p => p.DomainStatusAtNC).Index(2);
                Map(p => p.DomainAutoRenewStatus).Index(3);
                Map(p => p.DomainExpirationDate).Index(4);
            }
        }
    }
}
