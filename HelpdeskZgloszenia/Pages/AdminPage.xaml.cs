using HelpdeskReports.Models;
using HelpdeskZgloszenia.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpdeskZgloszenia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public static readonly HttpClient _httpClient = new HttpClient();
        private  readonly AdminData _adminData;
        public AdminPage()
        {
            InitializeComponent();
        }

        public AdminPage(AdminData adminData)
        {
            _adminData = adminData;
            InitializeComponent();
            LoadAdminData();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            AdminPageContent.Source = new Uri("Admin/Dashboard.xaml",UriKind.Relative);
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            AdminPageContent.Source = new Uri("Admin/Reports.xaml", UriKind.Relative);
        }

        private void BtnWorkers_Click(object sender, RoutedEventArgs e)
        {
            AdminPageContent.Source = new Uri("Admin/Workers.xaml", UriKind.Relative);
        }

        private void BtnStats_Click(object sender, RoutedEventArgs e)
        {
            AdminPageContent.Source = new Uri("Admin/Stats.xaml", UriKind.Relative);
        }
        private void LoadAdminData()
        {
            LoginName.Text = $"{_adminData.Name} {_adminData.LastName}";
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
