using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
using HelpdeskReports.Models;

namespace HelpdeskZgloszenia.Pages.Admin
{
    public partial class Reports : Page
    {
        public Reports()
        {
            InitializeComponent();
            LoadReports();
        }
        public async void LoadReports()
        {
            try
            {
                string url = "https://localhost:7171/api/admin/reports/get";
                HttpResponseMessage response = await AdminPage._httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    List<Report> reports = JsonSerializer.Deserialize<List<Report>>(jsonResult,options);

                    GridReports.ItemsSource = reports;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
