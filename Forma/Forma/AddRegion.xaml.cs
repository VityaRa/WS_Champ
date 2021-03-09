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
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;

namespace Forma
{
    /// <summary>
    /// Логика взаимодействия для AddRegion.xaml
    /// </summary>
    public partial class AddRegion : Window
    {
        public AddRegion()
        {
            InitializeComponent();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            Region rg = new Region(0, InName.Text, InCapital.Text, InDistrict.Text);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string rgString = JsonConvert.SerializeObject(rg);
            wc.Headers.Add("Content-Type", "application/json");
            try
            {
                string response = wc.UploadString("https://localhost:44372/api/values", "POST", rgString);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();
        }
    }
}
