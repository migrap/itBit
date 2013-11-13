using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Configuration {
    internal class NewsConfigurator : INewsConfigurator {
        private int _max;
        public INewsConfigurator Max(int value) {
            _max = value;
            return this;
        }

        public HttpRequestMessage Build() {
            var uri = "/api/feeds/news/{0}".FormatWith(_max);

            return new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative)
            };
        }
    }
}
