using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeStatusFetcher.Core
{
    public class Fetcher
    {
        private readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube/status?detail=true";
        private Dictionary<string, CMYK> _tubeColorDictionary;
        private Dictionary<string, ConsoleColor> _tubeConsoleColorDictionary;
        private Dictionary<int, string> _severityDescriptionMap;

        public void GetTubeInfo()
        {
            InitTubeColors();
            InitConsoleColors();

            var tflResponse = GetData();

            DisplayTubeStatus(tflResponse);

            Console.ReadLine();
        }

        private void InitTubeColors()
        {
            _tubeColorDictionary = new Dictionary<string, CMYK>();
            string json = File.ReadAllText("./data/colours.json");
            var tubeColors = JArray.Parse(json);
            foreach (var tubeColor in tubeColors)
            {
                var colour = new CMYK(
                    tubeColor["colour"]["C"]?.Value<double>() ?? 0.0,
                    tubeColor["colour"]["M"]?.Value<double>() ?? 0.0,
                    tubeColor["colour"]["Y"]?.Value<double>() ?? 0.0,
                    tubeColor["colour"]["K"]?.Value<double>() ?? 0.0);

                _tubeColorDictionary.Add(tubeColor["id"].Value<string>(), colour);
            }
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

        private List<LineInfo> GetData()
        {
            var client = new RestClient(_apiEndPoint);
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var tflResponse = JsonConvert.DeserializeObject<List<TflLineInfo>>(content);

            var lineInfoList = tflResponse.Select(t =>
                new LineInfo()
                {
                    Id = t.id,
                    Name = t.name,
                    Reason = t.lineStatuses[0].reason,
                    StatusSeverityDescription = t.lineStatuses[0].statusSeverityDescription,
                    StatusSeverity = t.lineStatuses[0].statusSeverity
                }).ToList();

            return lineInfoList;
        }

        private void DisplayTubeStatus(List<LineInfo> lineInfoList)
        {
            Console.WriteLine("Line                Status                 Reason");
            Console.WriteLine("====                =============          ======");
            lineInfoList.ForEach(l => PrintLineInfo(l));
        }

        public void PrintLineInfo(LineInfo line)
        {
            // Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = _tubeConsoleColorDictionary[line.Id];
            Console.Write($"{line.Name.PadRight(20, ' ')}");

            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{line.StatusSeverityDescription}[Code: {line.StatusSeverity}]");
            Console.Write("          ");
            Console.Write($"{line.Reason}");
            Console.WriteLine();
        }
    }
}
