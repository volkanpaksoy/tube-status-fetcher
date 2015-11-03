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
        public void DisplayTubeStatus(List<LineInfo> lineInfoList)
        {
            System.Console.ResetColor();
            System.Console.Clear();
            System.Console.WriteLine($"Displaying tube status retrieved at: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            System.Console.WriteLine("Line                Status                 Reason");
            System.Console.WriteLine("====                =============          ======");
            lineInfoList.ForEach(l => PrintLineInfo(new ConsoleLineInfoDecorator(l)));

            System.Console.WriteLine();
            System.Console.WriteLine("Press F5 to refresh the results, Q to quit");
        }

        public void PrintLineInfo(ConsoleLineInfoDecorator line)
        {
            System.Console.BackgroundColor = line.BackColour;
            System.Console.ForegroundColor = line.ForeColour;
            System.Console.Write($"{line.LineInfo.Name.PadRight(20, ' ')}");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"{line.LineInfo.StatusSeverityDescription}[Code: {line.LineInfo.StatusSeverity}]");
            System.Console.Write("          ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"{line.LineInfo.Reason}");
            System.Console.WriteLine();
        }
    }
}
