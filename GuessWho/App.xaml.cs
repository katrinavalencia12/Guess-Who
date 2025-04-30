namespace GuessWho;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new HomePage();
        MainPage = new NavigationPage(new startPage());
        //MainPage = new NavigationPage(new HomePage());

    }
}

