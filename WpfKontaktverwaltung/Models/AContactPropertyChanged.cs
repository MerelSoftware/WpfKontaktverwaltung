using System;
using System.ComponentModel;

namespace WpfKontaktverwaltung.Models
{
    /// <summary>
    /// Abstracte Basisklasse um PropertyChanged Aufzurufen
    /// </summary>
    public abstract class ContactPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Generische Funktion um PropertyChanged aufzurufen, minimiert etwas den Overhead
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member">Referenz auf die Membervariable</param>
        /// <param name="value">Neuer Wert für die Membervariable</param>
        /// <param name="caller">Aufrufende Instanz der abgeleiteten Klasse </param>
        /// <param name="propertyname">Name der Eigenschaft</param>
        protected void SetProperty<T>(ref T member, T value, ContactPropertyChanged caller, String propertyname)
        {
            member = value;
            PropertyChanged(caller, new PropertyChangedEventArgs(propertyname));
        }
    }
}
