using HttpClientConnection;
using System.Xml.Linq;

namespace HelloMaui1;

public partial class BookPage : ContentPage
{
	public BookPage(Book item)
	{
		InitializeComponent();
        stack.Add(new Label
        {
            Text = item.booTitle,
            FontSize = 22,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            FontAttributes = FontAttributes.Bold,
        }
        );
		stack.Add(new Image
        {
            Source = item.booCoverImage,
            Margin = new Thickness() { Top = 5, Left = 0, Right = 5, Bottom = 5 },
            HeightRequest = 450,
        });
        stack.Add(new Label
        {
            Text = $"Summary:   {item.booSummary}",
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Publish Date:  {item.booPublishDate}",
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            FontSize = 14,
        });
        var excerptButton = new Button
        {
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            Text = $"Book Excerpt",
        };
        excerptButton.Clicked += async (sender, e) =>
        {
            await Navigation.PushModalAsync(new excerptView(item.booExcerpt));
        };

        stack.Add(excerptButton);
        stack.Add(new Label
        {
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            Text = $"Page Count:    {item.booPageCount}",
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Average Rating:    {item.booAvgRating}",
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            FontSize = 14,
        });
        stack.Add(new Button
        {
            Margin = new Thickness() { Top = 5, Left = 0, Right = 0, Bottom = 5 },
            Text = "Lire",
            WidthRequest = 100,

        });
    }
}