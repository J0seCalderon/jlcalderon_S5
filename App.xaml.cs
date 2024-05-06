namespace jlcalderon_S5
{
    public partial class App : Application
    {
        public static PersonRepository personRepo {  get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.vPersona());
            personRepo = personRepository;

        }
    }
}
