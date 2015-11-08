using System;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fetcher = new Fetcher();
            var viewer = new ConsoleViewer();

            bool exit = false;

            viewer.DisplayTubeStatus(fetcher.GetTubeInfo());

            do
            {
                ConsoleKeyInfo key = System.Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F5:
                        viewer.DisplayTubeStatus(fetcher.GetTubeInfo());
                        break;
                    case ConsoleKey.Q:
                        exit = true;
                        break;
                    default:
                        System.Console.WriteLine("Unknown command");
                        break;
                }
            }
            while (!exit);
        }
    }
}
