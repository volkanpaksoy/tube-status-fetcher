using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeStatusFetcher.Core
{
    public struct RGB
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public RGB(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
