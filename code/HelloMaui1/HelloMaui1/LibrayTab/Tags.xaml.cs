

using HttpClientConnection;
using Microsoft.Maui.Controls;

namespace HelloMaui1;

public partial class Tags : ContentPage
{
	private List<Category> _categories;

    public Tags()
	{
		InitializeComponent();
        GetDataAsync();
        PopulateTags();
    }

    /// <summary>
    /// Method for creating the tag buttons based on the tags list, and giving them a random color
    /// </summary>
    private void PopulateTags() 
	{ 
		List<string> tags = new List<string>() { "Horror", "Romatic", "Fiction", "Sci-Fi", "Horror", "Romatic", "Fiction", "Sci-Fi" , 
                                                 "Horror", "Romatic", "Fiction", "Sci-Fi" , "Horror", "Romatic", "Fiction", "Sci-Fi" };

        for (int i = 0; i < tags.Count(); i++)
        {
            Button button = CreateTag(tags[i]);
            button.Clicked += (sender, e) =>
            {
                CreateTagsPage(button.Text);
            };
            stack.Add(button);
        }
	}
    private Button CreateTag(string text) {
        
        Random random = new Random();
        return new Button
        {
            Text = text,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 5, Bottom = 5 },
            HeightRequest = 60,
            WidthRequest = 110,
            TextTransform = TextTransform.Uppercase,
            TextColor = Color.FromArgb("#000000"),
            BackgroundColor = Color.FromArgb(GeneratePastelColor(random)),
            CornerRadius = 15
        };
    }
    private async void CreateTagsPage(string name) 
    {
        await Navigation.PushModalAsync(new TagPage(name));
    }
    public async Task GetDataAsync()
    {
        try
        {
            // Fetch books asynchronously and assign the result directly to _books
            _categories = await HTTP.GetCategories();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately (e.g., show an error message)
            Console.WriteLine($"Error fetching books: {ex.Message}");
        }

    }
    private static string GeneratePastelColor(Random random)
    {
        // Generate pastel colors by randomly selecting low saturation and high brightness
        byte[] rgb = new byte[3];
        random.NextBytes(rgb);

        // Adjust the brightness
        int brightness = random.Next(128, 256); // Adjust this range for different brightness levels

        // Mix the RGB values with white
        byte mixValue = (byte)((255 + brightness) / 2);
        byte r = (byte)((rgb[0] + mixValue) / 2);
        byte g = (byte)((rgb[1] + mixValue) / 2);
        byte b = (byte)((rgb[2] + mixValue) / 2);

        return $"#{r:X2}{g:X2}{b:X2}";
    }
}