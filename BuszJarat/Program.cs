using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuszJarat
{
  class Program
  {
    static void Main(string[] args)
    {
      string file = "21esBusz.txt";
      BuszJarat buszJarat = new BuszJarat(file);
      Console.WriteLine("A program a busz indulási idejétől a felhasználó által megadott \n ideig eltelt idő alatt megtett helyét számolja ki a busznak.");
      Console.WriteLine();
      Console.WriteLine($"A busz indulási indőpontja: {buszJarat.startDate}");
      Console.WriteLine("Adja meg a vizsgálni kívánt időpontot. Érvényes formátum:hónap.nap.év óra:perc:másodperc AM vagy PM");
      string vizsgaltIdopont = Console.ReadLine();
      TimeSpan menetido = buszJarat.TimeInterval(vizsgaltIdopont);
      Console.WriteLine($"Az eddig eltelt menetidő: {menetido}");
      Console.WriteLine("Adja meg a busz átlagos sebességét (Km/h)");
      double sebesseg = int.Parse(Console.ReadLine());
      Console.WriteLine($"Megtett út méterben: {buszJarat.DistanceCalculator(menetido, sebesseg)}m");
      Console.WriteLine($"Megtett út kilóméterben: {(buszJarat.DistanceCalculator(menetido, sebesseg))/1000}km");
      buszJarat.BuszPozicio();
      buszJarat.PrintMegallo();
      Console.WriteLine("Megállók:");
      buszJarat.Print();
      Console.WriteLine();
      string programResz = "A most következő programrész a felhasználó által megadott megálló \n alapján kiszámolja hogy mikor lesz a legközelebb" +
        "a busz abban a megállóban";
      Console.WriteLine(programResz);
      int sorszam;
      bool isValid = false;
      while(isValid == false)
      {
        Console.WriteLine("Kérem adja meg a megálló sorszámát.");
        sorszam = Convert.ToInt32(Console.ReadLine());
        if (buszJarat.Counter <= sorszam)
        {
          Console.Clear();
          Console.WriteLine("A megadott megálló nem létezik, kérem adjon meg érvényes számot.");
          Console.WriteLine();
          Console.WriteLine(programResz);
          Console.WriteLine();
          Console.WriteLine($"A busz indulási indőpontja: {buszJarat.startDate}");
          Console.WriteLine();
          buszJarat.Print();
        }
        else
        {
          DateTime erkezesiIDo = buszJarat.BusStopTime(sorszam, sebesseg);
          Console.WriteLine($"{buszJarat[sorszam]} nevű megállóban legközelebb a busz ekkor lesz: {erkezesiIDo}");
          isValid = true;
        }
      }
      Console.WriteLine("Vége a programnak, viszlát");
      Console.ReadKey();
    }
  }
}
 