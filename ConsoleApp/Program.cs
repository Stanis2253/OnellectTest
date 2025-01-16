using NumberGenerator;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Net;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        string baseUrl = configuration["ApiSettings:BaseUrl"];

        await Do(baseUrl);
    }

    private static async Task Do(string BaseUrl)
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

        Console.WriteLine();

        SendRequest(SortList, BaseUrl);
    }
    private static async Task SendRequest(List<int> data, string url)
    {
        string json = JsonSerializer.Serialize(data);

        await ConsoleApp.HttpRequestHelper.GetRequest(json, url);
    }

}