using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Configuration {
    public interface IOrderbookConfigurator {
        IOrderbookConfigurator Symbol(string value);
    }
}
