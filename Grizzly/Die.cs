using System;

namespace Grizzly
{
    class Die
    {
        private static readonly Random random = new Random();

        public int Sides { get; private set; }

        public Die(int sides = 1)
        {
            Sides = sides;
        }

        public int Roll()
        {
            return random.Next(Sides);
        }
    }
}
