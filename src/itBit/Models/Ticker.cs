using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class Ticker {
        [JsonProperty("intervalStart")]
        public DateTimeOffset IntervalStart { get; set; }
        
        [JsonProperty("intervalInMinutes")]
        public int IntervalInMinutes { get; set; }
        
        [JsonProperty("change")]
        public double Change { get; set; }
        
        [JsonProperty("bid")]
        public double Bid { get; set; }
        
        [JsonProperty("ask")]
        public double Ask { get; set; }
        
        [JsonProperty("open")]
        public double Open { get; set; }
        
        [JsonProperty("high")]
        public double High { get; set; }
        
        [JsonProperty("low")]
        public double Low { get; set; }
        
        [JsonProperty("close")]
        public double Close { get; set; }
        
        [JsonProperty("volume")]
        public double Volume { get; set; }
        
        [JsonProperty("tickerSymbol")]
        public string Symbol { get; set; }
        
        [JsonProperty("currentTime")]
        public DateTimeOffset Datetime { get; set; }
        
        [JsonProperty("keyexpire")]
        public DateTimeOffset Keyexpire { get; set; }
    }
}
