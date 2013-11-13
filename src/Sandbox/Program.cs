using itBit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox {
    class Program {
        static void Main(string[] args) {

            var client = new itBitClient(x => x.Address("https://itbit.apiary.io"));

            //var ticker = client.GetTickerAsync(x => x.Symbol(?"BTCUSD")).Result;

            //var news = client.GetNewsAsync(x => x.Max(1)).Result;

            //var prices = client.GetPricesAsync(x => x.Symbol("BTCUSD")).Result;

            var orderbook = client.GetOrderbookAsync(x => x.Symbol("BTCUSD")).Result;
            Console.ReadLine();
        }
    }
}