public partial class ChistesPage : ContentPage
{
    public ChistesPage()
    {
        InitializeComponent();
        LoadJoke();
    }

    private async void LoadJoke()
    {
        using var client = new HttpClient();
        var response = await client.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
        var joke = System.Text.Json.JsonSerializer.Deserialize<Joke>(response);
        JokeLabel.Text = $"{joke.setup}\n\n{joke.punchline}";
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