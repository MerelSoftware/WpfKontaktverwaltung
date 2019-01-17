using System;

namespace WpfKontaktverwaltung.Models
{
    /// <summary>
    /// Kontakt Model
    /// </summary>
    public class Contact : ContactPropertyChanged, Interfaces.IPersistable
    {
        private String _surname;
        private String _lastname;
        private String _fullname;
        private String _organisation;
        private String _phone;
        private String _email;
        private String _note;

        private Boolean _isDirty;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Contact()
        {
            UpdateFullname();
        }


        /// <summary>
        /// Vorname des Kontaktes
        /// </summary>
        public String Surname
        {
            get { return _surname; }
            set
            {
                base.SetProperty(ref _surname, value, this, nameof(Surname));
                this.IsDirty = true;
                UpdateFullname();
            }
        }

        /// <summary>
        /// Nachname des Kontaktes
        /// </summary>
        public String Lastname
        {
            get { return _lastname; }
            set
            {
                base.SetProperty(ref _lastname, value, this, nameof(Lastname));
                UpdateFullname();
            }
        }

        /// <summary>
        /// Aus Vor- und Nachname des Kontaktes zusammegesetzes Name
        /// </summary>
        public String Fullname
        {
            get
            {
                return _fullname;
            }
        }

        /// <summary>
        /// Organisation des Kontaktes
        /// </summary>
        public String Organisation
        {
            get { return _organisation; }
            set
            {
                base.SetProperty(ref _organisation, value, this, nameof(Organisation));
                UpdateFullname();
            }
        }

        /// <summary>
        /// Telefonnummer
        /// </summary>
        public String Phone
        {
            get { return _phone; }
            set
            {
                base.SetProperty(ref _phone, value, this, nameof(Phone));
            }
        }


        /// <summary>
        /// E-Mailadresse
        /// </summary>
        public String EMail
        {
            get { return _email; }
            set
            {
                base.SetProperty(ref _email, value, this, nameof(EMail));
            }
        }

        /// <summary>
        /// Notiz zum Kontakt
        /// </summary>
        public String Note
        {
            get { return _note; }
            set
            {
                base.SetProperty(ref _note, value, this, nameof(Note));
            }
        }

        /// <summary>
        /// Gibt an, ob das Objekt modifiziert wurde
        /// </summary>
        public Boolean IsDirty
        {
            get { return _isDirty; }
            set
            {
                SetProperty(ref _isDirty, value, this, nameof(IsDirty));
            }
        }

        /// <summary>
        /// Hilfsfunktion um den vollen Namen nach jedem ändern des
        /// Vor-, Zu- oder Organisationsnamen zu aktualisieren
        /// </summary>
        private void UpdateFullname()
        {
            String nameresult;
            if (String.IsNullOrWhiteSpace((nameresult = _surname + " " + _lastname)) == false)
            {
                base.SetProperty(ref _fullname, nameresult, this, nameof(Fullname));
                return;
            }

            if (String.IsNullOrWhiteSpace((nameresult = _organisation)) == false)
            {
                base.SetProperty(ref _fullname, nameresult, this, nameof(Fullname));
                return;
            }
        }

        /// <summary>
        /// Speicherfunktion
        /// </summary>
        public void Persist()
        {
            System.Windows.MessageBox.Show("Speicherfunktion des Kontakts aufgerufen", "Nicht MVVM");
        }

        /// <summary>
        /// Löschfunktion
        /// </summary>
        public void Destroy()
        {
            System.Windows.MessageBox.Show("Löschfunktion des Kontakts aufgerufen", "Nicht MVVM");
        }
    }
}
