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
      buszJarat.Print();
      //buszJarat.TimeInterval();
      Console.ReadKey();
    }
  }
}
