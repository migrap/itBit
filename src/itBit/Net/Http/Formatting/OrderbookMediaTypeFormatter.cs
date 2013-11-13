using itBit.Net.Http.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Net.Http.Formatting {
    internal class OrderbookMediaTypeFormatter : JsonMediaTypeFormatter {
        public OrderbookMediaTypeFormatter() {
            SerializerSettings.Converters.Add(new ReadOnlyCollectionConverter());
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger logger) {
            return base.ReadFromStreamAsync(type, stream, content, logger);
        }
    }
}