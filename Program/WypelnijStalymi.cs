using System;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    public class WypelnijStalymi : Wypelnij
    {
        public WypelnijStalymi()
        {
            DC.czytelnicy.Add(new Czytelnik(1, "FirstName1", "LastName1"));
            DC.czytelnicy.Add(new Czytelnik(2, "FirstName2", "LastName2"));
            DC.czytelnicy.Add(new Czytelnik(3, "FirstName3", "LastName3"));
            DC.czytelnicy.Add(new Czytelnik(4, "FirstName4", "LastName4"));

            DC.ksiazki.Add(1, new Ksiazka(1, "Potop", new ArrayList { "H. Sienkiewicz" }));
            DC.ksiazki.Add(2, new Ksiazka(2, "Systemy polityczne współeczesnego świata", new ArrayList { "A.Antoszewski", "R.Herbut" }));


            DC.egzemplarzeKsiazek.Add(new EgzemplarzKsiazki(DC.ksiazki[1], 1, " Ksiazka polskiego autora", new DateTime(2000, 1, 11)));
            DC.egzemplarzeKsiazek.Add(new EgzemplarzKsiazki(DC.ksiazki[1], 2, " Kultowa powieść histroyczna ", new DateTime(2010, 6, 7)));
            DC.egzemplarzeKsiazek.Add(new EgzemplarzKsiazki(DC.ksiazki[2], 3, " Ksiazka o polityce ", new DateTime(2012, 10, 10)));
            DC.egzemplarzeKsiazek.Add(new EgzemplarzKsiazki(DC.ksiazki[2], 4, " Brak szczegolowych informacji ", new DateTime(2012, 8, 8)));

            DC.wypozyczenia.Add(new Wypozyczenie(1, DC.czytelnicy[0], DC.egzemplarzeKsiazek[0], DateTime.Now, DateTime.Now.AddDays(7)));
            DC.wypozyczenia.Add(new Wypozyczenie(2, DC.czytelnicy[1], DC.egzemplarzeKsiazek[1], DateTime.Now, DateTime.Now.AddDays(14)));
            DC.wypozyczenia.Add(new Wypozyczenie(3, DC.czytelnicy[2], DC.egzemplarzeKsiazek[2], DateTime.Now, DateTime.Now.AddDays(5)));
            DC.wypozyczenia.Add(new Wypozyczenie(4, DC.czytelnicy[3], DC.egzemplarzeKsiazek[3], DateTime.Now, DateTime.Now.AddDays(10)));
        }

    }



    
}
