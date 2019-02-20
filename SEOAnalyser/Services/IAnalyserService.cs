using System.Collections.Generic;

namespace SEOAnalyser.Services
{
    public interface IAnalyserService
    {
        Dictionary<string, int> GetAllWords();
        Dictionary<string, int> GetAllMetaTags();
        List<string> GetAllExternalLinks();
    }
}