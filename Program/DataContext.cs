using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Program
{
    public class DataContext
    {
        public List<Czytelnik> czytelnicy = new List<Czytelnik>();
        public Dictionary<int, Ksiazka> ksiazki = new Dictionary<int, Ksiazka>();
        public List<EgzemplarzKsiazki> egzemplarzeKsiazek = new List<EgzemplarzKsiazki>();
        public ObservableCollection<Wypozyczenie> wypozyczenia = new ObservableCollection<Wypozyczenie>();
    }

    
}
