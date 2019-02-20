using SEOAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEOAnalyser.Services
{
    public class AnalyserService
    {
        private IAnalyserService _analyserService;
        private AnalyserModel _analyserModel;
        public AnalyserService(AnalyserModel analyserModel)
        {
            _analyserModel = analyserModel;
        }

        public ContentModel Analysis()
        {
            if(string.IsNullOrEmpty(_analyserModel.Content))
            {
                return new ContentModel();
            }

            if (_analyserModel.Content.StartsWith("http"))
            {
                _analyserService = new UrlAnalyserService(_analyserModel);
            }
            else
            {
                _analyserService = new TextAnalyserService(_analyserModel);
            }

            return new ContentModel()
            {
                WordList = _analyserService.GetAllWords(),
                TagList = _analyserService.GetAllMetaTags(),
                LinkList = _analyserService.GetAllExternalLinks()
            };
        }
    }
}