using System;

namespace Enigma
{
    public class Rotor : IRotor
    {
        private readonly char[] _key;
        private int _offset;
        private int _ringSetting;

        public Rotor(RotorType rotorType)
        {
            _key = GetKey(rotorType);
            RotorType = rotorType;
        }

        public bool Notch
        {
            get
            {
                var n = GetNotches(RotorType);

                if (n.Contains(Position))
                    return true;

                return false;
            }
        }

        public char Position
        {
            get =>
                MyExtensions.LoopIndex(
                    MyExtensions.Alphabet,
                    _offset
                );

            set => _offset = value.ToInt();
        }

        public char RingSetting
        {
            get => MyExtensions.Alphabet[_ringSetting];
            set => _ringSetting = MyExtensions.GetIndex(value, MyExtensions.Alphabet);
        }

        public RotorType RotorType { get; }

        public char GetBackward(char input)
        {
            var charIn = MyExtensions.LoopIndex(
                MyExtensions.Alphabet,
                input.ToInt() + _offset - _ringSetting
            );

            var charSwapped = CharSwap(charIn, _key, MyExtensions.Alphabet);

            var charOut = MyExtensions.LoopIndex(
                MyExtensions.Alphabet,
                charSwapped.ToInt() - _offset + _ringSetting
            );

            return charOut;
        }

        public char GetForward(char input)
        {
            var charIn = MyExtensions.LoopIndex(
                MyExtensions.Alphabet,
                input.ToInt() + _offset - _ringSetting
            );

            var charSwapped = CharSwap(charIn, MyExtensions.Alphabet, _key);

            var charOut = MyExtensions.LoopIndex(
                MyExtensions.Alphabet,
                charSwapped.ToInt() - _offset + _ringSetting
            );


            return charOut;
        }

        public void Increment()
        {
            _offset++;
            if (_offset == 26)
                _offset = 0;
        }

        public static string GetNotches(RotorType rotorType)
        {
            return rotorType switch
            {
                RotorType.I => "Q",
                RotorType.II => "E",
                RotorType.III => "V",
                RotorType.IV => "J",
                RotorType.V => "Z",
                RotorType.VI => "ZM",
                RotorType.VII => "ZM",
                RotorType.VIII => "ZM",
                _ => throw new Exception()
            };
        }

        private static char CharSwap(char c, char[] fromKey, char[] toKey)
        {
            var index = MyExtensions.GetIndex(c, fromKey);

            return toKey[index];
        }

        private static char[] GetKey(RotorType rotorType)
        {
            // 26, 0 - 25
            return rotorType switch
            {
                RotorType.I => "EKMFLGDQVZNTOWYHXUSPAIBRCJ".ToCharArray(),
                RotorType.II => "AJDKSIRUXBLHWTMCQGZNPYFVOE".ToCharArray(),
                RotorType.III => "BDFHJLCPRTXVZNYEIWGAKMUSQO".ToCharArray(),
                RotorType.IV => "ESOVPZJAYQUIRHXLNFTGKDCMWB".ToCharArray(),
                RotorType.V => "VZBRGITYUPSDNHLXAWMJQOFECK".ToCharArray(),
                RotorType.VI => "JPGVOUMFYQBENHZRDKASXLICTW".ToCharArray(),
                RotorType.VII => "NZJHGRCXMYSWBOUFAIVLPEKQDT".ToCharArray(),
                RotorType.VIII => "FKQHTLXOCBJSPDZRAMEWNIUYGV".ToCharArray(),
                _ => throw new Exception()
            };
        }
    }
}
