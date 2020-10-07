using System;

namespace Enigma
{
    public class Reflector
    {
        private readonly char[] _key;

        public Reflector(ReflectorType reflectorType)
        {
            _key = GetKey(reflectorType);
        }

        public char GetOutput(char input)
        {
            return CharSwap(input, MyExtensions.Alphabet, _key);
        }

        private static char CharSwap(char c, char[] fromKey, char[] toKey)
        {
            var index = MyExtensions.GetIndex(c, fromKey);

            return toKey[index];
        }

        private static char[] GetKey(ReflectorType reflectorType)
        {
            switch (reflectorType)
            {
                case ReflectorType.A: return "EJMZALYXVBWFCRQUONTSPIKHGD".ToCharArray();
                case ReflectorType.B: return "YRUHQSLDPXNGOKMIEBFZCWVJAT".ToCharArray();
                case ReflectorType.C: return "FVPJIAOYEDRZXWGCTKUQSBNMHL".ToCharArray();
                case ReflectorType.BThin: return "ENKQAUYWJICOPBLMDXZVFTHRGS".ToCharArray();
                case ReflectorType.CThin: return "RDOBJNTKVEHMLFCWZAXGYIPSUQ".ToCharArray();
                default: throw new ArgumentOutOfRangeException(nameof(reflectorType), reflectorType, null);
            }
        }
    }
}
