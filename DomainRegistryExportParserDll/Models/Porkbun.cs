using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace DomainRegistryExportParserDll.Models;

/// <summary>
///     Using export in list named 'Get CSV File w/o Auth Codes'
/// </summary>
public class Porkbun
{
    public class Model
    {
        [Name("DOMAIN")] public string Domain { get; set; } = string.Empty;
        [Name("TLD")] public string TLD { get; set; } = string.Empty;
        [Name("CREATE DATE")] public string CreateDate { get; set; } = string.Empty;
        [Name("EXPIRE DATE")] public string ExpireDate { get; set; } = string.Empty;
        [Name("LOCKED")] public string Locked { get; set; } = string.Empty;
        [Name("PRIVACY")] public string Privacy { get; set; } = string.Empty;
        [Name("AUTO RENEW")] public string AuthRenew { get; set; } = string.Empty;
        [Name("NAMESERVERS")] public string NameServers { get; set; } = string.Empty;
        [Name("AUTH CODE")] public string AuthCode { get; set; } = string.Empty;
        [Name("AUTH CODE CHANGED")] public string AuthCodeChanged { get; set; } = string.Empty;
        [Name("EST. RENEWAL PRICE")] public string EstRenewalPrice { get; set; } = string.Empty;
        [Name("STATUSES")] public string Statuses { get; set; } = string.Empty;
        [Name("URL FORWARDS")] public string UrlForwards { get; set; } = string.Empty;
    }

    public class Map : ClassMap<Model>
    {
        public Map()
        {
            Map(p => p.Domain).Index(0);
            Map(p => p.TLD).Index(1);
            Map(p => p.CreateDate).Index(2);
            Map(p => p.ExpireDate).Index(3);
            Map(p => p.Locked).Index(4);
            Map(p => p.Privacy).Index(5);
            Map(p => p.AuthRenew).Index(6);
            Map(p => p.NameServers).Index(7);
            Map(p => p.AuthCode).Index(8);
            Map(p => p.AuthCodeChanged).Index(9);
            Map(p => p.EstRenewalPrice).Index(10);
            Map(p => p.Statuses).Index(11);
            Map(p => p.UrlForwards).Index(12).Optional();
        }
    }
}