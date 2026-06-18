using HelpdeskZgloszenia.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http.Json;

namespace HelpdeskZgloszenia.Pages;

public partial class LoginPage : Page
{
    private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7171") };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnLogin_Click(object sender, RoutedEventArgs e)
    {
        var daneLogowania = new LoginRequestDto
        {
            Login = TxtLogin.Text,
            Haslo = TxtHaslo.Password
        };


        var odpowiedz = await _httpClient.PostAsJsonAsync<LoginRequestDto>("api/Authorization/login", daneLogowania);

        if (odpowiedz.IsSuccessStatusCode)
        {
            var wynik = await odpowiedz.Content.ReadFromJsonAsync<LoginResponse>();
            MessageBox.Show($"Witaj {wynik.Imie} {wynik.Nazwisko}");

            if (wynik.Rola == "Informatyk")
                NavigationService.Navigate(new AdminPage());
            else
                NavigationService.Navigate(new WorkerPage());
        }
        else
        {
            string komunikatBledu = await odpowiedz.Content.ReadAsStringAsync();
            MessageBox.Show(komunikatBledu);
        }
    }
}
