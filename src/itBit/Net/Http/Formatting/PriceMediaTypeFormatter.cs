using itBit.Models;
using itBit.Net.Http.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Net.Http.Formatting {
    internal class PriceMediaTypeFormatter : JsonMediaTypeFormatter {
        public PriceMediaTypeFormatter() {
            SerializerSettings.Converters.Add(new ReadOnlyCollectionConverter());
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger logger) {
            return base.ReadFromStreamAsync(typeof(IReadOnlyCollection<Price>), stream, content, logger)
                .ContinueWith(x => (object)(Prices)(ReadOnlyCollection<Price>)x.Result);
        }
    }
}