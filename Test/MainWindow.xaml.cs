using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Test
{

    public partial class MainWindow : Window
    {

        private DispatcherTimer _timer = new DispatcherTimer();
        Coin_Market newForm;
        public MainWindow()
        {
            InitializeComponent();
            Parse();
        }
        public void OpenForm(string user_request)
        {
            newForm = new Coin_Market(user_request);
            newForm.ShowDialog();
            //newForm.Show();
        }
        private void Button_BTK_Click(object sender, RoutedEventArgs e)
        {
            string user_request = "bitcoin";
            OpenForm(user_request);
        }
        private void Button_ETH_Click(object sender, RoutedEventArgs e)
        {
            string user_request = "ethereum";
            OpenForm(user_request);
        }
        private void Button_TTH_Click(object sender, RoutedEventArgs e)
        {
            string user_request = "tether";
            OpenForm(user_request);
        }
        private void Button_BNB_Click(object sender, RoutedEventArgs e)
        {
            string user_request = "binance-coin";
            OpenForm(user_request);
        }
        private void Button_USDCoin_Click(object sender, RoutedEventArgs e)
        {
            string user_request = "usd-coin";
            OpenForm(user_request);
        }
        private void ComboBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string user_request = ComboBox_Search.Text;
                OpenForm(user_request);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void Parse()
        {
            if (ListViewMain.Items != null && ListViewMain.Items.Count != 0)

                ListViewMain.Items.Clear();

            string link = "https://api.coincap.io/v2/assets";
            var request = new GetRequest(link);

            request.Run();

            var response = request.Response;
            var json = JObject.Parse(response);
            var value = json["data"];

            foreach (var item in value)
            {
                var rank = item["rank"];
                var name = item["name"];
                var symbol = item["symbol"];
                var priceUsd = item["priceUsd"];
                var changePercent24Hr = item["changePercent24Hr"];

                ListViewMain.Items.Add(new Coin {
                    rank = Convert.ToString(rank),
                    name = Convert.ToString(name),
                    symbol = Convert.ToString(symbol), 
                    priceUsd = Convert.ToString(priceUsd),
                    changePercent24Hr = Convert.ToString(changePercent24Hr) });
            }
        }
        private void Parse(object sender, EventArgs e) => Parse();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Tick += new EventHandler(Parse);
            _timer.Interval = new TimeSpan(0, 0, 5);
            _timer.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CalcWindow newForm = new CalcWindow();
            // newForm.ShowDialog();
            newForm.Show();
        }
        private void ButtonWindowState_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
    }
}
