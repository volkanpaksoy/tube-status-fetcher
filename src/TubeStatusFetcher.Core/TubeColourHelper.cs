using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeStatusFetcher.Core
{
    public class TubeColourHelper
    {
        private static Dictionary<string, CMYK> _tubeColorCMYKDictionary = new Dictionary<string, CMYK>();
        private static Dictionary<string, RGB> _tubeColorRGBDictionary = new Dictionary<string, RGB>();

        static TubeColourHelper()
        {
            _tubeColorCMYKDictionary = new Dictionary<string, CMYK>();
            _tubeColorRGBDictionary = new Dictionary<string, RGB>();

            string json = File.ReadAllText("./data/colours.json");
            var tubeColors = JArray.Parse(json);
            foreach (var tubeColor in tubeColors)
            {
                _tubeColorCMYKDictionary.Add(tubeColor["id"].Value<string>(), new CMYK(
                    tubeColor["CMYK"]["C"]?.Value<double>() ?? 0.0,
                    tubeColor["CMYK"]["M"]?.Value<double>() ?? 0.0,
                    tubeColor["CMYK"]["Y"]?.Value<double>() ?? 0.0,
                    tubeColor["CMYK"]["K"]?.Value<double>() ?? 0.0));

                _tubeColorRGBDictionary.Add(tubeColor["id"].Value<string>(), new RGB(
                    tubeColor["RGB"]["R"]?.Value<int>() ?? 0,
                    tubeColor["RGB"]["G"]?.Value<int>() ?? 0,
                    tubeColor["RGB"]["B"]?.Value<int>() ?? 0));
            }
        }
        
        public static CMYK GetCMYKColour(string lineId)
        {
            if (!_tubeColorCMYKDictionary.ContainsKey(lineId))
            {
                throw new ArgumentException($"Colour for line [{lineId}] could not be found in CMYK colour map");
            }

            return _tubeColorCMYKDictionary[lineId];
        }

        public static RGB GetRGBColour(string lineId)
        {
            if (!_tubeColorRGBDictionary.ContainsKey(lineId))
            {
                throw new ArgumentException($"Colour for line [{lineId}] could not be found in RGB colour map");
            }

            return _tubeColorRGBDictionary[lineId];
        }
    }
}
