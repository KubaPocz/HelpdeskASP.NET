using HelpdeskReports.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpdeskZgloszenia.Pages.Admin
{
    public partial class Workers : Page
    {
        public Workers()
        {
            InitializeComponent();
            LoadWorkers();
        }

        public async void LoadWorkers()
        {
            try
            {
                string url = "https://localhost:7171/api/admin/workers/get";
                HttpResponseMessage response = await AdminPage._httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    List<Worker> reports = JsonSerializer.Deserialize<List<Worker>>(jsonResult, options);

                    GridWorkers.ItemsSource = reports;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
