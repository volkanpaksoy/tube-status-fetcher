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

        public List<LineInfo> GetTubeInfo()
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
    }
}
