using NUnit.Framework;
using Acari.Services;
using System;
using IronPython.Hosting;
using System.IO;

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

        [Test]
        public void IronPythonTest()
        {
            var engine = Python.CreateEngine();
            var source = engine.CreateScriptSourceFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonSampleIronPython.py"));
            var scope = engine.CreateScope();
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            Console.WriteLine("From Iron Python");
            Console.WriteLine("5 + 10 = {0}", calculatorInstance.add(5, 10));
            Console.WriteLine("5++ = {0}", calculatorInstance.increment(5));
        }
    }


}