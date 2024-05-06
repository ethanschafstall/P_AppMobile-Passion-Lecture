using HttpClientConnection;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HelloMaui1;

public partial class BookSelf : ContentPage
{
    private List<Book> _books;
    public BookSelf()
	{
		InitializeComponent();
        GetDataAsync();
    }
    public async Task GetDataAsync()
    {
        try
        {
            // Fetch books asynchronously and assign the result directly to _books
            _books = await HTTP.GetBooks();
            // Populate the UI with fetched books
            PopulateBooks();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately (e.g., show an error message)
            Console.WriteLine($"Error fetching books: {ex.Message}");
        }
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
    }
    private async void EditSettings(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new DisplayBookSettings());
    }
    private void PopulateBooks()
    {

        for (int i = 0; i < _books.Count(); i++)
        {
            Button button = CreateBook(_books[i]);
            button.Clicked += (sender, e) =>
            {
                CreateTagsPage(button.Text);
            };
            stack.Add(button);
        }
    }
    private Button CreateBook(Book item)
    {

        return new Button
        {
            Text = item.booTitle,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 5, Bottom = 5 },
            HeightRequest = 60,
            WidthRequest = 110,
            TextTransform = TextTransform.Uppercase,
            TextColor = Color.FromArgb("#000000"),
            CornerRadius = 15
        };
    }
    private async void CreateTagsPage(string name)
    {
        await Navigation.PushModalAsync(new TagPage(name));
    }
}
