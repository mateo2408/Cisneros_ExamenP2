using System;
using Microsoft.Maui.Controls;

namespace Cisneros_ExamenP2.Pages
{
    public partial class AboutPage : ContentPage
    {
        public string CurrentDate { get; set; }

        public AboutPage()
        {
            InitializeComponent();
            CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            BindingContext = this;
        }
    }
}