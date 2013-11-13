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
            return SendAsync(request).ReadAsAsync<Ticker, TickerMediaTypeFormatter>();
        }

        public Task<News> GetNewsAsync(Action<INewsConfigurator> configure) {
            var configurator = new NewsConfigurator();
            configure(configurator);

            var request = configurator.Build();
            return SendAsync(request).ReadAsAsync<News, NewsMediaTypeFormatter>();
        }

        public Task<Prices> GetPricesAsync(Action<IPriceConfigurator> configure) {
            var configurator = new PriceConfigurator();
            configure(configurator);

            var request = configurator.Build();
            return SendAsync(request).ReadAsAsync<Prices, PriceMediaTypeFormatter>();
        }

        public Task<Orderbook> GetOrderbookAsync(Action<IOrderbookConfigurator> configure) {
            var configurator = new OrderbookConfigurator();
            configure(configurator);

            var request = configurator.Build();
            return SendAsync(request).ReadAsAsync<Orderbook, OrderbookMediaTypeFormatter>();
        }
    }

    public static partial class Extensions {
        public static Task<Ticker> GetTickerAsync(this itBitClient self, string symbol) {
            return self.GetTickerAsync(x => x.Symbol(symbol));
        }

        internal static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> self, MediaTypeFormatter formatter) {
            return self.ReadAsAsync<T>(new MediaTypeFormatter[] { formatter });
        }

        internal static Task<TResult> ReadAsAsync<TResult, TMediaTypeFormatter>(this Task<HttpResponseMessage> self) where TMediaTypeFormatter : MediaTypeFormatter, new() {
            return self.ReadAsAsync<TResult>(new MediaTypeFormatter[] { new TMediaTypeFormatter() });
        }
    }
}