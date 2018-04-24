namespace Program
{
    public class Czytelnik
    {
        public int IdCzytelnika { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Czytelnik(int newID, string newImie, string newNazwisko)
        {
            IdCzytelnika = newID;
            Imie = newImie;
            Nazwisko = newNazwisko;
        }
        public Czytelnik() { }
    }

    
}
