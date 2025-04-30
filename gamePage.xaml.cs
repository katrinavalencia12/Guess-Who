using System.Collections.ObjectModel;
namespace GuessWho;

public partial class gamePage : ContentPage
{

	private string answer;

    private ObservableCollection<Models.Person> ppl;



    public gamePage(ObservableCollection<Models.Person> peps, string answer)
	{
        InitializeComponent();
		answer = this.answer;
        ppl = peps;
        setUpGrid();

    }

    private void setUpGrid()
    {
        int index = 0;
        for (var r = 1; r < 6; r++)
        {
            for (var c = 0; c < 5; c++)
            {
                if (index < ppl.Count)
                {
                    var button = new Button
                    {
                        Text = ppl[index].Name,
                        TextColor = Colors.Black,
                        BackgroundColor = Colors.Yellow,
                        CornerRadius = 20,
                        WidthRequest = 100,
                        HeightRequest = 100,
                        ImageSource = ppl[index].ImageUrl

                    };
                    button.Clicked += (sender, e) => { Card_Clicked(sender, e); };
                    guessWhoGame.Add(button, c, r);
                }
                index++;
            }
        }
    }

    void Card_Clicked(Object sender, EventArgs e)
	{
		var button = sender as Button;
		if (button != null)
		{
            if(button.BackgroundColor == Colors.Yellow)
            {
                button.BackgroundColor = Colors.Blue;
                foreach(var person in ppl)
                {
                    if (button.Text.Equals(person.Name))
                        ppl.Remove(person);
                }
            }

		}


	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PushAsync(new HomePage());
    }

	void Button_Clicked_1(object sender, EventArgs e)
	{
        if (ppl.Count != 1)
        {
            return;
        }
        var person = ppl[0];
		if (string.Equals(person.Name, answer, StringComparison.OrdinalIgnoreCase))
        {
			DisplayAlert("you win", "good job", "ok");
		}
        else
        {
            DisplayAlert("you lose", "try again next time", "ok");
        }
	}
}
