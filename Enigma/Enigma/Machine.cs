using System;
using System.Linq;

namespace Enigma
{
    public class Machine
    {
        private readonly IPlugboard _plugboard;
        private readonly IRotorGroup _rotorGroup;

        public Machine(MachineSettings machineSettings)
        {
            machineSettings.Validate();

            _plugboard = new Plugboard(Plugboard.GetSettings(machineSettings.Plugs));

            _rotorGroup = machineSettings.RotorGroupType switch
            {
                RotorGroupType.Rotor3 => new RotorGroup3(
                    new Rotor(machineSettings.Rotors[0]),
                    new Rotor(machineSettings.Rotors[1]),
                    new Rotor(machineSettings.Rotors[2]),
                    new Reflector(machineSettings.Reflector)
                ),
                RotorGroupType.Rotor4 => new RotorGroup4(
                    new Rotor(machineSettings.Rotors[0]),
                    new Rotor(machineSettings.Rotors[1]),
                    new Rotor(machineSettings.Rotors[2]),
                    new Rotor(machineSettings.Rotors[3]),
                    new Reflector(machineSettings.Reflector)
                ),
                _ => throw new ArgumentOutOfRangeException()
            };

            _rotorGroup.RotorPositions = machineSettings.RotorPositions;
            _rotorGroup.RingSettings = machineSettings.RotorPositions;
        }

        public char[] GetRotorPosition()
        {
            return _rotorGroup.RotorPositions;
        }

        public char PressKey(char cIn)
        {
            if (!MyExtensions.Alphabet.ToList().Contains(cIn))
                throw new Exception();

            var c1 = _plugboard.Convert(cIn);
            var c2 = _rotorGroup.GetOutput(c1);
            var c3 = _plugboard.Convert(c2);

            return c3;
        }

        public char[] PressKeys(char[] cIn)
        {
            return cIn.Select(PressKey).ToArray();
        }
    }
}
