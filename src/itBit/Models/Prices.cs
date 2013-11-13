using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Models {
    public class Prices : IReadOnlyCollection<Price> {
        private List<Price> _headlines = new List<Price>();

        internal Prices(){            
        }

        internal Prices(IEnumerable<Price> collection) {
            _headlines.AddRange(collection);
        }

        internal void Add(Price value) {
            _headlines.Add(value);
        }

        public int Count {
            get { return _headlines.Count; }
        }

        public IEnumerator<Price> GetEnumerator() {
            return _headlines.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public static explicit operator Prices(ReadOnlyCollection<Price> source) {
            return new Prices(source);
        }
    }
}