using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeStatusFetcher.Core
{
    public interface IColourProvider
    {
        CMYK GetForegroundColour(string lineId);
        CMYK GetBackgroundColour(string lineId);
    }

    public class ConsoleColourProvider : IColourProvider
    {
        public CMYK GetBackgroundColour(string lineId)
        {
            throw new NotImplementedException();
        }

        public CMYK GetForegroundColour(string lineId)
        {
            throw new NotImplementedException();
        }
    }

    
}
