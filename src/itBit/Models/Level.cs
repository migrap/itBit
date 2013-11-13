using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    [DebuggerDisplay("{ToString()}")]
    public class Level {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        public override string ToString() {
            return (new { Price, Quantity }).ToString();
        }
    }
}
