using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// data type defined to hold the two colors of clor pair
    /// </summary>
    internal class ColorPair
    {
        internal Color majorColor;
        internal Color minorColor;
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
    }
}
