using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradingBot.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await AsyncMain()).Wait();
        }

        public static async Task AsyncMain()
        {
            int lastTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int gap = 1296060;
            int symbol = 8849;

            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");

                    var response = await httpClient.GetAsync(
                        $"https://tvc4.forexpros.com/f4ea20b925889f8ab599a646581d040a/1585218404/18/18/88/history?symbol={symbol}&resolution=1&from={lastTime - gap}&to={lastTime}");


                    var chartData =
                        JsonConvert.DeserializeObject<InvestingChartData>(await response.Content.ReadAsStringAsync());

                    if (chartData.s != "ok")
                    {
                        // 정상 응답이 아니면 멈춘다
                        break;
                    }

                    var firstTime = chartData.t.First();
                    Console.WriteLine(firstTime);
                    lastTime = firstTime - 1;
                }
            }
        }
    }
}
