using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HttpRequestHelper
    {
        public static async Task GetRequest(string json, string url)
        {
            try
            {
                using HttpClient client = new HttpClient();
                // Упаковка данных в тело запроса
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                // Отправка POST-запроса
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Обработка ответа
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response: {responseBody}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
