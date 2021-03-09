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
using Newtonsoft.Json;
using System.Net;

namespace Forma
{
    /// <summary>
    /// Логика взаимодействия для UpdateRegion.xaml
    /// </summary>
    public partial class UpdateRegion : Window
    {
        public static int index = -1;
        public UpdateRegion(Region item)
        {
            InitializeComponent();
            NameInput.Text = item.name;
            CapitalInput.Text = item.capital;
            DistrictInput.Text = item.district;
            index = item.code;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Region newRegion = new Region(index, NameInput.Text, CapitalInput.Text, DistrictInput.Text);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-type", "application/json");
            var json = JsonConvert.SerializeObject(newRegion);
            
            try
            {
                wc.UploadString("https://localhost:44372/api/values/" + newRegion.code.ToString(), "PUT", json);
                MessageBox.Show("Успешно!");
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
