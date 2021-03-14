using System;
using System.Collections.Generic;

namespace KatalogSamochodowy
{
    class Funkcje
    {
        public static int CzytajLiczbe()
        {
            return Int32.Parse(Console.ReadLine());
        }

        public static int WyborElementu(List<Pojazd> katalog, String wiadomosc = "Wybierz element")
        {
            int opcja, rozmiar = katalog.Count;
            while (true)
            {
                Console.WriteLine("{0}\n Podaj wartosc od 1 do {1}", wiadomosc, rozmiar);
                opcja = CzytajLiczbe();
                if(opcja > 0 && opcja <=rozmiar)
                    return opcja-1;
            }
        }

        public static void WyswietlKatalog(List<Pojazd> katalog)
        {
            Console.WriteLine("\n");
            int i = 1;
            foreach(var pojazd in katalog)
            {
                Console.Write(i++ + ". ");
                pojazd.Wypisz();
            }
        }

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

        public static void ObslugaMenu()
        {
            List<Pojazd> Katalog = new List<Pojazd>();
            while (true)
            {
                GenerujMenu();
                int opcja = CzytajLiczbe();
                switch (opcja)
                {
                    case 1:
                        {
                            
                            break;
                        }
                    case 2:
                        {

                            break;
                        }
                    case 3:
                        {
                            Pojazd samochod = Pojazd.WprowadzPojazd();
                            Katalog.Add(samochod);
                            break;
                        }
                    case 4:
                        {
                            WyswietlKatalog(Katalog);
                            break;
                        }
                    case 5:
                        {

                            break;
                        }
                    case 6:
                        {
                            Katalog[WyborElementu(Katalog, "Podaj element do wyswietlenia")].Wypisz();
                            break;
                        }
                    case 7:
                        {

                            break;
                        }
                    case 8:
                        {
                            Katalog.RemoveAt(WyborElementu(Katalog, "Podaj element do usuniecia"));
                            break;
                        }
                    case 9:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
                Console.WriteLine("Nacisnij aby kontynuowac");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
