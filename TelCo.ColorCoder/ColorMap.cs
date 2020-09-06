using System;
using System.Drawing;

#region Namespace
namespace TelCo.ColorCoder
{
    #region User Defined Data Types
    /// <summary>
    /// This class provides the color coding and
    /// mapping of pair number to color and color to pair number.
    /// </summary>
    class ColorMap
    {
        #region Fields
        /// <summary>
        /// Array of Major colors
        /// </summary>
        static Color[] colorMapMajor;
        /// <summary>
        /// Array of minor colors
        /// </summary>
        static Color[] colorMapMinor;
        #endregion

        #region Static Constructor
        /// <summary>
        /// Static constructor required to initialize static variable
        /// </summary>
        static ColorMap()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        internal static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            // Construct the return val from the arrays
            ColorPair pair = new ColorPair(colorMapMajor[majorIndex], colorMapMinor[minorIndex]);

            // return the value
            return pair;
        }

        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorPair pair)
        {
            // Get the index of major color
            int majorIndex = Array.IndexOf(colorMapMajor, pair.majorColor);

            // Get the index of minor color
            int minorIndex = Array.IndexOf(colorMapMinor, pair.minorColor);

            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
        public override string ToString()
        {
            string mapOfPairNumberToColor = "";
            for(int i = 1 ; i <= colorMapMajor.Length * colorMapMinor.Length ;i++)
            {
                ColorPair pair = GetColorFromPairNumber(i);
                mapOfPairNumberToColor += string.Format("PairNumber:{0}, {1}\n", i, pair.ToString());
            }
            return mapOfPairNumberToColor;
        }
        #endregion
    }
    #endregion
}
#endregion