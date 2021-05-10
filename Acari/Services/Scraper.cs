using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace Acari.Services
{
    public class Scraper
    {
        public static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }
        public static IWebDriver GetChromeDriver()
        {
            List<string> programmerLinks = new List<string>();

            var options = new ChromeOptions();
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });

            return new ChromeDriver(options);
        }
    }
}
