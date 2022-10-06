using Newtonsoft.Json.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Test
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string link = "https://api.coincap.io/v2/assets";

            var reqest = new GetRequest(link);
            
                reqest.Run();
                var response = reqest.Response;

                var json = JObject.Parse(response);
                var value = json["data"];

                foreach (var item in value)
                {
                    var rank = item["rank"];
                    var name = item["name"];
                    var symbol = item["symbol"];
                    var priceUsd = item["priceUsd"];
                    var changePercent24Hr = item["changePercent24Hr"];

                    ListViewMain.Items.Add(new Coin { rank_ = Convert.ToString(rank), name_ = Convert.ToString(name), symbol_ = Convert.ToString(symbol), priceUsd_ = Convert.ToString(priceUsd), changePercent24Hr_ = Convert.ToString(changePercent24Hr) });
                }
        }
        private void Button_BTK_Click(object sender, RoutedEventArgs e)
        {
            Coin_Market newForm = new Coin_Market();
            newForm.Show();
        }
        private void Button_ETH_Click(object sender, RoutedEventArgs e)
        {
            Coin_Market newForm = new Coin_Market();
            newForm.Show();
        }

        private void Button_TTH_Click(object sender, RoutedEventArgs e)
        {
            Coin_Market newForm = new Coin_Market();
            newForm.Show();
        }

        private void Button_BNB_Click(object sender, RoutedEventArgs e)
        {
            Coin_Market newForm = new Coin_Market();
            newForm.Show();
        }

        private void Button_USDCoin_Click(object sender, RoutedEventArgs e)
        {
            Coin_Market newForm = new Coin_Market();
            newForm.Show();
        }

        private void TextBox_Show_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string value = TextBox_Show.Text;
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
