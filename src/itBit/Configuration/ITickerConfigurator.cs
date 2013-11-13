using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Configuration {
    public interface ITickerConfigurator {
        ITickerConfigurator Symbol(string value);
    }
}
