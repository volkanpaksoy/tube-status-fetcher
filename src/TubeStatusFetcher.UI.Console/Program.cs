using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tsf = new Fetcher();
            tsf.GetTubeInfo();
        }
    }
}
