using System;

namespace KatalogSamochodowy
{
    class Program
    {
        private static void Main(String[] args)
        {
            Console.WriteLine("Test");
            Pojazd samochod = new Pojazd("Ford", "Focus", 2004, 1999, 20000, typ_skrzyni.automatyczna);
            samochod.Wypisz();
        }
    }
}
