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
