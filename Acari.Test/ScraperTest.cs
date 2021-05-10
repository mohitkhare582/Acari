using NUnit.Framework;
using Acari.Services;
using System;

namespace Acari.Test
{
    public class ScraperTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetURLTest()
        {
            var testUrl = "https://www.linkedin.com/in/mohitkhare582";
            var LAuto = new LinkedInAutomation(Scraper.GetChromeDriver());
            LAuto.Login("mohitkhare582", "Iam100%sexyandsmart");


        }
    }
}