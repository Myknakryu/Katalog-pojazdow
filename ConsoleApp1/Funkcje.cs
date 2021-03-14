using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogSamochodowy
{
    class Funkcje
    {
        public static void GenerujMenu()
        {
            String[] opcje = { "Wczytanie z katalogu", "Zapis katalogu z pliku", "Wprowadzanie nowego samochodu",
                "Wyswietlenie listy pojazdow", "Wyswietlenie warunkowe", "Wyswietlenie pojedynczego samochodu", "Sortowanie", 
                "Usuniecie z katalogu", "Wyjscie"};
            int i = 1;
            foreach(var opcja in opcje)
            {
                Console.WriteLine("{0} - {1}", i++, opcja);
            }
        }
    }
}
