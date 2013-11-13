//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace itBit.Net.Http.Configuration {
//    internal class HttpRequestMessageConfigurator : IHttpRequestMessageConfigurator {
//        private HttpRequestMessage _message = new HttpRequestMessage();
//        public IHttpRequestMessageConfigurator Method(HttpMethod value) {
//            _message.Method = value;
//            return this;
//        }        

//        public HttpRequestMessage Build() {
//            return _message;
//        }
//    }
//}