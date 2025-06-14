﻿using Cisneros_ExamenP2.Pages;

namespace Cisneros_ExamenP2;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnChistesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChistesPage());
    }
    
    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutPage());
    }
}