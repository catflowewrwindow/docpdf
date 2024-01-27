using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docpdf
{
    internal class ImageInlineObject
    {
        public Image Image { get; }

        public ImageInlineObject(Image image)
        {
            Image = image;
        }
    }
}
