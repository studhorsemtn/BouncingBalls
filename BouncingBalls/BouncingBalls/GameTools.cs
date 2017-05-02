using System;
using System.Drawing;

namespace BouncingBalls
{
    public class GameTools
    {
        static Random _random;
        public static Color GetRandomColor()
        {
            return Color.FromArgb(255, GetRandomNumber(0, 255), GetRandomNumber(0, 255), GetRandomNumber(0, 255));
        }
        public static Color GetRandomAlphaColor()
        {
            return Color.FromArgb(GetRandomNumber(0, 255), GetRandomNumber(0, 255), GetRandomNumber(0, 255), GetRandomNumber(0, 255));
        }
        public static int GetRandomNumber(int lowestPossibleValue, int heighestPossibleValue, bool allowZero = false)
        {
            if (_random == null)
                _random = new Random();

            int temp = _random.Next(lowestPossibleValue, heighestPossibleValue + 1);
            if (allowZero)
                return temp;

            return temp == 0 ? GetRandomNumber(lowestPossibleValue, heighestPossibleValue, false) : temp;
        }
    }
}
