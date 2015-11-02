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
        private Dictionary<string, ConsoleColor> _tubeColourDictionary;

        public ConsoleViewer()
        {
            InitColours();
        }

        private void InitColours()
        {
            _tubeColourDictionary = new Dictionary<string, ConsoleColor>();
            _tubeColourDictionary.Add("bakerloo", ConsoleColor.DarkYellow);
            _tubeColourDictionary.Add("central", ConsoleColor.Red);
            _tubeColourDictionary.Add("circle", ConsoleColor.Yellow);
            _tubeColourDictionary.Add("district", ConsoleColor.Green);
            _tubeColourDictionary.Add("hammersmith-city", ConsoleColor.Magenta);
            _tubeColourDictionary.Add("jubilee", ConsoleColor.Gray);
            _tubeColourDictionary.Add("metropolitan", ConsoleColor.DarkMagenta);
            _tubeColourDictionary.Add("northern", ConsoleColor.Black);
            _tubeColourDictionary.Add("piccadilly", ConsoleColor.DarkBlue);
            _tubeColourDictionary.Add("victoria", ConsoleColor.Blue);
            _tubeColourDictionary.Add("waterloo-city", ConsoleColor.DarkCyan);
        }

        public void DisplayTubeStatus(List<LineInfo> lineInfoList)
        {
            System.Console.ResetColor();
            System.Console.Clear();
            System.Console.WriteLine($"Displaying tube status retrieved at: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            System.Console.WriteLine("Line                Status                 Reason");
            System.Console.WriteLine("====                =============          ======");
            lineInfoList.ForEach(l => PrintLineInfo(l));
        }

        public void PrintLineInfo(LineInfo line)
        {
            System.Console.ForegroundColor = _tubeColourDictionary[line.Id];
            System.Console.Write($"{line.Name.PadRight(20, ' ')}");
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($"{line.StatusSeverityDescription}[Code: {line.StatusSeverity}]");
            System.Console.Write("          ");
            System.Console.Write($"{line.Reason}");
            System.Console.WriteLine();
        }
    }
}
