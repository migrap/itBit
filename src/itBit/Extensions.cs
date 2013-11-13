using itBit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace itBit {
    public static partial class Extensions {
        internal static string FormatWith(this string input, params object[] formatting) {
            return string.Format(input, formatting);
        }

        public static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> self, params MediaTypeFormatter[] formatters) {
            return self.Result.Content.ReadAsAsync<T>(formatters);
        }
    }
}
