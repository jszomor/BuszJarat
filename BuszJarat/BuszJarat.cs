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
    public string Pozicio;
    public string startDate;
    public Entries[] getEntries = new Entries[100];
    public int Counter = 1;

    public BuszJarat(string file)
    {
      StreamReader fileReader = new StreamReader(file);
      string sor;
      string[] adatok;
      //string startDate = File.ReadAllLines()
      //  fileReader.ReadLine()
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
      Console.WriteLine(startDate);
      for (int i = 0; i < Counter; i++)
      {
        Console.WriteLine("{0,3} {1,-20} {2,3}", getEntries[i].Id, getEntries[i].MegalloNeve, getEntries[i].Tavolsag);
      }
    }
    public void TimeInterval(string dateString)
    {
      //DateTime departure = new DateTime(start);
      dateString = "7/10/1974 7:10:24 AM";
      DateTime dateFromString = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
      Console.WriteLine(dateFromString.ToString());
      DateTime departure = new DateTime(2010, 6, 12, 18, 32, 0);
      DateTime arrival = new DateTime(2010, 6, 13, 22, 47, 0);
      TimeSpan travelTime = arrival - departure;
      Console.WriteLine("{0} - {1} = {2}", arrival, departure, travelTime);

      // The example displays the following output:
      //       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00
    }
  }
}
