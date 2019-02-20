using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEOAnalyser.Services;
using SEOAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyser.Tests.Services
{
    [TestClass]
    public class AnalyserServiceTest
    {


        [TestMethod]
        public void GetAllWords()
        {
            var analyserModel = new AnalyserModel();
            analyserModel.Content = "Filler text is text that shares some characteristics of a real written text, but is random or otherwise generated. It may be used to display a sample of fonts, generate text for testing, or to spoof an e-mail spam filter.";
            analyserModel.FilterStopWords = true;
            var analyserService = new AnalyserService(analyserModel);
            var result=analyserService.Analysis();
            Assert.AreEqual(result.WordList["text"], 4);
            Assert.IsFalse(result.WordList.ContainsKey("that"));

            analyserModel.FilterStopWords = false;
            analyserService = new AnalyserService(analyserModel);
            result = analyserService.Analysis();
            Assert.IsTrue(result.WordList.ContainsKey("that"));
        }

        [TestMethod]
        public void GetAllExternalLinks()
        {
            var analyserModel = new AnalyserModel();
            analyserModel.Content = "There are links for your reference, http://test.com, https://www.app.com.my";
            var analyserService = new AnalyserService(analyserModel);
            var result = analyserService.Analysis();
            Assert.AreEqual(result.LinkList.Count, 2);
        }
    }
}
