using System;

namespace Enigma
{
    internal class Program
    {
        // https://en.wikipedia.org/wiki/Enigma_rotor_details

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var settings = new MachineSettings
            {
                Plugs = new char[0],
                Reflector = ReflectorType.B,
                RingPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                RotorGroupType = RotorGroupType.Rotor3,
                RotorPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                Rotors = new[]
                {
                    RotorType.I,
                    RotorType.II,
                    RotorType.III
                }
            };

            settings.Validate();

            var m = new Machine(settings);
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));
            Console.WriteLine(m.PressKey('A'));

            Console.ReadLine();
        }
    }
}
