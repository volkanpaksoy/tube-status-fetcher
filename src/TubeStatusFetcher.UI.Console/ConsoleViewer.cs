using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.Console
{
    public class ConsoleViewer
    {
        private Dictionary<string, ConsoleColor> _tubeBGColourDictionary;
        private Dictionary<string, ConsoleColor> _tubeFGColourDictionary;

        public ConsoleViewer()
        {
            InitColours();
        }

        private void InitColours()
        {
            _tubeBGColourDictionary = new Dictionary<string, ConsoleColor>();
            _tubeBGColourDictionary.Add("bakerloo", ConsoleColor.DarkYellow);
            _tubeBGColourDictionary.Add("central", ConsoleColor.Red);
            _tubeBGColourDictionary.Add("circle", ConsoleColor.Yellow);
            _tubeBGColourDictionary.Add("district", ConsoleColor.Green);
            _tubeBGColourDictionary.Add("hammersmith-city", ConsoleColor.Magenta);
            _tubeBGColourDictionary.Add("jubilee", ConsoleColor.Gray);
            _tubeBGColourDictionary.Add("metropolitan", ConsoleColor.DarkMagenta);
            _tubeBGColourDictionary.Add("northern", ConsoleColor.Black);
            _tubeBGColourDictionary.Add("piccadilly", ConsoleColor.DarkBlue);
            _tubeBGColourDictionary.Add("victoria", ConsoleColor.Blue);
            _tubeBGColourDictionary.Add("waterloo-city", ConsoleColor.DarkCyan);

            _tubeFGColourDictionary = new Dictionary<string, ConsoleColor>();
            _tubeFGColourDictionary.Add("bakerloo", ConsoleColor.White);
            _tubeFGColourDictionary.Add("central", ConsoleColor.White);
            _tubeFGColourDictionary.Add("circle", ConsoleColor.Black);
            _tubeFGColourDictionary.Add("district", ConsoleColor.White);
            _tubeFGColourDictionary.Add("hammersmith-city", ConsoleColor.Black);
            _tubeFGColourDictionary.Add("jubilee", ConsoleColor.White);
            _tubeFGColourDictionary.Add("metropolitan", ConsoleColor.White);
            _tubeFGColourDictionary.Add("northern", ConsoleColor.White);
            _tubeFGColourDictionary.Add("piccadilly", ConsoleColor.White);
            _tubeFGColourDictionary.Add("victoria", ConsoleColor.Black);
            _tubeFGColourDictionary.Add("waterloo-city", ConsoleColor.Black);
        }

        public void DisplayTubeStatus(List<LineInfo> lineInfoList)
        {
            System.Console.ResetColor();
            System.Console.Clear();
            System.Console.WriteLine($"Displaying tube status retrieved at: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            System.Console.WriteLine("Line                Status                 Reason");
            System.Console.WriteLine("====                =============          ======");
            lineInfoList.ForEach(l => PrintLineInfo(l));

            System.Console.WriteLine();
            System.Console.WriteLine("Press F5 to refresh the results, Q to quit");
        }

        public void PrintLineInfo(LineInfo line)
        {
            System.Console.BackgroundColor = _tubeBGColourDictionary[line.Id];
            System.Console.ForegroundColor = _tubeFGColourDictionary[line.Id];
            System.Console.Write($"{line.Name.PadRight(20, ' ')}");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"{line.StatusSeverityDescription}[Code: {line.StatusSeverity}]");
            System.Console.Write("          ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"{line.Reason}");
            System.Console.WriteLine();
        }
    }
}
