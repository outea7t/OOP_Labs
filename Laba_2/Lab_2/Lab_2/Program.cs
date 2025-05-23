using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskOOPLab2
{
    static class Program
    {
        // CoinMarketCap API Key - Я знаю, что нельзя оставлять ключ в коде, но делаю это для того, чтобы проект запустился без дополнительных настроек.
        private const string coinMarketCapApiKey = "034da4f0-e561-43c8-a324-910fb8ddc834";

        private static readonly string[] urls = {
            "https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol=BTC",
            "https://api.coingecko.com/api/v3/simple/price?ids=ethereum&vs_currencies=usd&include_market_cap=true",
            "https://www.google.com"
        };

        public static void SyncRequest()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            var timer = Stopwatch.StartNew();

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                try
                {
                    Console.WriteLine($"\nСинхронный запрос к {url}");

                    if (i == 0)
                        httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapApiKey);

                    var response = httpClient.GetAsync(url).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode} ({(int)response.StatusCode})");
                        return;
                    }

                    var json = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Ответ от {url} (JSON):");
                    Console.WriteLine(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при запросе к {url}: {ex.Message}");
                }
                finally
                {
                    if (i == 0)
                        httpClient.DefaultRequestHeaders.Remove("X-CMC_PRO_API_KEY");
                }
            }

            timer.Stop();
            Console.WriteLine($"\nОбщее время синхронных запросов: {timer.ElapsedMilliseconds} мс");
        }

        public static async Task<string> AsyncRequest()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            var timer = Stopwatch.StartNew();

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                try
                {
                    Console.WriteLine($"\nАсинхронный запрос к {url}");

                    if (i == 0)
                        httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapApiKey);

                    var response = await httpClient.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode} ({(int)response.StatusCode})");
                        return $"Ошибка: {response.StatusCode} ({(int)response.StatusCode})";
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Ответ от {url} (JSON):");
                    Console.WriteLine(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при запросе к {url}: {ex.Message}");
                    return $"Ошибка при запросе к {url}: {ex.Message}";
                }
                finally
                {
                    if (i == 0)
                        httpClient.DefaultRequestHeaders.Remove("X-CMC_PRO_API_KEY");
                }
            }

            timer.Stop();
            Console.WriteLine($"\nОбщее время асинхронных запросов: {timer.ElapsedMilliseconds} мс");
            return $"\nОбщее время асинхронных запросов: {timer.ElapsedMilliseconds} мс";
        }

        public static void Main()
        {
            SyncRequest();
            AsyncRequest().Wait();
        }
    }
}

/* Изначально я парсил жсон, так как не увидел, что его нельзя парсить
 Синхронные запросы
if (i == 0)
{
    var json = response.Content.ReadAsStringAsync().Result;
    using var doc = JsonDocument.Parse(json);

    var data = doc.RootElement.GetProperty("data").GetProperty("BTC");
    var name = data.GetProperty("name").GetString();
    var price = data.GetProperty("quote").GetProperty("USD").GetProperty("price").GetDecimal();
    var marketCap = data.GetProperty("quote").GetProperty("USD").GetProperty("market_cap").GetDecimal();

    Console.WriteLine($"Криптовалюта: {name}");
    Console.WriteLine($"Текущая цена: ${price:N2}");
    Console.WriteLine($"Капитализация: ${marketCap:N0}");
}
else if (i == 1)
{
    var json = response.Content.ReadAsStringAsync().Result;
    using var doc = JsonDocument.Parse(json);

    var ethData = doc.RootElement.GetProperty("ethereum");
    var price = ethData.GetProperty("usd").GetDecimal();
    var marketCap = ethData.GetProperty("usd_market_cap").GetDecimal();

    Console.WriteLine($"Криптовалюта: Ethereum");
    Console.WriteLine($"Текущая цена: ${price:N2}");
    Console.WriteLine($"Капитализация: ${marketCap:N0}");
}
else
{
    var html = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine("Ответ от Google (обрезанный HTML):");
    Console.WriteLine(html.Substring(0, Math.Min(html.Length, 300)) + "...");
}

 
 Асинхронные запросы
if (i == 0)
{
    var json = await response.Content.ReadAsStringAsync();
    using var doc = JsonDocument.Parse(json);

    var data = doc.RootElement.GetProperty("data").GetProperty("BTC");
    var name = data.GetProperty("name").GetString();
    var price = data.GetProperty("quote").GetProperty("USD").GetProperty("price").GetDecimal();
    var marketCap = data.GetProperty("quote").GetProperty("USD").GetProperty("market_cap").GetDecimal();

    Console.WriteLine($"Криптовалюта: {name}");
    Console.WriteLine($"Текущая цена: ${price:N2}");
    Console.WriteLine($"Капитализация: ${marketCap:N0}");
}
else if (i == 1)
{
    var json = await response.Content.ReadAsStringAsync();
    using var doc = JsonDocument.Parse(json);

    var ethData = doc.RootElement.GetProperty("ethereum");
    var price = ethData.GetProperty("usd").GetDecimal();
    var marketCap = ethData.GetProperty("usd_market_cap").GetDecimal();

    Console.WriteLine($"Криптовалюта: Ethereum");
    Console.WriteLine($"Текущая цена: ${price:N2}");
    Console.WriteLine($"Капитализация: ${marketCap:N0}");
}
else
{
    var html = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Ответ от Google (обрезанный HTML):");
    Console.WriteLine(html.Substring(0, Math.Min(html.Length, 300)) + "...");
}
 
 */