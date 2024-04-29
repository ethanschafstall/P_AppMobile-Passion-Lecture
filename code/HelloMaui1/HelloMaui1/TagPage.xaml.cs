using static System.Net.Mime.MediaTypeNames;

namespace HelloMaui1;

public partial class TagPage : ContentPage
{
	public TagPage(string tagId)
	{
		InitializeComponent();
		stack.Add(new Button
        {
            Text = tagId,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 5, Bottom = 5 },
            HeightRequest = 60,
            WidthRequest = 110,
            TextTransform = TextTransform.Uppercase,
            TextColor = Color.FromArgb("#000000"),
            CornerRadius = 15
        });
    }
}