using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Program
{
    public class DataRepository
    {

        private DataContext _Kontener;
        public DataContext Kontener
        {
            get
            {
                return _Kontener;
            }
            private set
            {
                _Kontener = value;
            }
        }
        public int EgzemplarzeEvent { get; set; }
        public int KsiazkiEvent { get; set; }
        public long CzytelnicyEvent { get; set; }

        public DataRepository(Wypelnij w) => Kontener = w.DC;


        #region Eventy
        public delegate void ModyfikacjaCzytelnikowEventHandler(Object o, EventArgs e);
        public event ModyfikacjaCzytelnikowEventHandler ModyfikacjaCzytelnikow;

        public delegate void ModyfikacjaKsiazekEventHandler(Object o, EventArgs e);
        public event ModyfikacjaKsiazekEventHandler ModyfikacjaKsiazek;

        public delegate void ModyfikacjaEgzemplarzyEventHandler(Object o, EventArgs e);
        public event ModyfikacjaEgzemplarzyEventHandler ModyfikacjaEgzemplarzy;
        protected virtual void OnModyfikacjaCzytelnikow()
        {
            if (ModyfikacjaCzytelnikow != null)
            {
                ModyfikacjaCzytelnikow(this, EventArgs.Empty);
            }
        }
        protected virtual void OnModyfikacjaKsiazek()
        {
            if (ModyfikacjaKsiazek != null)
            {
                ModyfikacjaKsiazek(this, EventArgs.Empty);
            }
        }
        protected virtual void OnModyfikacjaEgzemeplarzy()
        {
            if (ModyfikacjaEgzemplarzy != null)
            {
                ModyfikacjaEgzemplarzy(this, EventArgs.Empty);
            }
        }
        #endregion

        #region MetodyCzytelnika
        public void DodajCzytelnika(Czytelnik czytelnik)
        {
            Kontener.czytelnicy.Add(czytelnik);
            CzytelnicyEvent = 1;
            OnModyfikacjaCzytelnikow();

        }

        public Czytelnik PobierzCzytelnika(int id)
        {
            Czytelnik toReturn = null;
            foreach (Czytelnik c in Kontener.czytelnicy)
            {
                if (c.IdCzytelnika == id)
                {
                    toReturn = c;
                }
            }
            CzytelnicyEvent = 2;
            OnModyfikacjaCzytelnikow();
            return toReturn;

        }

        public List<Czytelnik> PobierzCzytelnikow()
        {
            CzytelnicyEvent = 3;
            OnModyfikacjaCzytelnikow();
            return Kontener.czytelnicy;
        }

        public void UaktualnijCzytelnika(int id, params string[] args)
        {
            if (args.Length == 1)
                foreach (Czytelnik c in Kontener.czytelnicy)
                    if (c.IdCzytelnika == id)
                        c.Imie = args[0];
            if (args.Length == 2)
                foreach (Czytelnik c in Kontener.czytelnicy)
                    if (c.IdCzytelnika == id)
                    {
                        c.Imie = args[0];
                        c.Nazwisko = args[1];
                    }
            if (args.Length > 2)
                WriteLine("Nieprawidlowa ilosc argumentow");

            CzytelnicyEvent = 4;
            OnModyfikacjaCzytelnikow();

        }
        public void UsunCzytelnika(int idCzytelnika)
        {
            Kontener.czytelnicy.Remove(Kontener.czytelnicy.Find(p => p.IdCzytelnika == idCzytelnika));
            CzytelnicyEvent = 5;
            OnModyfikacjaCzytelnikow();

        }
        #endregion

        #region MetodyKsiazki

        public void DodajKsiazke(int value, Ksiazka ksiazka)
        {
            Kontener.ksiazki.Add(value, ksiazka);
            KsiazkiEvent = 1;
            OnModyfikacjaKsiazek();
        }

        public Ksiazka PobierzKsiazke(int key)
        {
            Ksiazka toReturn = null;
            foreach (KeyValuePair<int, Ksiazka> entry in Kontener.ksiazki)
            {
                if (entry.Key == key)
                    toReturn = entry.Value;
            }
            KsiazkiEvent = 2;
            OnModyfikacjaKsiazek();
            return toReturn;

        }
        public Dictionary<int, Ksiazka> PobierzKsiazki()
        {
            KsiazkiEvent = 3;
            OnModyfikacjaKsiazek();
            return Kontener.ksiazki;
        }

        public void UaktualnijKsiazke(int id, params string[] args)
        {
            if (args.Length == 1)
                foreach (KeyValuePair<int, Ksiazka> entry in Kontener.ksiazki)
                    if (entry.Value.IdKsiazki == id)
                        entry.Value.Tytul = args[0];
            if (args.Length >= 2)
                foreach (KeyValuePair<int, Ksiazka> entry in Kontener.ksiazki)
                    if (entry.Value.IdKsiazki == id)
                    {
                        for (int i = 0; i < args.Length; i++)
                            entry.Value.autorzy.Add(args[i]);
                    }
            KsiazkiEvent = 4;
            OnModyfikacjaKsiazek();
        }
        public void UsunKsiazke(int idKsiazki)
        {
            for (int i = 0; i < Kontener.ksiazki.Count; i++)
            {
                var element = Kontener.ksiazki.ElementAt(i);
                var keyValue = element.Key;
                if (element.Key == idKsiazki)
                    Kontener.ksiazki.Remove(keyValue);
            }
            KsiazkiEvent = 5;
            OnModyfikacjaKsiazek();
        }

        #endregion

        #region MetodyEgzemplarzaKsiazki
        public void DodajEgzemplarz(EgzemplarzKsiazki egzemplarz)
        {
            Kontener.egzemplarzeKsiazek.Add(egzemplarz);
            EgzemplarzeEvent = 1;
            OnModyfikacjaEgzemeplarzy();
        }

        public EgzemplarzKsiazki PobierzEgzemplarz(int id)
        {
            EgzemplarzKsiazki toReturn = null;
            foreach (EgzemplarzKsiazki e in Kontener.egzemplarzeKsiazek)
            {
                if (e.IdEgzemplarza == id)
                {
                    toReturn = e;
                }
            }
            EgzemplarzeEvent = 2;
            OnModyfikacjaEgzemeplarzy();
            return toReturn;

        }
        public List<EgzemplarzKsiazki> PobierzEgzemplarze()
        {
            EgzemplarzeEvent = 3;
            OnModyfikacjaEgzemeplarzy();
            return Kontener.egzemplarzeKsiazek;
        }

        public void UaktualnijEgzemplarz(int idEgzemplarza, Ksiazka newKsiazka)
        {
            foreach (EgzemplarzKsiazki e in Kontener.egzemplarzeKsiazek)
                if (e.IdEgzemplarza == idEgzemplarza)
                    e.Ksiazka = newKsiazka;
            EgzemplarzeEvent = 4;
            OnModyfikacjaEgzemeplarzy();
        }

        public void UaktualnijEgzemplarz(int idEgzemplarza, string newOpis)
        {
            foreach (EgzemplarzKsiazki e in Kontener.egzemplarzeKsiazek)
                if (e.IdEgzemplarza == idEgzemplarza)
                    e.OpisKsiazki = newOpis;
            EgzemplarzeEvent = 4;
            OnModyfikacjaEgzemeplarzy();
        }

        public void UaktualnijEgzemplarz(int idEgzemplarza, DateTime newDataZakupu)
        {
            foreach (EgzemplarzKsiazki e in Kontener.egzemplarzeKsiazek)
                if (e.IdEgzemplarza == idEgzemplarza)
                    e.DataZakupu = newDataZakupu;
            EgzemplarzeEvent = 4;
            OnModyfikacjaEgzemeplarzy();
        }
        public void UsunEgzemplarz(int idEgzemplarza)
        {
            Kontener.egzemplarzeKsiazek.Remove(Kontener.egzemplarzeKsiazek.Find(p => p.IdEgzemplarza == idEgzemplarza));
            EgzemplarzeEvent = 5;
            OnModyfikacjaEgzemeplarzy();
        }
        #endregion

        #region MetodyWypozyczen
        public void DodajWypozycznie(Wypozyczenie wypozyczenie)
        {
            Kontener.wypozyczenia.Add(wypozyczenie);
        }
        public Wypozyczenie PobierzWypozyczenie(int id)
        {
            Wypozyczenie toReturn = null;
            foreach (Wypozyczenie w in Kontener.wypozyczenia)
            {
                if (w.IdWypozyczenia == id)
                {
                    toReturn = w;
                }
            }
            return toReturn;

        }
        public ObservableCollection<Wypozyczenie> PobierzWypozyczenia()
        {
            return Kontener.wypozyczenia;
        }

        public void UaktualnijWypozyczenie(int idWypozyczenia, Czytelnik newCzytelnik)
        {
            foreach (Wypozyczenie w in Kontener.wypozyczenia)
            {
                if (w.IdWypozyczenia == idWypozyczenia)
                {
                    w.Czytelnik = newCzytelnik;
                }
            }
        }

        public void UaktualnijWypozyczenie(int idWypozyczenia, EgzemplarzKsiazki newEgzemplarzKsiazki)
        {
            foreach (Wypozyczenie w in Kontener.wypozyczenia)
            {
                if (w.IdWypozyczenia == idWypozyczenia)
                {
                    w.EgzemplarzKsiazki = newEgzemplarzKsiazki;
                }
            }
        }

        public void UaktualnijWypozyczenie(int idWypozyczenia, params DateTime[] args)
        {
            Kontener.wypozyczenia.Single(i => i.IdWypozyczenia == idWypozyczenia);
            foreach (Wypozyczenie w in Kontener.wypozyczenia)
            {
                if (w.IdWypozyczenia == idWypozyczenia)
                {
                    if (args.Length == 1)
                    {
                        w.OdKiedy = args[0];
                    }
                    if (args.Length == 2)
                    {
                        w.OdKiedy = args[0];
                        w.DoKiedy = args[1];

                    }
                }
            }
        }
        public void UsunWypozyczenie(int idWypozyczenia)
        {
            Kontener.wypozyczenia.Remove(Kontener.wypozyczenia.Single(i => i.IdWypozyczenia == idWypozyczenia));

        }
        #endregion
    }

    
}
