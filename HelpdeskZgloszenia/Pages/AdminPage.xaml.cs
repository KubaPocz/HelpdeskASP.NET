using HelpdeskReports.Models;
using HelpdeskZgloszenia.Pages.Admin;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace HelpdeskZgloszenia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public static readonly HttpClient _httpClient = new HttpClient();
        private  readonly AdminData _adminData;
        public DispatcherTimer _globalTimer;
        public static event Action? OnTimeChanged;

        public static List<Report> reports = new List<Report>();
        public static List<Worker> workers = new List<Worker>();
        public AdminPage(AdminData adminData)
        {
            _adminData = adminData;
            _globalTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _globalTimer.Tick += (s, e) =>
            {
                string time = DateTime.Now.ToString("HH:mm");
                OnTimeChanged?.Invoke();
            };
            _globalTimer.Start();

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
