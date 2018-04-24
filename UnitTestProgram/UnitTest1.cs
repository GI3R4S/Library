using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Program.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void DodajCzytelnikaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.czytelnicy.Count;
            dr.DodajCzytelnika(new Czytelnik(5, "Andrzej", "D"));
            Assert.AreEqual(test + 1, dr.Kontener.czytelnicy.Count);
        }

        [TestMethod()]
        public void PobierzCzytelnikaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            Czytelnik c = dr.PobierzCzytelnika(1);
            Assert.AreEqual(1, c.IdCzytelnika);
        }

        [TestMethod()]
        public void PobierzCzytelnikowTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            var test = dr.PobierzCzytelnikow();
            Assert.AreEqual(test.Count, dr.Kontener.czytelnicy.Count);

        }

        [TestMethod()]
        public void UaktualnijCzytelnikaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijCzytelnika(1, "Janusz", "Jakis");
            Assert.IsTrue(dr.PobierzCzytelnika(1).Imie.Equals("Janusz"));
            Assert.IsTrue(dr.PobierzCzytelnika(1).Nazwisko.Equals("Jakis"));
            dr.UaktualnijCzytelnika(1, "Jakis");
            Assert.IsTrue(dr.PobierzCzytelnika(1).Imie.Equals("Jakis"));
            Assert.IsTrue(dr.PobierzCzytelnika(1).Nazwisko.Equals("Jakis"));
        }

        [TestMethod()]
        public void UsunCzytelnikaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.czytelnicy.Count;
            System.Console.WriteLine(test);
            dr.UsunCzytelnika(4);
            Assert.AreEqual(test - 1, dr.Kontener.czytelnicy.Count);
        }

        [TestMethod()]
        public void DodajKsiazkeTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.ksiazki.Count;
            dr.DodajKsiazke(4, new Ksiazka(4, "Lalka", new System.Collections.ArrayList { "Bolesław Prus" }));
            Assert.AreEqual(test + 1, dr.Kontener.ksiazki.Count);
        }

        [TestMethod()]
        public void PobierzKsiazkeTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            Ksiazka k = dr.PobierzKsiazke(1);
            Assert.AreEqual(1, k.IdKsiazki);
        }

        [TestMethod()]
        public void PobierzKsiazkiTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            var test = dr.PobierzKsiazki();
            Assert.AreEqual(test.Count, dr.Kontener.ksiazki.Count);
        }

        [TestMethod()]
        public void UaktualnijKsiazkeTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.PobierzKsiazke(1).autorzy.Count;
            dr.UaktualnijKsiazke(1, "Ja", "Ty");
            Assert.AreEqual(test + 2, dr.PobierzKsiazke(1).autorzy.Count);
        }

        [TestMethod()]
        public void UsunKsiazkeTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.ksiazki.Count;
            dr.UsunKsiazke(1);
            Assert.AreEqual(test - 1, dr.Kontener.ksiazki.Count);
        }

        [TestMethod()]
        public void DodajEgzemplarzTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.egzemplarzeKsiazek.Count;
            dr.DodajEgzemplarz(new EgzemplarzKsiazki(dr.PobierzKsiazke(1), 5, "Brak danych", new DateTime(2010, 10, 10)));
            Assert.AreEqual(test + 1, dr.Kontener.egzemplarzeKsiazek.Count);
        }

        [TestMethod()]
        public void PobierzEgzemplarzTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            EgzemplarzKsiazki e = dr.PobierzEgzemplarz(1);
            Assert.AreEqual(1, e.IdEgzemplarza);
        }

        [TestMethod()]
        public void PobierzEgzemplarzeTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            var test = dr.PobierzEgzemplarze();
            Assert.AreEqual(test.Count, dr.Kontener.egzemplarzeKsiazek.Count);
        }

        [TestMethod()]
        public void UaktualnijEgzemplarzTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijEgzemplarz(1, new DateTime(1999, 10, 10));
            Assert.IsTrue(dr.PobierzEgzemplarz(1).DataZakupu.Equals(new DateTime(1999, 10, 10)));
        }

        [TestMethod()]
        public void UaktualnijEgzemplarzTest1()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijEgzemplarz(1, dr.PobierzKsiazke(2));
            Assert.AreEqual(dr.PobierzEgzemplarz(1).Ksiazka.IdKsiazki, 2);
        }

        [TestMethod()]
        public void UaktualnijEgzemplarzTest2()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijEgzemplarz(1, "Probny opis");
            Assert.IsTrue(dr.PobierzEgzemplarz(1).OpisKsiazki.Equals("Probny opis"));

        }

        [TestMethod()]
        public void UsunEgzemplarzTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.egzemplarzeKsiazek.Count;
            dr.UsunEgzemplarz(4);
            Assert.AreEqual(test - 1, dr.Kontener.egzemplarzeKsiazek.Count);
        }

        [TestMethod()]
        public void DodajWypozycznieTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.wypozyczenia.Count;
            dr.DodajWypozycznie(new Wypozyczenie(5, dr.PobierzCzytelnika(4), dr.PobierzEgzemplarz(4), DateTime.Now, DateTime.Now.AddDays(7)));
            Assert.AreEqual(test + 1, dr.Kontener.wypozyczenia.Count);
        }

        [TestMethod()]
        public void PobierzWypozycznieTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            Wypozyczenie w = dr.PobierzWypozyczenie(1);
            Assert.AreEqual(1, w.IdWypozyczenia);
        }

        [TestMethod()]
        public void PobierzWypozyczeniaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            var test = dr.PobierzWypozyczenia();
            Assert.AreEqual(test.Count, dr.Kontener.wypozyczenia.Count);
        }

        [TestMethod()]
        public void UaktualnijWypozyczeniaTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijWypozyczenie(1, new DateTime(2222, 2, 22), new DateTime(2222, 2, 25));
            Assert.IsTrue(dr.PobierzWypozyczenie(1).OdKiedy.Equals(new DateTime(2222, 2, 22)));
            Assert.IsTrue(dr.PobierzWypozyczenie(1).DoKiedy.Equals(new DateTime(2222, 2, 25)));


        }

        [TestMethod()]
        public void UaktualnijWypozyczeniaTest1()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijWypozyczenie(1, dr.PobierzEgzemplarz(4));
            Assert.AreEqual(dr.PobierzWypozyczenie(1).EgzemplarzKsiazki.IdEgzemplarza, 4);
        }
        [TestMethod()]
        public void UaktualnijWypozyczeniaTestZmianyCzytelnika()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            dr.UaktualnijWypozyczenie(1, dr.PobierzCzytelnika(3));
            Assert.AreEqual(dr.PobierzWypozyczenie(1).Czytelnik.IdCzytelnika, 3);
        }
        [TestMethod()]
        public void UsunWypozyczenieTest()
        {
            DataRepository dr = new DataRepository(new WypelnijStalymi());
            int test = dr.Kontener.wypozyczenia.Count;
            dr.UsunWypozyczenie(4);
            Assert.AreEqual(test - 1, dr.Kontener.wypozyczenia.Count);
        }

        [TestMethod()]
        public void GenerujLancuchTest()
        {
            WypelnijLosowymi wl = new WypelnijLosowymi(10,10,10,10);
            int requiredLenghth = 10;
            string test = wl.GenerujLancuch(10);
            Assert.IsTrue(test.Length == requiredLenghth);
        }

        [TestMethod()]
        public void WypelnijLosowymiTest()
        {
            int requiredAmountWypozyczenia = 5;
            int requiredAmountCzytelnicy = 10;
            int requiredAmountEgzemplarze = 7;
            int requiredAmountKsiazki = 12;
            WypelnijLosowymi wl = new WypelnijLosowymi(requiredAmountCzytelnicy, requiredAmountKsiazki, requiredAmountEgzemplarze, requiredAmountWypozyczenia);

            Assert.IsTrue(wl.DC.czytelnicy.Count == requiredAmountCzytelnicy);
            Assert.IsTrue(wl.DC.egzemplarzeKsiazek.Count == requiredAmountEgzemplarze);
            Assert.IsTrue(wl.DC.ksiazki.Count == requiredAmountKsiazki);
            Assert.IsTrue(wl.DC.wypozyczenia.Count == requiredAmountWypozyczenia);
        }

    }
}
