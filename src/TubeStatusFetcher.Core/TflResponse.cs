using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TubeStatusFetcher.Core
{
    internal class TflResponse
    {
        public List<TflLineInfo> LineInfo { get; set; }
    }

    internal class TflLineInfo
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string modeName { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public Linestatus[] lineStatuses { get; set; }
        public object[] routeSections { get; set; }
        public Servicetype[] serviceTypes { get; set; }
    }

    internal class Linestatus
    {
        public string type { get; set; }
        public int id { get; set; }
        public int statusSeverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public string reason { get; set; }
        public DateTime created { get; set; }
        public object[] validityPeriods { get; set; }
    }

    internal class Servicetype
    {
        public string type { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }
}


