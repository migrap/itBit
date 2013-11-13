using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class Price {
        [JsonProperty("x")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("y")]
        public double Value { get; set; }
    }
}
