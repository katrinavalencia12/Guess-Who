namespace GuessWho;

public partial class startPage : ContentPage
{
	public startPage()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		var button = sender as Button;
		if (button.Text.Contains("2"))
		{
			Navigation.PushAsync(new HomePage());
		}
    }
}
