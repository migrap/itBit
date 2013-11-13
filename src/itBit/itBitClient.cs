using itBit.Configuration;
using itBit.Models;
using itBit.Net.Http.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace itBit {
    public partial class itBitClient {
        private HttpClient _client;

        public itBitClient(Action<IConfigurator> configure) {
            var configurator = new Configurator();
            configure(configurator);
            _client = configurator.Build();
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) {
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        public Task<Ticker> GetTickerAsync(Action<ITickerConfigurator> configure) {
            var configurator = new TickerConfigurator();
            configure(configurator);

            var request = configurator.Build();

            return SendAsync(request)
                .GetTickerAsync();
        }

        public Task<News> GetNewsAsync(Action<INewsConfigurator> configure) {
            var configurator = new NewsConfigurator();
            configure(configurator);

            var request = configurator.Build();

            return SendAsync(request)
                .GetNewsAsync();
        }

        public Task<Prices> GetPricesAsync(Action<IPriceConfigurator> configure) {
            var configurator = new PriceConfigurator();
            configure(configurator);

            var request = configurator.Build();

            return SendAsync(request)
                .GetPricesAsync();
        }
    }

    public static partial class Extensions {
        public static Task<Ticker> GetTickerAsync(this itBitClient self, string symbol) {
            return self.GetTickerAsync(x => x.Symbol(symbol));
        }

        internal static Task<Ticker> GetTickerAsync(this Task<HttpResponseMessage> self) {
            return self.ReadAsAsync<Ticker>(new JsonMediaTypeFormatter());            
        }

        internal static Task<News> GetNewsAsync(this Task<HttpResponseMessage> self) {
            return self.ReadAsAsync<News>(new NewsMediaTypeFormatter());
        }

        internal static Task<Prices> GetPricesAsync(this Task<HttpResponseMessage> self) {
            return self.ReadAsAsync<Prices>(new PriceMediaTypeFormatter());
        }
    }
}