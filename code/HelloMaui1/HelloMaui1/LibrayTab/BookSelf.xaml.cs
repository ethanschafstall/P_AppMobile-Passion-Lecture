using HttpClientConnection;

namespace HelloMaui1;

public partial class BookSelf : ContentPage
{
	public BookSelf()
	{
		InitializeComponent();
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
}
