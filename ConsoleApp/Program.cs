

using DomainRegistryExportParserDll.Models;

var txt = System.IO.File.ReadAllText(@"C:\Users\Jeff\Downloads\1165491.98b14c5dcf38eeb33800a163c29fdae6a9f86aad96e5504eb2b51492a3a564b3.domains.csv");
var result = DomainRegistryExportParserDll.Parse.Porkbun(txt);
foreach (var item in result)
{
    Console.WriteLine(item.Domain);
    
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Press any key");
Console.ReadKey();