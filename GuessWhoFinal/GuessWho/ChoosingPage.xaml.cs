using System.Collections.ObjectModel;

namespace GuessWho;

public partial class ChoosingPage : ContentPage
{
    private string answer { get; set; }

    private ObservableCollection<Models.Person> ppl;


    public ChoosingPage(ObservableCollection<Models.Person> peps)
    {
        InitializeComponent();
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
        button.BackgroundColor = Colors.Red;
        answer = button.Text;


    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }

    async void Button_Clicked_1(object sender, EventArgs e)
    {
        //DisplayAlert(answer +"", "yes", "yes");
        Navigation.PushAsync(new gamePage(ppl, answer));
    }


}

