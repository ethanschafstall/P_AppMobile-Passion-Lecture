using HttpClientConnection;

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
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Publish Date:  {item.booPublishDate}",
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Excerpt:   {item.booExcerpt}",
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Page Count:    {item.booPageCount}",
            FontSize = 14,
        });
        stack.Add(new Label
        {
            Text = $"Average Rating:    {item.booAvgRating}",
            FontSize = 14,
        });
    }
}