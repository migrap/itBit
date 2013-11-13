using itBit.Models;
using itBit.Net.Http.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    internal class NewsMediaTypeFormatter : JsonMediaTypeFormatter {
        public NewsMediaTypeFormatter() {
            SerializerSettings.Converters.Add(new ReadOnlyCollectionConverter());
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger logger) {
            return base.ReadFromStreamAsync(typeof(IReadOnlyCollection<Headline>), stream, content, logger)
                .ContinueWith(x => (object)(News)(ReadOnlyCollection<Headline>)x.Result);
        }
    }
}