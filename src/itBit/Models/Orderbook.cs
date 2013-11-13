using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class Orderbook {
        [JsonProperty("bid")]
        public IReadOnlyList<Level> Bids { get; set; }

        [JsonProperty("ask")]
        public IReadOnlyList<Level> Asks { get; set; }
    }
}
