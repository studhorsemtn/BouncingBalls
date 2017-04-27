using System;
using System.Drawing;

namespace BouncingBalls
{
    public class GameTools
    {
        static Random _random;
        public static int GetRandomNumber(int lowestPossible, int highestPossible, bool zeroIsValid = false)
        {
            if (_random == null)
                _random = new Random();

            var temp = _random.Next(lowestPossible, highestPossible + 1);

            if (zeroIsValid)
                return temp;

            // if zero is not an allowed number, reroll this random number.
            return temp == 0 ? GetRandomNumber(lowestPossible, highestPossible, zeroIsValid) : temp;
        }
        public static Color GetRandomColor()
        {
            int r = GetRandomNumber(0, 255);
            int g = GetRandomNumber(0, 255);
            int b = GetRandomNumber(0, 255);

            return Color.FromArgb(r, g, b);
        }
        public static Color GetRandomAlphaColor()
        {
            int a = GetRandomNumber(0, 255);
            int r = GetRandomNumber(0, 255);
            int g = GetRandomNumber(0, 255);
            int b = GetRandomNumber(0, 255);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
