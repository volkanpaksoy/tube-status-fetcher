using System;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fetcher = new Fetcher();
            var viewer = new Viewer();

            do
            {
                viewer.DisplayTubeStatus(fetcher.GetTubeInfo());
                System.Console.WriteLine("Press F5 to refresh the results, Q to quit");
            }
            while (System.Console.ReadKey().Key == ConsoleKey.F5);
        }
    }
}
