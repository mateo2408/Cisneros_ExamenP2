using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Cisneros_ExamenP2.Pages
{
    public partial class ChistesPage : ContentPage
    {
        public ChistesPage()
        {
            InitializeComponent();
            LoadJoke();
        }

        private async void LoadJoke()
        {
            OtroChisteButton.IsEnabled = false;
            try
            {
                var handler = new HttpClientHandler();
                handler.AutomaticDecompression = System.Net.DecompressionMethods.All;
                using var client = new HttpClient(handler);
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = await client.GetAsync("https://official-joke-api.appspot.com/random_joke");
                if (!response.IsSuccessStatusCode)
                {
                    JokeLabel.Text = "Error: Could not fetch joke.";
                    return;
                }

                var contentType = response.Content.Headers.ContentType?.MediaType;
                var responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("API Response: " + responseBody);

                if (contentType != "application/json")
                {
                    JokeLabel.Text = "Error: Unexpected response format.";
                    return;
                }

                var joke = System.Text.Json.JsonSerializer.Deserialize<Joke>(responseBody);
                if (joke != null && !string.IsNullOrEmpty(joke.setup) && !string.IsNullOrEmpty(joke.punchline))
                {
                    JokeLabel.Text = $"{joke.setup}\n\n{joke.punchline}";
                }
                else
                {
                    JokeLabel.Text = "No joke found. Try again.";
                }
            }
            catch (Exception ex)
            {
                JokeLabel.Text = $"Error loading joke: {ex.Message}";
            }
            finally
            {
                OtroChisteButton.IsEnabled = true;
            }
        }

        private void OnOtroChisteClicked(object sender, EventArgs e)
        {
            LoadJoke();
        }

        class Joke
        {
            public string setup { get; set; }
            public string punchline { get; set; }
        }
    }
}