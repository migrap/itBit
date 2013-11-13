using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Configuration {
    internal class OrderbookConfigurator : IOrderbookConfigurator {
        private string _symbol;

        public IOrderbookConfigurator Symbol(string value) {
            _symbol = value;
            return this;
        }

        public HttpRequestMessage Build() {
            var uri = "/api/feeds/orderbook/{0}".FormatWith(_symbol);

            return new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative)
            };
        }
    }
}
