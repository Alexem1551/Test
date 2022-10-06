using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class GetRequest
    {
        HttpWebRequest _request;
        string _address;

        public string Response { get; set; }
        public GetRequest(string address)
        {
            _address = address;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
           
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
               
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }

    public class Coin
    {
        public string rank_ { get; set; }
        public string name_ { get; set; }
        public string symbol_ { get; set; }
        public string priceUsd_ { get; set; }
        public string changePercent24Hr_ { get; set; }
    }

    public class Coin_market
    {
        public string exchangeId_ { get; set; }
        public string baseId_ { get; set; }
        public string volumeUsd24Hr_ { get; set; }
        public string priceUsd_ { get; set; }
    }
}
