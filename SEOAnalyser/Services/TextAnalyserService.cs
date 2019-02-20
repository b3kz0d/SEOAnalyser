using SEOAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEOAnalyser.Helper;
using System.Text.RegularExpressions;

namespace SEOAnalyser.Services
{
    public class TextAnalyserService : IAnalyserService
    {
        AnalyserModel _model;
        public TextAnalyserService(AnalyserModel model)
        {
            _model = model;
        }

        public Dictionary<string, int> GetAllWords()
        {
            var wordList = new Dictionary<string, int>();
            var words = _model.Content.Split(AnalyserHelper.Spliter, StringSplitOptions.RemoveEmptyEntries);
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
            return new Dictionary<string, int>();
        }

        
        public List<string> GetAllExternalLinks()
        {
            var linkList = new List<string>();
            MatchCollection links = Regex.Matches(_model.Content, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
            foreach (Match link in links)
            {
                linkList.Add(link.Value);
            }
            return linkList;
        }

    }
}