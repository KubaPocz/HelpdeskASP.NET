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

            UpdateClock();
            AdminPage.OnTimeChanged += UpdateClock;
            this.Unloaded += (s, e) => AdminPage.OnTimeChanged -= UpdateClock;
        }
        public void LoadReports()
        {
            GridReports.ItemsSource = AdminPage.reports;
        }
        private void UpdateClock()
        {
            TxtClock.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
