using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class Headline {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("contentSnippet")]
        public string Content { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
