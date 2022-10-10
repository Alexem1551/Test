using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test
{
    public class GetRequest
    {
        HttpWebRequest request;
        string address;

        public string Response { get; set; }
        public GetRequest(string link)
        {
            address = link;
        }
        public void Run()
        {
            request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
             
                 var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Incorrect data entered!");
                throw;
            }
        }
    }

    public class Coin
    {
        public string rank { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string priceUsd { get; set; }
        public string changePercent24Hr { get; set; }
    }
    public class Coin_market
    {
        public string exchangeId { get; set; }
        public string baseId { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string priceUsd { get; set; }
    }




}
