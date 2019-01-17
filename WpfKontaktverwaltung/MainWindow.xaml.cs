using System.Windows;

namespace WpfKontaktverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Demo Daten
            ViewModels.ContactCollectionViewModel contactCollectionViewModel = new ViewModels.ContactCollectionViewModel();
            contactCollectionViewModel.ContactCollection.Add(new ViewModels.ContactViewModel() { Contact = new Models.Contact() { Surname = "Tim", Lastname = "Ebersbach", Phone = "55523 35 61 62", EMail=""} });
            contactCollectionViewModel.ContactCollection.Add(new ViewModels.ContactViewModel() { Contact = new Models.Contact() { Surname = "Jennifer", Lastname = "Scherer", Phone= "55523 39 00 54" } });
            contactCollectionViewModel.ContactCollection.Add(new ViewModels.ContactViewModel() { Contact = new Models.Contact() { Organisation ="Grunwald KG", Phone = "55502 29 04 35" } });
            contactCollectionViewModel.ContactCollection.Add(new ViewModels.ContactViewModel() { Contact = new Models.Contact() { Surname="Daniel", Lastname="Kohler", Organisation="Grunwald KG", Phone = "55586 18 05 70" } });

            this.DataContext = contactCollectionViewModel;
        }
    }
}
