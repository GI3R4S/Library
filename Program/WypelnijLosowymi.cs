using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    public class WypelnijLosowymi : Wypelnij
    {
        Random gen = new Random();
        public string GenerujLancuch(int length)
        {

            const string znaki = "abcdefghijklmnopqrstuwxyz";
            string doZwrocenia = new String(Enumerable.Repeat(znaki, length).Select(s => s[gen.Next(s.Length)]).ToArray());
            return doZwrocenia;
        }
        public WypelnijLosowymi(int iloscCzytelnikow, int iloscKsiazek, int iloscEgzemplarzy, int iloscWypozyczen)
        {
            int losowyCzytelnik = 0;
            int losowyEgzemplarz = 0;
            int losowaKsiazka = 0;
            DC = new DataContext();
            for(int i = 1; i<= iloscCzytelnikow; i++)
            {
                DC.czytelnicy.Add(new Czytelnik(i, GenerujLancuch(gen.Next(5, 10)),GenerujLancuch(gen.Next(5, 15))));
            }

            for(int i = 1; i<= iloscKsiazek; i++)
            {
                int iloscAutorow = gen.Next(10) +1;
                ArrayList autorzy = new ArrayList();
                for (int j = 0; j < iloscAutorow; j++)
                {
                    autorzy.Add(GenerujLancuch(gen.Next(5, 15)));
                }
                DC.ksiazki.Add(i, new Ksiazka(i, GenerujLancuch(gen.Next(5, 20)), autorzy));
            }
            for (int i = 1; i <= iloscEgzemplarzy; i++)
            {
                Ksiazka k;
                losowaKsiazka = gen.Next(iloscKsiazek) + 1;
                k = DC.ksiazki[losowaKsiazka];
                DC.egzemplarzeKsiazek.Add(new EgzemplarzKsiazki(k, i, GenerujLancuch(gen.Next(10, 40)),new DateTime(gen.Next(1975,2018),gen.Next(1,12),gen.Next(1,28))));
            }
            for(int i = 1; i<= iloscWypozyczen; i++)
            {
                losowyEgzemplarz = gen.Next(iloscEgzemplarzy) + 1;
                losowyCzytelnik = gen.Next(iloscCzytelnikow) + 1;

                EgzemplarzKsiazki egzemplarzKsiazki = DC.egzemplarzeKsiazek.Find(p => p.IdEgzemplarza == losowyEgzemplarz);
                Czytelnik czytelnik = DC.czytelnicy.Find(p => p.IdCzytelnika == losowyCzytelnik);
                DC.wypozyczenia.Add(new Wypozyczenie(i,czytelnik ,egzemplarzKsiazki, new DateTime(gen.Next(1975, 2000), gen.Next(1, 12), gen.Next(1, 28)), new DateTime(gen.Next(2001, 2018), gen.Next(1, 12), gen.Next(1, 28))));

            }





        }
    }

    
}
