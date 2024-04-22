

namespace HelloMaui1;

public partial class Tags : ContentPage
{
	private List<Button> buttons;
	public Tags()
	{
		InitializeComponent();
		PopulateTags();
    }

    /// <summary>
    /// Method for creating the tag buttons based on the tags list, and giving them a random color
    /// </summary>
    private void PopulateTags() 
	{ 
		List<string> tags = new List<string>() { "Horror", "Romatic", "Fiction", "Sci-Fi"};
        List<string> colors = new List<string>() { "Horror", "Romatic", "Fiction", "Sci-Fi" };
		int randomValue;
        Random random = new Random();


        //stack.Add(test);
        for (int i = 0; i < tags.Count(); i++)
        {
            stack.Add(new Button
            {
                Text = tags[i],
                Margin = 10,
                HeightRequest = 100,
                WidthRequest = 100,

            });
        //            < Setter Property = "BackgroundColor" Value = "LightGrey" ></ Setter >
        //< Setter Property = "CornerRadius" Value = "15" />
        //< Setter Property = "TextColor" Value = "Black" />
        //< Setter Property = "TextTransform" Value = "Uppercase" />
        //< Setter Property = "WidthRequest" Value = "110" />
        //< Setter Property = "HeightRequest" Value = "60" />
        //< Setter Property = "Margin" Value = "5,0,5,10" />

        }
	}

}