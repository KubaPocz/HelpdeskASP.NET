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

            UpdateClock();
            AdminPage.OnTimeChanged += UpdateClock;
            this.Unloaded += (s, e) => AdminPage.OnTimeChanged -= UpdateClock;
        }

        public async void LoadWorkers()
        {
            GridWorkers.ItemsSource = AdminPage.workers;
        }
        private void UpdateClock()
        {
            TxtClock.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
