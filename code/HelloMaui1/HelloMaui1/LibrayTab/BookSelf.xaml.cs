using HttpClientConnection;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HelloMaui1;

public partial class BookSelf : ContentPage
{
    private List<Book> _books;

    private FlexLayout flexLayout;
    public BookSelf()
	{
		InitializeComponent();
        GetDataAsync();
    }
    //Margin="0, 20,0,0" JustifyContent="SpaceEvenly" Wrap="Wrap"  x:Name="stack"
    private void GenerateFlexlayout()
    {
        flexLayout = new FlexLayout {
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
            Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Margin = new Thickness() { Top = 20, Left = 0, Right = 5, Bottom = 0,
           
            }
        };
        baseStack.Add(flexLayout);
    }
    public async Task GetDataAsync()
    {
        try
        {
            // Fetch books asynchronously and assign the result directly to _books
            _books = await HTTP.GetBooks();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately (e.g., show an error message)
            Console.WriteLine($"Error fetching books: {ex.Message}");
        }
        collectionView.ItemsSource = _books;
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
            ImageButton button = CreateBook(_books[i]);
            button.Clicked += (sender, e) =>
            {
                CreateBookPage((Book)button.BindingContext);
            };
            flexLayout.Add(button);
        }
        
    }
    private ImageButton CreateBook(Book item)
    {

        return new ImageButton
        {
            Source = item.booCoverImage,
            BindingContext = item,
            //Text = item.booTitle,
            //ImageSource = item.booCoverImage,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 5, Bottom = 5 },
            HeightRequest = 150,
            WidthRequest = 120,
            CornerRadius = 15
            
        };
    }
    private async void CreateBookPage(Book book)
    {
        await Navigation.PushModalAsync(new BookPage(book));
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var temp = (ImageButton)sender;
        CreateBookPage((Book)temp.CommandParameter);
    }
}
