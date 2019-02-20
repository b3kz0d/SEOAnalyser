using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEOAnalyser.Models
{
    public abstract class AsSerializeable
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}