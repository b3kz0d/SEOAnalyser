using HtmlAgilityPack;
using SEOAnalyser.Helper;
using SEOAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace SEOAnalyser.Services
{
    public class UrlAnalyserService : IAnalyserService
    {
        private AnalyserModel _model;
        public UrlAnalyserService(AnalyserModel model)
        {
            _model = model;
        }
        public Dictionary<string, int> GetAllWords()
        {
            var wordList = new Dictionary<string, int>();
            var httpClient = new HttpClient();
            var document = new HtmlDocument();

            var htmlContent=httpClient.GetStringAsync(_model.Content).Result;
            document.LoadHtml(htmlContent);
            var content = document.DocumentNode.InnerText;
            var words = content.Split(AnalyserHelper.Spliter, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var lowerCaseWord = word.ToLower();
                if (!Regex.IsMatch(lowerCaseWord, "^[a-z\u00c0-\u00f6]+$") || lowerCaseWord.Length < 2)
                    continue;
                if (_model.FilterStopWords && AnalyserHelper.GetAllStopWords().Contains(lowerCaseWord))
                    continue;

                if (!wordList.ContainsKey(lowerCaseWord))
                {
                    wordList.Add(lowerCaseWord, 1);
                    continue;
                }
                wordList[lowerCaseWord] += 1;
            }
            return wordList;
        }

        public Dictionary<string, int> GetAllMetaTags()
        {
            var tagList = new Dictionary<string, int>();

            var httpClient = new HttpClient();
            var document = new HtmlDocument();

            var htmlContent = httpClient.GetStringAsync(_model.Content).Result;
            document.LoadHtml(htmlContent);
            var metaTags = document.DocumentNode.SelectNodes("//meta");

            var tags = new List<string>();
            
            foreach(var metaTag in metaTags)
            {
                if(metaTag.Attributes["content"] != null&& !string.IsNullOrEmpty(metaTag.Attributes["content"].Value))
                {
                    var list = metaTag.Attributes["content"].Value.Split(AnalyserHelper.Spliter,StringSplitOptions.RemoveEmptyEntries).ToList();
                    tags.AddRange(list);
                }
            }
            var words = GetAllWords();
            tagList = words.Where(x => tags.Contains(x.Key)).ToDictionary(i => i.Key, i => i.Value);
            return tagList;
        }

        public List<string> GetAllExternalLinks()
        {
            var wordList = new Dictionary<string, int>();
            var httpClient = new HttpClient();
            var document = new HtmlDocument();

            var htmlContent = httpClient.GetStringAsync(_model.Content).Result;
            document.LoadHtml(htmlContent);
            var content = document.DocumentNode.InnerText;

            var linkList = new List<string>();
            MatchCollection links = Regex.Matches(content, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
            foreach (Match link in links)
            {
                linkList.Add(link.Value);
            }
            return linkList;
        }

    }
}