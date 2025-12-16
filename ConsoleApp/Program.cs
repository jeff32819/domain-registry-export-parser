

var txt = System.IO.File.ReadAllText(@"C:\Users\Jeff\Downloads\Domain_List.csv");
var result = DomainRegistryExportParserDll.Parse.NameCheap(txt);
foreach (var item in result)
{
    Console.WriteLine(item.DomainName);
    Console.WriteLine(item.DomainExpirationDate);
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Press any key");
Console.ReadKey();