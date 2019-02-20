using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SEOAnalyser.Models
{
    public class AnalyserModel: AsSerializeable
    {
        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("Filter out stop words")]
        public bool FilterStopWords { get; set; } = true;

        [DisplayName("Show number of words")]
        public bool ShowWordList { get; set; } = true;

        [DisplayName("Show number of meta tags in Url")]
        public bool ShowTagList { get; set; } = true;

        [DisplayName("Show number of external links")]
        public bool ShowLinkList { get; set; } = true;


    }
}