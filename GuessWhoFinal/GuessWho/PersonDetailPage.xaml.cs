namespace GuessWho;

public partial class PersonDetailPage : ContentPage
{
    private Models.Person copyOfPerson;
    public event EventHandler<Models.Person> personSaved;
    public PersonDetailPage()
    {
        InitializeComponent();
        copyOfPerson = new Models.Person();
        BindingContext = copyOfPerson;
    }
    public PersonDetailPage(Models.Person person)
    {
        InitializeComponent();
        copyOfPerson = new Models.Person();
        copyOfPerson.Name = person.Name;
        copyOfPerson.Sex = person.Sex;
        copyOfPerson.EyeColor = person.EyeColor;
        copyOfPerson.HairColor = person.HairColor;
        copyOfPerson.WearsGlasses = person.WearsGlasses;
        copyOfPerson.ImageUrl = person.ImageUrl;
        copyOfPerson.ID = person.ID;
        BindingContext = copyOfPerson;
    }

    private void SaveButtonClicked(object sender, EventArgs e)
    {
        personSaved?.Invoke(this, copyOfPerson);
        Navigation.PopAsync();
    }
}
