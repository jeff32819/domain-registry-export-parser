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
        Delimiter = ",",
        MissingFieldFound = null
    };
    /// <summary>
    /// Removes the first line from text
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static string RemoveFirstLineFromText(string txt)
    {
        var lines = txt.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        return string.Join(Environment.NewLine, lines.Skip(1));
    }

    /// <summary>
    /// Namecheap export
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Porkbun process export, currently set for 'Get CSV File w/o Auth Codes'
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static List<Porkbun.Model> Porkbun(string txt)
    {
        txt = RemoveFirstLineFromText(txt); // 1st line has warning: Please note that renewal prices are estimates based on current renewal rates.
        var arr = new List<Porkbun.Model>();
        using var reader = new StringReader(txt);
        using var csv = new CsvReader(reader, Configuration);
        csv.Context.RegisterClassMap<Porkbun.Map>();
        var records = csv.GetRecords<Porkbun.Model>();
        foreach (var item in records)
        {
            Debug.Print(item.Domain);
            if (!string.IsNullOrEmpty(item.Domain))
            {
                arr.Add(item);
            }
        }
        return arr;
    }
}