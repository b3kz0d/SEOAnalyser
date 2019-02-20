using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEOAnalyser.Models
{
    public class ContentModel
    {
        public Dictionary<string,int> WordList { get; set; }
        public Dictionary<string,int> TagList { get; set; }
        public List<string> LinkList { get; set; }
    }
}