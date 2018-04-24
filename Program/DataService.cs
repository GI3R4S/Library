using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Program
{
    public class DataService
    {

        private DataRepository dr;
        public DataService(DataRepository newDr)
        {
            dr = newDr;
            dr.PobierzWypozyczenia().CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(OnWypozyczeniaChange);
            dr.ModyfikacjaCzytelnikow += OnCzytelnicyChange;
            dr.ModyfikacjaKsiazek += OnKsiazkiChange;
            dr.ModyfikacjaEgzemplarzy += OnEgzemplarzeChange;
        }
        #region ObslugaZdarzen
        public void OnWypozyczeniaChange(Object o, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                WriteLine("Dodano pozycję do wypożyczeń");
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                WriteLine("Zamieniono element kolekcji na inny");

            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                WriteLine("Usuniete element z kolekcji");

            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                WriteLine("Przemieszczono element wewnatrz kolekcji");

            }
        }
        public void OnCzytelnicyChange(Object o, EventArgs e)
        {
            switch (dr.CzytelnicyEvent)
            {
                case 1:
                    {
                        WriteLine("Dodano element do kolekcji czytlenikow");
                        break;
                    }
                case 2:
                    {
                        WriteLine("Pobrano element z kolekcji czytelnikow");
                        break;
                    }
                case 3:
                    {
                        WriteLine("Pobrano calosc kolecji czytelnikow");
                        break;
                    }
                case 4:
                    {
                        WriteLine("Zaktualizowano element kolekcji czytlenikow");
                        break;
                    }
                case 5:
                    {
                        WriteLine("Usunieto element z kolekcji czytlenikow");
                        break;
                    }
                default:
                    {
                        WriteLine("Unknown event code");
                        break;
                    }
            }

        }
        public void OnKsiazkiChange(Object o, EventArgs e)
        {
            switch (dr.KsiazkiEvent)
            {
                case 1:
                    {
                        WriteLine("Dodano element do kolekcji ksiazek");
                        break;
                    }
                case 2:
                    {
                        WriteLine("Pobrano element z kolekcji ksiazek");
                        break;
                    }
                case 3:
                    {
                        WriteLine("Pobrano calosc kolecji ksiazek");
                        break;
                    }
                case 4:
                    {
                        WriteLine("Zaktualizowano element kolekcji ksiazek");
                        break;
                    }
                case 5:
                    {
                        WriteLine("Usunieto element z kolekcji ksiazek");
                        break;
                    }
                default:
                    {
                        WriteLine("Unknown event code");
                        break;
                    }
            }

        }
        public void OnEgzemplarzeChange(Object o, EventArgs e)
        {
            switch (dr.EgzemplarzeEvent)
            {
                case 1:
                    {
                        WriteLine("Dodano element do kolekcji egzemplarzy");
                        break;
                    }
                case 2:
                    {
                        WriteLine("Pobrano element z kolekcji egzemplarzy");
                        break;
                    }
                case 3:
                    {
                        WriteLine("Pobrano calosc kolecji egzemplarzy");
                        break;
                    }
                case 4:
                    {
                        WriteLine("Zaktualizowano element kolekcji egzemplarzy");
                        break;
                    }
                case 5:
                    {
                        WriteLine("Usunieto element z kolekcji egzemplarzy");
                        break;
                    }
                default:
                    {
                        WriteLine("Unknown event code");
                        break;
                    }
            }

        }
        #endregion

        //METODY ZAIMPLEMENTOWANE W DATASERVICE
        public void DrukujWszystko(List<Czytelnik> container)
        {
            foreach (Czytelnik c in container)
                WriteLine($"Id czytelnika:  {c.IdCzytelnika}\nImie:    {c.Imie}\nNazwisko:   {c.Nazwisko}\n\n");
        }
        public void DrukujWszystkoPowiazane(List<Czytelnik> container)
        {
            foreach (Czytelnik c in container)
            {
                WriteLine($"Id czytelnika:  {c.IdCzytelnika}\nImie:    {c.Imie}\nNazwisko:   {c.Nazwisko}\n\n");
                foreach (Wypozyczenie w in dr.PobierzWypozyczenia())
                    if (w.Czytelnik == c)
                    {
                        WriteLine($"ID wypozyczenia:   {w.IdWypozyczenia}\nID egzemplarza:   " +
                        $"{w.EgzemplarzKsiazki.IdEgzemplarza}\nID czytelnika:    {w.Czytelnik.IdCzytelnika}\nOd kiedy:   " +
                        $"{w.OdKiedy.ToShortDateString()}\nDo kiedy:    {w.DoKiedy.ToShortDateString()}\n\n ");
                        EgzemplarzKsiazki e = dr.PobierzEgzemplarze().Find(p => p.IdEgzemplarza == w.EgzemplarzKsiazki.IdEgzemplarza);
                        WriteLine($"ID egzemplarza:   {e.IdEgzemplarza}\nID ksiazki:    {e.Ksiazka.IdKsiazki}\nOpis ksiazki:   {e.OpisKsiazki}\nData zakupu:    {e.DataZakupu.ToShortDateString()}\n\n ");

                        var k = dr.PobierzKsiazki().First(p => e.Ksiazka.IdKsiazki == p.Value.IdKsiazki);
                        WriteLine($"ID klucza:   {k.Key}\nID ksiazki:    {k.Value.IdKsiazki}\nTytul ksiazki:   {k.Value.Tytul}\nAutorzy:");
                        int i = 1;
                        foreach (String s in k.Value.autorzy)
                        {
                            WriteLine($"{i}. {s}");
                            i++;
                        }
                        WriteLine();

                    }
            }
        }
        public void DrukujWszystko(List<EgzemplarzKsiazki> container)
        {
            foreach (EgzemplarzKsiazki e in container)
                WriteLine($"ID egzemplarza:   {e.IdEgzemplarza}\nID ksiazki:    {e.Ksiazka.IdKsiazki}\nOpis ksiazki:   {e.OpisKsiazki}\nData zakupu:    {e.DataZakupu.ToShortDateString()}\n\n ");
        }

        public void DrukujWszystko(Dictionary<int, Ksiazka> container)
        {
            foreach (var e in container)
            {
                WriteLine($"ID klucza:   {e.Key}\nID ksiazki:    {e.Value.IdKsiazki}\nTytul ksiazki:   {e.Value.Tytul}\nAutorzy:");
                int i = 1;
                foreach (String s in e.Value.autorzy)
                {
                    WriteLine($"{i}. {s}");
                    i++;
                }
                WriteLine();
                WriteLine();
            }
        }

        public void DrukujWszystko(ObservableCollection<Wypozyczenie> container)
        {
            foreach (Wypozyczenie w in container)
                WriteLine($"ID wypozyczenia:   {w.IdWypozyczenia}\nID egzemplarza:   " +
                    $"{w.EgzemplarzKsiazki.IdEgzemplarza}\nID czytelnika:    {w.Czytelnik.IdCzytelnika}\nOd kiedy:   " +
                    $"{w.OdKiedy.ToShortDateString()}\nDo kiedy:    {w.DoKiedy.ToShortDateString()}\n\n ");
        }

        public List<Czytelnik> FiltrujCzytelnikow(Predicate<Czytelnik> predicate)
        {
            return dr.PobierzCzytelnikow().FindAll(predicate);
        }

        public List<EgzemplarzKsiazki> FiltrujEgzemplarz(Predicate<EgzemplarzKsiazki> predicate)
        {
            return dr.PobierzEgzemplarze().FindAll(predicate);
        }

        public ObservableCollection<Wypozyczenie> FiltrujWypozyczenia(Func<Wypozyczenie, bool> predicate)
        {
            var filtered = dr.PobierzWypozyczenia().Where(predicate);
            return new ObservableCollection<Wypozyczenie>(filtered);
        }
        public Dictionary<int, Ksiazka> FiltrujKsiazki(Func<KeyValuePair<int, Ksiazka>, bool> predicate)
        {
            var toReturn = dr.PobierzKsiazki().Where(predicate);
            return toReturn.ToDictionary(p => p.Key, p => p.Value);

        }
        //METODY ZAIMPLEMENTOWANE W DATAREPOSITORY
        ////////////////////
        #region Czytelnik
        public void DodajCzytelnika(Czytelnik czytelnik) => dr.DodajCzytelnika(czytelnik);

        public Czytelnik PobierzCzytelnika(int id) => dr.PobierzCzytelnika(id);

        public List<Czytelnik> PobierzCzytelnikow() => dr.PobierzCzytelnikow();

        public void UaktualnijCzytelnika(int id, params string[] args) => dr.UaktualnijCzytelnika(id, args);
        public void UsunCzytelnika(int idCzytelnika) => dr.UsunCzytelnika(idCzytelnika);
        #endregion
        ////////////////////
        #region Ksiazka
        public void DodajKsiazke(int value, Ksiazka ksiazka) => dr.DodajKsiazke(value, ksiazka);

        public Ksiazka PobierzKsiazke(int key) => dr.PobierzKsiazke(key);
        public Dictionary<int, Ksiazka> PobierzKsiazki() => dr.PobierzKsiazki();

        public void UaktualnijKsiazke(int id, params string[] args) => dr.UaktualnijKsiazke(id, args);
        public void UsunKsiazke(int idKsiazki) => dr.UaktualnijKsiazke(idKsiazki);

        #endregion
        ////////////////////
        #region Egzemplarze
        public void DodajEgzemplarz(EgzemplarzKsiazki egzemplarz) => dr.DodajEgzemplarz(egzemplarz);

        public EgzemplarzKsiazki PobierzEgzemplarz(int id) => dr.PobierzEgzemplarz(id);
        public List<EgzemplarzKsiazki> PobierzEgzemplarze() => dr.PobierzEgzemplarze();

        public void UaktualnijEgzemplarz(int idEgzemplarza, Ksiazka newKsiazka) => dr.UaktualnijEgzemplarz(idEgzemplarza, newKsiazka);

        public void UaktualnijEgzemplarz(int idEgzemplarza, string newOpis) => dr.UaktualnijEgzemplarz(idEgzemplarza, newOpis);

        public void UaktualnijEgzemplarz(int idEgzemplarza, DateTime newDataZakupu) => dr.UaktualnijEgzemplarz(idEgzemplarza, newDataZakupu);
        public void UsunEgzemplarz(int idEgzemplarza) => dr.UsunEgzemplarz(idEgzemplarza);

        #endregion
        ////////////////////
        #region Wypozyczenia
        public void DodajWypozycznie(Wypozyczenie wypozyczenie) => dr.DodajWypozycznie(wypozyczenie);
        public Wypozyczenie PobierzWypozyczenie(int id) => dr.PobierzWypozyczenie(id);
        public ObservableCollection<Wypozyczenie> PobierzWypozyczenia() => dr.PobierzWypozyczenia();

        public void UaktualnijWypozyczenie(int idWypozyczenia, Czytelnik nowyCzytelnik) => dr.UaktualnijWypozyczenie(idWypozyczenia, nowyCzytelnik);
        public void UaktualnijWypozyczenie(int idWypozyczenia, EgzemplarzKsiazki nowyEgzemplarzKsiazki) => dr.UaktualnijWypozyczenie(idWypozyczenia,nowyEgzemplarzKsiazki);

        public void UaktualnijWypozyczenie(int idWypozyczenia, params DateTime[] args) => dr.UaktualnijWypozyczenie(idWypozyczenia, args);
        public void UsunWypozyczenie(int idWypozyczenia) => dr.UsunWypozyczenie(idWypozyczenia);
        #endregion
        ////////////////////
    }

    
}
