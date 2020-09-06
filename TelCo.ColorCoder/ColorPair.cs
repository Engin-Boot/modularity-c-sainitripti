using System.Drawing;

#region Namespace
namespace TelCo.ColorCoder
{
    #region User Defined Data Types
    /// <summary>
    /// data type defined to hold the two colors of color pair
    /// </summary>
    internal class ColorPair
    {
        #region Fields
        internal Color majorColor;
        internal Color minorColor;
        #endregion

        #region Methods
        internal ColorPair(Color majorColor, Color minorColor)
        {
            this.majorColor = majorColor;
            this.minorColor = minorColor;
        }
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
        #endregion
    }
    #endregion
}
#endregion
