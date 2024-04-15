using HttpClientConnection;

namespace HelloMaui1;

public partial class YourBooks : ContentPage
{
	public YourBooks()
	{
		InitializeComponent();
	}
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        CallAPI.GetSunrise();
    }
    private void OnImageButtonClicked(object sender, EventArgs e) { }
}
