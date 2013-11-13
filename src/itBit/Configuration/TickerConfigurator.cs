using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Configuration {
    internal class TickerConfigurator : ITickerConfigurator {
        private string _symbol;        

        public ITickerConfigurator Symbol(string value) {
            _symbol = value;
            return this;
        }

        public HttpRequestMessage Build() {
            var uri = "/api/feeds/ticker/{0}".FormatWith(_symbol);

            return new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative)
            };
        }
    }
}
