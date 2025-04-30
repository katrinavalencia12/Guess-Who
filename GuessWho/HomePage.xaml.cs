using System.Collections.ObjectModel;

namespace GuessWho;

public partial class HomePage : ContentPage
{
    private ObservableCollection<Models.Person> people, gamePeople;
    private PersonDatabase PersonDB;

    public HomePage()
    {
        InitializeComponent();
        people = new ObservableCollection<Models.Person>();
        gamePeople = new ObservableCollection<Models.Person>();
        personListView.ItemsSource = people;
        //searchSubset = new ObservableCollection<Models.Person>();
        PersonDB = new PersonDatabase();

        InitialPersonList();
        //LoadFromDatabase();

    }

    public void OnAppearing()
    {
        Navigation.PushAsync(new ChoosingPage(gamePeople));
    }

    private async void LoadFromDatabase()
    {
        foreach (var person in await PersonDB.GetPersonAsync())
        {

            people.Add(person);
        }
    }


    private async void InitialPersonList()
    {
        people = new ObservableCollection<Models.Person>()
        {
            new Models.Person() {Name= "Ariana Grande", Sex ="female", EyeColor="brown", HairColor="brown", WearsGlasses=false, ImageUrl="ariana_grande.jpg"},
            new Models.Person() {Name= "Jennifer Lawrence", Sex ="female", EyeColor="gray", HairColor="blond", WearsGlasses=false, ImageUrl="jennifer_lawrence.jpg"},
            new Models.Person() {Name= "Olivia Rodrigo", Sex ="female", EyeColor="brown", HairColor="brown", WearsGlasses=false, ImageUrl="olivia_rodrigo.jpg"},
            new Models.Person() {Name= "Scarlett Johansson", Sex ="female", EyeColor="green", HairColor="blond", WearsGlasses=false, ImageUrl="scarlett_johansson.jpg"},
            new Models.Person() {Name= "Tom Hiddleston", Sex ="male", EyeColor="blue", HairColor="blond", WearsGlasses=false, ImageUrl = "tom_hiddleston.jpg"},
            new Models.Person() {Name= "Renee Rapp", Sex ="female", EyeColor="blue", HairColor="blond", WearsGlasses=false, ImageUrl = "renee_rapp.jpg"},
            new Models.Person() {Name= "Brad Pitt", Sex ="male", EyeColor="blue", HairColor="brown", WearsGlasses=false, ImageUrl = "brad_pitt.jpg"},
            new Models.Person() {Name= "Ryan Gosling", Sex ="male", EyeColor="blue", HairColor="blond", WearsGlasses=false, ImageUrl = "ryan_gosling.jpg"},
            new Models.Person() {Name= "Zac Efron", Sex ="male", EyeColor="blue", HairColor="brown", WearsGlasses=false, ImageUrl = "zac_efron.jpg"},
            new Models.Person() {Name= "Ryan Renolds", Sex ="male", EyeColor="brown", HairColor="brown", WearsGlasses=false, ImageUrl = "ryan_renolds.jpg"},
            new Models.Person() {Name= "Chris Pine", Sex ="male", EyeColor="blue", HairColor="blond", WearsGlasses=false, ImageUrl = "chris_pine.jpg"},
            new Models.Person() {Name= "David Beckham", Sex ="male", EyeColor="brown", HairColor="blond", WearsGlasses=false, ImageUrl = "david_beckham.jpg"},
            new Models.Person() {Name= "Selena Gomez", Sex ="female", EyeColor="brown", HairColor="black", WearsGlasses=false, ImageUrl = "selena_gomez.jpg"},
            new Models.Person() {Name= "Will Smith", Sex ="male", EyeColor="brown", HairColor="black", WearsGlasses=false, ImageUrl = "will_smith.jpg"},
            new Models.Person() {Name= "Britney Spears", Sex ="female", EyeColor="brown", HairColor="blond", WearsGlasses=false, ImageUrl = "britney_spears.jpg"},
            new Models.Person() {Name= "Lady Gaga", Sex ="female", EyeColor="green", HairColor="blond", WearsGlasses=false, ImageUrl = "lady_gaga.jpg"},
            new Models.Person() {Name= "Adam Sandler", Sex ="male", EyeColor="brown", HairColor="brown", WearsGlasses=false, ImageUrl = "adam_sandler.jpg"},
            new Models.Person() {Name= "Jennifer Lopez", Sex ="female", EyeColor="brown", HairColor="blond", WearsGlasses=false, ImageUrl = "jennifer_lopez.jpg"},
            new Models.Person() {Name= "Angelina Jolie", Sex ="female", EyeColor="blue", HairColor="brown", WearsGlasses=false, ImageUrl = "angelina_jolie.jpg"},
            new Models.Person() {Name= "Johnny Depp", Sex ="male", EyeColor="black", HairColor="brown", WearsGlasses=false, ImageUrl = "johnny_depp.jpg"},
            new Models.Person() {Name= "Emma Stone", Sex ="female", EyeColor="green", HairColor="", WearsGlasses=false, ImageUrl = "emma_stone.jpg"},
            new Models.Person() {Name= "Julia Roberts", Sex ="female", EyeColor="brown", HairColor="red", WearsGlasses=false, ImageUrl = "julia_roberts.jpg"},


        };
        personListView.ItemsSource = people;


        personListView.ItemsSource = people;

        await PersonDB.DeleteAllPeopleAsync();
        foreach (var person in people)
        {
            await PersonDB.SavePersonAsync(person);
        }

    }

    public void ToggleSelection(Models.Person person)
    {
        person.IsSelected = !person.IsSelected;

        if (!person.IsSelected)
            gamePeople.Add(person);

        else
            gamePeople.Remove(person);

    }


    void Add_New_Button_Clicked(object sender, EventArgs e)
    {
        var person = new Models.Person();
        var page = new PersonDetailPage();
        page.personSaved += (obj, copyOfPerson) =>
        {
            person.Name = copyOfPerson.Name;
            person.Sex = copyOfPerson.Sex;
            person.EyeColor = copyOfPerson.EyeColor;
            person.HairColor = copyOfPerson.HairColor;
            person.WearsGlasses = copyOfPerson.WearsGlasses;
            person.ImageUrl = copyOfPerson.ImageUrl;
            PersonDB.SavePersonAsync(person);
        };
        Navigation.PushAsync(page);
    }

    void personToggle_Toggled(object sender, ToggledEventArgs e)
    {
        var toggle = sender as Switch;
        var person = toggle.BindingContext as Models.Person;
        ToggleSelection(person);


        if (gamePeople.Count == 20)
        {

            Navigation.PushAsync(new ChoosingPage(gamePeople));

        }
    }

        void personListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var person = e.Item as Models.Person;
            var page = new PersonDetailPage(person);
            page.personSaved += (obj, copyOfPerson) =>
            {
                person.Name = copyOfPerson.Name;
                person.Sex = copyOfPerson.Sex;
                person.EyeColor = copyOfPerson.EyeColor;
                person.HairColor = copyOfPerson.HairColor;
                person.WearsGlasses = copyOfPerson.WearsGlasses;
                person.ImageUrl = copyOfPerson.ImageUrl;
                person.ID = copyOfPerson.ID;
                PersonDB.SavePersonAsync(person);
            };
            Navigation.PushAsync(page);
        }

}

