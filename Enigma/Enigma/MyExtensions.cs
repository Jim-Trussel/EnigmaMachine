using System;

namespace Enigma
{
    public static class MyExtensions
    {
        public static char[] Alphabet { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static int GetIndex(char c, char[] from)
        {
            var i = -1;
            foreach (var f in from)
            {
                i++;
                if (f == c)
                    return i;
            }

            throw new Exception("Index Not Found");
        }

        public static char LoopIndex(char[] key, int index)
        {
            var c = key[0];
            var maxIndex = key.Length - 1;

            if (index == 0)
                return c;

            var i = 0;

            if (index > 0)
            {
                if (maxIndex >= index)
                    return key[index];

                for (var j = 0; j <= index; j++)
                {
                    if (i == maxIndex + 1)
                        i = 0;

                    c = key[i];

                    i++;
                }

                return c;
            }

            i = 0;
            for (var j = 0; j >= index; j--)
            {
                if (i == -1)
                    i = maxIndex;

                c = key[i];

                i--;
            }

            return c;
        }

        public static int ToInt(this char c)
        {
            return GetIndex(c, "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
        }
    }
}
