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

namespace Test
{
    public partial class Coin_Market : Window
    {
        public Coin_Market()
        {           
            InitializeComponent();
            string coin_name = "bitcoin";
            var reqest = new GetRequest($"https://api.coincap.io/v2/assets/{coin_name}/markets");

            reqest.Run();

            var response = reqest.Response;

            var json = JObject.Parse(response);
            var value = json["data"];

            foreach (var item in value)
            {
                var exchangeId = item["exchangeId"];
                var baseId = item["baseId"];
                var volumeUsd24Hr = item["volumeUsd24Hr"];
                var priceUsd = item["priceUsd"];

                ListViewMain.Items.Add(new Coin_market { exchangeId_ = Convert.ToString(exchangeId), baseId_ = Convert.ToString(baseId), volumeUsd24Hr_ = Convert.ToString(volumeUsd24Hr), priceUsd_ = Convert.ToString(priceUsd)});
            }
           
        }
        private void TextBox_Show_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Coin_Market newForm = new Coin_Market();
                newForm.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
