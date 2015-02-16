using System;

namespace CelticEgyptianRatscrewKata.GameSetup
{
    class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random;

        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        public RandomNumberGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public int Get(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}