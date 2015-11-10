using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TubeStatusFetcher.Core
{
    public class TubeColourHelper
    {
		private static Dictionary<string, RGB> _tubeColorRGBDictionary = new Dictionary<string, RGB>();

		static TubeColourHelper()
		{
			string dataFilePath = "data/colours.json";

			if (!File.Exists (dataFilePath)) 
			{
				Console.WriteLine ("Couldn't find colours.json");
			} 
			else 
			{
				string json = File.ReadAllText(dataFilePath);

				var tubeColors = JArray.Parse(json);

				foreach (var tubeColor in tubeColors)
				{
					_tubeColorRGBDictionary.Add(tubeColor["id"].Value<string>(), new RGB(
						tubeColor["RGB"]["R"].Value<int>(),
						tubeColor["RGB"]["G"].Value<int>(),
						tubeColor["RGB"]["B"].Value<int>()));
				}	
			}
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
