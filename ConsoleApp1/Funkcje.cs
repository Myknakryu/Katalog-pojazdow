using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KatalogSamochodowy
{
    class Funkcje
    {
        public static int CzytajLiczbe(int max = Int32.MaxValue, int min = Int32.MinValue)
        {
            try
            {
                int liczba = Int32.Parse(Console.ReadLine());
                if (liczba >= min && liczba <= max)
                    return liczba;
                else return min;
            }
            catch(System.FormatException e)
            {
                return 0;
            }
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

        public static void WyswietlanieWarunkowe(List<Pojazd> katalog)
        {
            PropertyInfo Parametr = typeof(Pojazd).GetProperty(Pojazd.skladowe[4]);
            foreach(var Pojazd in (from el in katalog where (int)Parametr.GetValue(el) < 100000 select el).ToList()) {
                Pojazd.Wypisz();
            }
        }

        public static List<Pojazd> Sortowanie(List<Pojazd> katalog,int skladowa)
        {
            PropertyInfo Parametr = typeof(Pojazd).GetProperty(Pojazd.skladowe[skladowa]);
            List<Pojazd> nowyKatalog = katalog.OrderBy(x => Parametr.GetValue(x, null)).ToList();
            return nowyKatalog;
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
                            Katalog = OperacjePlikowe.WczytajPlik();
                            break;
                        }
                    case 2:
                        {
                            OperacjePlikowe.ZapisDoPliku(Katalog);
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
                            WyswietlanieWarunkowe(Katalog);
                            break;
                        }
                    case 6:
                        {
                            Katalog[WyborElementu(Katalog, "Podaj element do wyswietlenia")].Wypisz();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Podaj wzgledem ktorej danej chcesz sortowac");
                            int i = 0;
                            foreach (var el in Pojazd.skladowe)
                                Console.WriteLine("{0}. {1}", i++, el);
                            Katalog = Sortowanie(Katalog, CzytajLiczbe(0,Pojazd.skladowe.Length-1));
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
