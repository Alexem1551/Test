using Newtonsoft.Json.Linq;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Test
{
    public partial class Coin_Market : Window 
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        public Coin_Market(string coin_name)
        {           

            InitializeComponent();

            var reqest = new GetRequest($"https://api.coincap.io/v2/assets/{coin_name}/markets");

            reqest.Run();

            var response = reqest.Response;

            var json = JObject.Parse(response);
            var value = json["data"];

            TextSymbol.Text = Convert.ToString(coin_name);

            foreach (var item in value)
            {
                var exchangeId = item["exchangeId"];
                var baseId = item["baseId"];
                var volumeUsd24Hr = item["volumeUsd24Hr"];
                var priceUsd = item["priceUsd"];

                ListViewMain.Items.Add(new Coin_market { exchangeId = Convert.ToString(exchangeId), baseId = Convert.ToString(baseId), volumeUsd24Hr = Convert.ToString(volumeUsd24Hr), priceUsd = Convert.ToString(priceUsd) });
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();
        
        private void ComboBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string user_request = ComboBox_Search.Text;
                Coin_Market newForm = new Coin_Market(user_request);
                newForm.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

   
    }
}
