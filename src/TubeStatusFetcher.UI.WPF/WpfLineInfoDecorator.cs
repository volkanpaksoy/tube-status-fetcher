using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.WPF
{
    public class WpfLineInfoDecorator
    {
        public LineInfo LineInfo { get; set; }

        public WpfLineInfoDecorator(LineInfo lineInfo)
        {
            LineInfo = lineInfo;
        }

        public Brush BackColour
        {
            get
            {
                return new SolidColorBrush(Color.FromRgb((byte)LineInfo.LineColour.R, (byte)LineInfo.LineColour.G, (byte)LineInfo.LineColour.B));
            }
        }

        public Brush ForeColour
        {
            get
            {
                return new SolidColorBrush(Colors.White);
            }
        }
    }
}
