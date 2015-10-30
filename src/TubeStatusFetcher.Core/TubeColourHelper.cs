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
        private static Dictionary<string, CMYK> _tubeColorDictionary = new Dictionary<string, CMYK>();

        static TubeColourHelper()
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

        public static CMYK GetLineColour(string lineId)
        {
            if (!_tubeColorDictionary.ContainsKey(lineId))
            {
                throw new ArgumentException($"Colour for line [{lineId}] could not be found in color map");
            }

            return _tubeColorDictionary[lineId];
        }

    }
}
