namespace WpfKontaktverwaltung.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactViewModel : Models.ContactPropertyChanged
    {
        private Models.Contact _contact;

        /// <summary>
        /// Macht den Zugrundeliegenden Kontakt öffentlich
        /// </summary>
        public Models.Contact Contact
        {
            get { return _contact; }
            set
            {
                if (_contact == null)
                {
                    SetProperty(ref _contact, value, this, nameof(Contact));
                }
            }
        }

        /// <summary>
        /// Kommando um einen Kontakt zu speichern
        /// </summary>
        public Commands.RelayCommand PersistContactCommand
        {
            get
            {
                return new Commands.RelayCommand(
                    (a) => { return _contact.IsDirty; }
                  , (a) => { Contact.Persist(); }
                );
            }
        }

        /// <summary>
        /// Gibt an, ob speichern aktiviert werden kann
        /// </summary>
        public bool IsSaveEnabled
        {
            get { return this.Contact.IsDirty; }
        }

    }
}
