using System;
using System.Collections.ObjectModel;

namespace WpfKontaktverwaltung.ViewModels
{
    /// <summary>
    /// Übergeordnetes ViewModel des MainWindow
    /// </summary>
    class ContactCollectionViewModel : Models.ContactPropertyChanged
    {

        ViewModels.ContactViewModel _currentContact;
        private Boolean _isContactEnabled = false;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public ContactCollectionViewModel()
        {
            this.ContactCollection = new ObservableCollection<ViewModels.ContactViewModel>();
        }

        /// <summary>
        /// Collection der Kontakte
        /// </summary>
        public ObservableCollection<ViewModels.ContactViewModel> ContactCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an, ob die Felder zum editieren eines Kontaktes freigegeben werden sollen
        /// </summary>
        public bool IsContactEnabled {
            get { return _isContactEnabled; }
            set
            {
                base.SetProperty(ref _isContactEnabled, value, this, nameof(IsContactEnabled));
            }
        }

        /// <summary>
        /// Der Momentan ausgewählte Kontakt
        /// </summary>
        public ViewModels.ContactViewModel CurrentContact
        {
            get { return _currentContact; }
            set
            {
                base.SetProperty(ref _currentContact, value, this, nameof(CurrentContact));
                IsContactEnabled = (value != null);
            }
        }

        /// <summary>
        /// Kommando zum neuerstellen eines Kontaktes
        /// </summary>
        public Commands.RelayCommand CreateContactCommand
        {
            get
            {
                return new Commands.RelayCommand(
                    (a) => { return true; }
                  , (a) => {
                        AddNewContactToCollection();
                    }
                );
            }
        }

        /// <summary>
        /// Kommando zum löschen des momentan ausgewählten Kontaktes
        /// </summary>
        public Commands.RelayCommand DestroyContactCommand
        {
            get
            {
                return new Commands.RelayCommand(
                    (a) => { return true; }
                  , (a) => {
                        _currentContact.Contact.Destroy();
                        ContactCollection.Remove(_currentContact);
                        IsContactEnabled = false;
                    }
                );
            }
        }

        /// <summary>
        /// Fügt einen neuen Kontakt in die ObservableCollection ContactCollection hinzu
        /// </summary>
        private void AddNewContactToCollection()
        {
            ContactCollection.Add(new ViewModels.ContactViewModel()
            {
                Contact = new Models.Contact()
            });

            this.CurrentContact = ContactCollection[ContactCollection.Count - 1];
        }

    }
}
