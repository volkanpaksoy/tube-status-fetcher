using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.Console
{
    public class Viewer
    {
        private Dictionary<string, ConsoleColor> _tubeConsoleColorDictionary;

        public Viewer()
        {
            InitConsoleColors();
        }

        private void InitConsoleColors()
        {
            _tubeConsoleColorDictionary = new Dictionary<string, ConsoleColor>();
            _tubeConsoleColorDictionary.Add("bakerloo", ConsoleColor.DarkYellow);
            _tubeConsoleColorDictionary.Add("central", ConsoleColor.Red);
            _tubeConsoleColorDictionary.Add("circle", ConsoleColor.Yellow);
            _tubeConsoleColorDictionary.Add("district", ConsoleColor.Green);
            _tubeConsoleColorDictionary.Add("hammersmith-city", ConsoleColor.Magenta);
            _tubeConsoleColorDictionary.Add("jubilee", ConsoleColor.Gray);
            _tubeConsoleColorDictionary.Add("metropolitan", ConsoleColor.DarkMagenta);
            _tubeConsoleColorDictionary.Add("northern", ConsoleColor.Black);
            _tubeConsoleColorDictionary.Add("piccadilly", ConsoleColor.DarkBlue);
            _tubeConsoleColorDictionary.Add("victoria", ConsoleColor.Blue);
            _tubeConsoleColorDictionary.Add("waterloo-city", ConsoleColor.DarkCyan);
        }

        public void DisplayTubeStatus(List<LineInfo> lineInfoList)
        {
            System.Console.Clear();
            System.Console.WriteLine("Line                Status                 Reason");
            System.Console.WriteLine("====                =============          ======");
            lineInfoList.ForEach(l => PrintLineInfo(l));
        }

        public void PrintLineInfo(LineInfo line)
        {
            // Console.BackgroundColor = ConsoleColor.White;
            System.Console.ForegroundColor = _tubeConsoleColorDictionary[line.Id];
            System.Console.Write($"{line.Name.PadRight(20, ' ')}");

            // Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($"{line.StatusSeverityDescription}[Code: {line.StatusSeverity}]");
            System.Console.Write("          ");
            System.Console.Write($"{line.Reason}");
            System.Console.WriteLine();
        }
    }
}
