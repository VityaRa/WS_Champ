using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;

namespace Forma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string answer = wc.DownloadString("https://localhost:44372/api/values/1");

            Region rg = new Region();
            rg = JsonConvert.DeserializeObject<Region>(answer);
            ANS.Text = rg.capital;

            answer = wc.DownloadString("https://localhost:44372/api/values");
            var rgList = new List<Region>();
            rgList = JsonConvert.DeserializeObject<List<Region>>(answer);
            DG.ItemsSource = rgList;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddRegion arw = new AddRegion();
            arw.Show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteRegion drb = new DeleteRegion();
            drb.Show();
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Region item = DG.SelectedItem as Region;
            var urb = new UpdateRegion(item);
            urb.Show();
        }
    }
}
