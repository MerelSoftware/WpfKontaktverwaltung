namespace WpfKontaktverwaltung.Interfaces
{
    /// <summary>
    /// Interface für Objekte, die in irgendeiner weise Persistent gehalten werden sollen
    /// </summary>
    interface IPersistable
    {
        void Persist();
        void Destroy();
    }
}
