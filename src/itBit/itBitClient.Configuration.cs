using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itBit {
    public partial class itBitClient {
        public interface IConfigurator {
            IConfigurator Address(string value);
            IConfigurator Handler(HttpMessageHandler value);
        }

        private class Configurator : IConfigurator {
            private Settings _settings = Settings.Default;

            public IConfigurator Address(string value) {
                _settings.Address = new Uri(value, UriKind.RelativeOrAbsolute);
                return this;
            }

            public IConfigurator Handler(HttpMessageHandler value) {
                _settings.Handler = value;
                return this;
            }

            public HttpClient Build() {
                var client = new HttpClient(_settings.Handler) {
                    BaseAddress = _settings.Address
                };
                return client;
            }
        }

        private class Settings {
            public static readonly Settings Default = new Settings {
                Address = new Uri("https://www.itbit.com"),
                Handler = new HttpClientHandler()
            };
            public Uri Address { get; set; }
            public HttpMessageHandler Handler { get; set; }
        }
    }
}