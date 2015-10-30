using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeStatusFetcher.Core
{
    // Taken from: http://www.codeproject.com/Articles/19045/Manipulating-colors-in-NET-Part
   public class ColourHelper
   {
        public static CMYK RGBtoCMYK(int red, int green, int blue)
        {
            // normalizes red, green, blue values
            double c = (double)(255 - red) / 255;
            double m = (double)(255 - green) / 255;
            double y = (double)(255 - blue) / 255;

            double k = (double)Math.Min(c, Math.Min(m, y));

            if (k == 1.0)
            {
                return new CMYK(0, 0, 0, 1);
            }
            else
            {
                return new CMYK((c - k) / (1 - k), (m - k) / (1 - k), (y - k) / (1 - k), k);
            }
        }

        public static Color CMYKtoRGB(double c, double m, double y, double k)
        {
            int red = Convert.ToInt32((1 - c) * (1 - k) * 255.0);
            int green = Convert.ToInt32((1 - m) * (1 - k) * 255.0);
            int blue = Convert.ToInt32((1 - y) * (1 - k) * 255.0);

            return Color.FromArgb(red, green, blue);
        }
    }

    /// <summary>
    /// Structure to define CMYK.
    /// </summary>
    public struct CMYK
    {
        /// <summary>
        /// Gets an empty CMYK structure;
        /// </summary>
        public readonly static CMYK Empty = new CMYK();

        private double c;
        private double m;
        private double y;
        private double k;

        public static bool operator ==(CMYK item1, CMYK item2)
        {
            return (
                item1.Cyan == item2.Cyan
                && item1.Magenta == item2.Magenta
                && item1.Yellow == item2.Yellow
                && item1.Black == item2.Black
                );
        }

        public static bool operator !=(CMYK item1, CMYK item2)
        {
            return (
                item1.Cyan != item2.Cyan
                || item1.Magenta != item2.Magenta
                || item1.Yellow != item2.Yellow
                || item1.Black != item2.Black
                );
        }

        public double Cyan
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                c = (c > 1) ? 1 : ((c < 0) ? 0 : c);
            }
        }

        public double Magenta
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
                m = (m > 1) ? 1 : ((m < 0) ? 0 : m);
            }
        }

        public double Yellow
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                y = (y > 1) ? 1 : ((y < 0) ? 0 : y);
            }
        }

        public double Black
        {
            get
            {
                return k;
            }
            set
            {
                k = value;
                k = (k > 1) ? 1 : ((k < 0) ? 0 : k);
            }
        }

        /// <summary>
        /// Creates an instance of a CMYK structure.
        /// </summary>
        public CMYK(double c, double m, double y, double k)
        {
            this.c = c;
            this.m = m;
            this.y = y;
            this.k = k;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            return (this == (CMYK)obj);
        }

        public override int GetHashCode()
        {
            return Cyan.GetHashCode() ^
              Magenta.GetHashCode() ^ Yellow.GetHashCode() ^ Black.GetHashCode();
        }

    }
}
