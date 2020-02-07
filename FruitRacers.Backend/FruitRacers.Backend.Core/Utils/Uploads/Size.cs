using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public class Size
    {
        private const string SEPARATOR = "x";

        public int Width { get; set; }
        public int Height { get; set; }

        public Size()
        {

        }

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("{0}{2}{1}", this.Width, this.Height, SEPARATOR);
        }

        public static IOptional<Size> TryParse(string sizeString)
        {
            string[] dimensions = sizeString.Split(SEPARATOR);

            if (dimensions.Length != 2)
            {
                return Optional.Empty<Size>();
            }

            if (int.TryParse(dimensions[0], out int width) && int.TryParse(dimensions[1], out int height))
            {
                return Optional.Of(new Size(width, height));
            }
            else
            {
                return Optional.Empty<Size>();
            }
        }
    }
}
