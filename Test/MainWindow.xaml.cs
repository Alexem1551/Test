using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Test
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var reqest = new GetRequest("https://api.coincap.io/v2/assets");
            reqest.Run();

            var response = reqest.Response;

            var json = JObject.Parse(response);
            var value = json["data"];


            /*for (int i = 0; i < 15; i++)
            {
                var data = Convert.ToString(value[i]);
              
                ListViewMain.Items.Add(data);
             }*/

            foreach (var item in value)
            {
                var rank = item["rank"];
                var name = item["name"];
                var symbol = item["symbol"];
                var priceUsd = item["priceUsd"];
                var changePercent24Hr = item["changePercent24Hr"];
                
                ListViewMain.Items.Add(new Coin {rank_= Convert.ToString(rank), name_= Convert.ToString(name), symbol_= Convert.ToString(symbol),priceUsd_ = Convert.ToString(priceUsd),changePercent24Hr_ = Convert.ToString(changePercent24Hr)});
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
    }
}
