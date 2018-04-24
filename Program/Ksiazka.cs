using System.Collections;

namespace Program
{
    public class Ksiazka
    {
        public int IdKsiazki { get; set; }
        public string Tytul { get; set; }
        public ArrayList autorzy = new ArrayList();

        public Ksiazka(int newIDKsiazki, string newTytul, ArrayList newAutorzy)
        {
            IdKsiazki = newIDKsiazki;
            Tytul = newTytul;
            autorzy = newAutorzy;
        }
    }

    
}
