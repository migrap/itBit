using itBit.Net.Http.Formatting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class News : IReadOnlyCollection<Headline> {
        private List<Headline> _headlines = new List<Headline>();

        internal News() {
        }

        internal News(IEnumerable<Headline> collection) {
            _headlines.AddRange(collection);
        }

        internal void Add(Headline value) {
            _headlines.Add(value);
        }

        public int Count {
            get { return _headlines.Count; }
        }

        public Headline this[int index] {
            get { return _headlines[index]; }
        }

        public IEnumerator<Headline> GetEnumerator() {
            return _headlines.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public static explicit operator News(ReadOnlyCollection<Headline> source) {
            return new News(source);
        }
    }
}