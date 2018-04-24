using System;

namespace Program
{
    public class EgzemplarzKsiazki
    {
        public int IdEgzemplarza { get; set; }
        public Ksiazka Ksiazka { get; set; }
        public string OpisKsiazki { get; set; }
        public DateTime DataZakupu { get; set; }

        public EgzemplarzKsiazki(Ksiazka newKsiazka, int newIdEgzemplarza, string newOpisKsiazki, DateTime newDataZakupu)
        {
            IdEgzemplarza = newIdEgzemplarza;
            Ksiazka = newKsiazka;
            OpisKsiazki = newOpisKsiazki;
            DataZakupu = newDataZakupu;
        }
    }

    
}
