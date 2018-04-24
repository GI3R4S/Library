using System;

namespace Program
{
    public class Wypozyczenie
    {
        public int IdWypozyczenia { get; set; }
        public Czytelnik Czytelnik { get; set; }
        public EgzemplarzKsiazki EgzemplarzKsiazki { get; set; }
        public DateTime OdKiedy { get; set; }
        public DateTime DoKiedy { get; set; }

        public Wypozyczenie(int noweIdWypozyczenia, Czytelnik newCzytelnik, EgzemplarzKsiazki newEgzemplarzKsiazki, DateTime noweOdKiedy, DateTime noweDoKiedy)
        {
            IdWypozyczenia = noweIdWypozyczenia;
            Czytelnik = newCzytelnik;
            EgzemplarzKsiazki = newEgzemplarzKsiazki;
            OdKiedy = noweOdKiedy;
            DoKiedy = noweDoKiedy;
        }

    }

    
}
