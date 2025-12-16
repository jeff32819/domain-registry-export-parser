using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using DomainRegistryExportParserDll.Models;

namespace DomainRegistryExportParserDll;

public static class Parse
{
    public static readonly CsvConfiguration Configuration = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        Delimiter = ","
    };

    public static List<NameCheap.Model> NameCheap(string txt)
    {
        var arr = new List<NameCheap.Model>();
        using var reader = new StringReader(txt);
        using var csv = new CsvReader(reader, Configuration);
        csv.Context.RegisterClassMap<NameCheap.Map>();
        var records = csv.GetRecords<NameCheap.Model>();
        foreach (var item in records)
        {
            Debug.Print(item.DomainName);
            if (!string.IsNullOrEmpty(item.DomainName))
            {
                arr.Add(item);
            }
        }

        return arr;
    }
}