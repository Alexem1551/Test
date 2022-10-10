using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
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
    public partial class CalcWindow : Window
    {
        public CalcWindow()
        {
            InitializeComponent();
        }
        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            Label4.Visibility = Visibility.Hidden;
            string link = "https://api.coincap.io/v2/assets";
            var request = new GetRequest(link);

            request.Run();

            var response = request.Response;
            var json = JObject.Parse(response);
            var value = json["data"];

            string First_currency = ComboBoxCalc1.Text;
            string Second_currency = ComboBoxCalc2.Text;
            double priceFirst_currency = 0, priceSecond_currency = 0, price;
            bool one = false, two = false;

            foreach (var item in value)
            {
                var id = item["id"];
                var symbol = item["symbol"];
                var priceUsd = item["priceUsd"];

                if (!one && Convert.ToString(id) == First_currency)
                {
                    priceFirst_currency = Convert.ToDouble(priceUsd);
                    Label1.Content = ($"1 {symbol} =");
                    one = true;
                }
                if (!two && Convert.ToString(id) == Second_currency)
                {
                    priceSecond_currency = Convert.ToDouble(priceUsd);
                    Label2.Content = (symbol);
                    two = true;
                }
                if (one && two) break;
            }

            price = (priceFirst_currency / priceSecond_currency);
            Label3.Content = (price);
        }
        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

