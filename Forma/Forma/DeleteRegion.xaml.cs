using System.Windows;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Forma
{
    /// <summary>
    /// Логика взаимодействия для DeleteRegion.xaml
    /// </summary>
    public partial class DeleteRegion : Window
    {
        public DeleteRegion()
        {
            InitializeComponent();
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string answer = wc.DownloadString("https://localhost:44372/api/values");
            var rgList = new List<Region>();
            rgList = JsonConvert.DeserializeObject<List<Region>>(answer);
            foreach (var rg in rgList)
            {
                DeleteCombo.Items.Add(rg.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-type", "application/json");
            string strToDelete = DeleteCombo.SelectedItem.ToString();
            string id = "";
            foreach (var symb in strToDelete)
            {
                if (symb == '.')
                    break;
                else id += symb;
            }
            try
            {
                string ans = wc.UploadString("https://localhost:44372/api/values/" + id, "DELETE", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();
        }
    }
}
