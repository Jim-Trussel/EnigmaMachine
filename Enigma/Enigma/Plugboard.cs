using System;
using System.Collections.Generic;
using System.Linq;

namespace Enigma
{
    public class Plugboard : IPlugboard
    {
        private readonly Dictionary<char, char> _setting;

        public Plugboard(Dictionary<char, char> setting)
        {
            Validate(setting);

            _setting = setting;
        }

        public char Convert(char c)
        {
            return _setting[c];
        }

        public static Dictionary<char, char> GetSettings(char[] plugs)
        {
            var settings = new Dictionary<char, char>();

            foreach (var l in MyExtensions.Alphabet)
            {
                settings.Add(l, l);
            }

            for (var i = 0; i < plugs.Length; i++)
            {
                var a = plugs[i];
                var b = plugs[i + 1];

                settings[a] = b;
                settings[b] = a;
            }

            Validate(settings);

            return settings;
        }

        private static void Validate(Dictionary<char, char> settings)
        {
            var wireCount = settings.Where(x => x.Value != x.Key).Count();

            if (wireCount > 10)
                throw new Exception();

            foreach (var outPath in settings)
            {
                var returnPath = settings
                    .First(x => x.Key == outPath.Value);

                if (outPath.Key != returnPath.Value)
                    throw new Exception();
            }
        }
    }
}
