using NumberGenerator;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Net;


internal class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        string baseUrl = configuration["ApiSettings:BaseUrl"];

        Do(baseUrl);
    }

    private static void Do(string BaseUrl)
    {
        GeneratorNums generator = new GeneratorNums();

        (List<int> GenList, List<int> SortList) = generator.Generate();

        Console.WriteLine("Список случайных чисел");

        foreach (var item in GenList)
            Console.Write(item + " ");

        Console.WriteLine();
        Console.WriteLine("Список отсортированных случайных чисел");

        foreach (var item in SortList)
            Console.Write(item + " ");

        string json = JsonSerializer.Serialize(SortList);

        ConsoleApp.HttpRequestHelper.GetRequest(json, BaseUrl);

        Console.ReadKey();
    }

}