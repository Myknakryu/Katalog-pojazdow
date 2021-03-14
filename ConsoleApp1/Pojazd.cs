using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogSamochodowy
{
    enum typ_skrzyni { manualna, automatyczna}
    class Pojazd
    {
        public String Marka { get; set; }
        public String Model { get; set; }

        public int Rocznik { get; set; }
        public int Pojemnosc { get; set; }
        public int Przebieg { get; set; }

        public typ_skrzyni Skrzynia { get; set; }

        public Pojazd(String Marka, String Model, int Rocznik, int Pojemnosc, int Przebieg, typ_skrzyni Skrzynia) {
            this.Marka = Marka;
            this.Model = Model;
            this.Rocznik = Rocznik;
            this.Pojemnosc = Pojemnosc;
            this.Przebieg = Przebieg;
            this.Skrzynia = Skrzynia;
        }
        public Pojazd() { }

        public static Pojazd WprowadzPojazd()
        {
            String[] Opcje = { "Podaj marke", "Podaj model", "Podaj rocznik", "Podaj pojemnosc (w cm^3)", "Podaj przebieg (w km)", "Podaj typ skrzyni\n 1- automatyczna by ustawic automatyczna" };
            int i = 0;
            Pojazd Samochod = new Pojazd();
            Console.WriteLine("{0}: ", Opcje[i++]);
            Samochod.Marka = Console.ReadLine();
            Console.WriteLine("{0}: ", Opcje[i++]);
            Samochod.Model = Console.ReadLine();
            Console.WriteLine("{0}: ", Opcje[i++]);
            Samochod.Rocznik = Funkcje.CzytajLiczbe();
            Console.WriteLine("{0}: ", Opcje[i++]);
            Samochod.Pojemnosc = Funkcje.CzytajLiczbe();
            Console.WriteLine("{0}: ", Opcje[i++]);
            Samochod.Przebieg = Funkcje.CzytajLiczbe();
            Console.WriteLine("{0}: ", Opcje[i]);
            Samochod.Skrzynia = (Funkcje.CzytajLiczbe()== 1?typ_skrzyni.automatyczna:typ_skrzyni.manualna);
            return Samochod;
        }

        public void Wypisz()
        {
            Console.WriteLine("{0} {1} - {2} - {3} cm^3 - {4} km - {5} ", Marka, Model, Rocznik, Pojemnosc, Przebieg, Skrzynia.ToString());
        }

        public static Boolean operator ~(Pojazd rhs)
        {
            if (rhs.Przebieg <= 10000)
                return true;
            return false;
        }
    }
}
