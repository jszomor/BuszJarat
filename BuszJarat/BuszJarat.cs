using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuszJarat
{
  class BuszJarat
  {
    public struct Entries
    {
      public int Id;
      public string MegalloNeve;
      public int Tavolsag;
    }
    public int Pozicio = 0;
    public string startDate;
    public Entries[] getEntries = new Entries[100];
    public int Counter = 1;
    public double megtettUt;

    public BuszJarat(string file)
    {
      StreamReader fileReader = new StreamReader(file);
      string sor;
      string[] adatok;
      startDate = fileReader.ReadLine();
      while ((sor = fileReader.ReadLine()) != null)
      {
        adatok = sor.Split('\t');
        if (adatok.Length != 3) continue;

        getEntries[Counter].Id = int.Parse(adatok[0]);
        getEntries[Counter].MegalloNeve = adatok[1];
        getEntries[Counter].Tavolsag = int.Parse(adatok[2]);
        Counter++;
      }
    }
    public void Print()
    {
      Console.WriteLine();
      Console.WriteLine("Sorszám   Buszmegálló     Távolság(Km)");
      for (int i = 1; i < Counter; i++)
      {
        Console.WriteLine("{0,3} {1,-20} {2,3}", getEntries[i].Id, getEntries[i].MegalloNeve, getEntries[i].Tavolsag);
      }
      Console.WriteLine();
      Console.WriteLine($"A busz ezen megállók között tartozkodik: {getEntries[Pozicio-1].MegalloNeve} - {getEntries[Pozicio].MegalloNeve}");
    }
    public TimeSpan TimeInterval(string arrival)
    {
      DateTime dateFromString = DateTime.Parse(startDate, System.Globalization.CultureInfo.InvariantCulture);
      DateTime arrivalDate = DateTime.Parse(arrival, System.Globalization.CultureInfo.InvariantCulture);
      TimeSpan travelTime = arrivalDate - dateFromString;
      return travelTime;
    }
    public double DistanceCalculator(TimeSpan menetido, double sebesseg)
    {
      megtettUt = sebesseg * 1000 / 60 * menetido.TotalMinutes;
      return megtettUt;
    }
    public void BuszPozicio()
    {
      bool megMegy = true;
      double megtettKm = megtettUt / 1000;
      while (megMegy)
      {
        for (int i = 1; i < Counter; i++)
        {
          if (megtettKm >= 0)
            megtettKm -= getEntries[i].Tavolsag;

          else
          {
            Pozicio = i;
            megMegy = false;
            break;
          }
        }
        for (int i = Counter-1; i > 1; i--)
        {
          if (megtettKm >= 0)
            megtettKm -= getEntries[i].Tavolsag;

          else
          {
            Pozicio = i;
            megMegy = false;
            break;
          }
        }
      }
    }
  }
}
