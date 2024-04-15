using HttpClientConnection;

namespace HelloMaui1;

public partial class Collections : ContentPage
{
	public Collections()
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