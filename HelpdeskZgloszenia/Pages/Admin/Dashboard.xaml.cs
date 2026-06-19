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
    public partial class Dashboard : Page
    {
        private List<Report> newReports = new List<Report>();
        public Dashboard()
        {
            InitializeComponent();
            GetDataFromDb();

            TxtClock.Text = DateTime.Now.ToString("HH:mm");
            AdminPage.OnTimeChanged += UpdateClock;
            AdminPage.OnTimeChanged += CheckForNewReports;
            this.Unloaded += (s,e) => AdminPage.OnTimeChanged -= UpdateClock;
        }
        private void LoadDashboardData()
        {
            TxtWorkersCount.Text = AdminPage.workers.Count().ToString();
            TxtReportsCount.Text = AdminPage.reports.Count().ToString();
            TxtLastReport.Text = CalculateLastReportTime();
        }
        private string CalculateLastReportTime()
        {
            var sortedRaports = AdminPage.reports.OrderByDescending(r => r.ReportDate).ToList();
            DateTime lastReportDate = sortedRaports.First().ReportDate;
            TimeSpan diff = DateTime.Now - lastReportDate;

            double minutes = diff.TotalMinutes;
            double hours = diff.TotalHours;
            double days = diff.TotalDays;

            if (hours >= 24)
                return $"{(int)days} d";
            if(minutes >= 60) 
                return $"{(int)hours} h";
            return $"{(int)minutes} m";
        }
        private async void GetDataFromDb()
        {
            try
            {
                string url = "https://localhost:7171/api/admin/reports/get";
                HttpResponseMessage response = await AdminPage._httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    AdminPage.reports = JsonSerializer.Deserialize<List<Report>>(jsonResult, options);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                string url = "https://localhost:7171/api/admin/workers/get";
                HttpResponseMessage response = await AdminPage._httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    AdminPage.workers = JsonSerializer.Deserialize<List<Worker>>(jsonResult, options);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadDashboardData();
        }
        private void UpdateClock()
        {
            TxtClock.Text = DateTime.Now.ToString("HH:mm");
        }
        private void CheckForNewReports()
        {

        }
    }
}
