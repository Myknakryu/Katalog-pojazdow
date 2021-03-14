using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KatalogSamochodowy
{
    class OperacjePlikowe
    {
        public static void ZapisDoPliku(List<Pojazd> obiekt)
        {
            using (Stream stream = File.Open("plik.bin", FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obiekt);
            }
        }

        public static List<Pojazd> WczytajPlik()
        {
            using (Stream stream = File.Open("plik.bin", FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (List<Pojazd>)binaryFormatter.Deserialize(stream);
            }
        }

    }
}
