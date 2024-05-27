namespace HelloMaui1;

public class excerptView : ContentPage
{
	public excerptView(string link)
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Image { Source = link
				}
			}
		};
	}
}