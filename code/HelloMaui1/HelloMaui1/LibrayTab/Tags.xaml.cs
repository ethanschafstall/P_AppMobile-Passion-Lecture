using HttpClientConnection;

namespace HelloMaui1;

public partial class Tags : ContentPage
{
	public Tags()
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

}