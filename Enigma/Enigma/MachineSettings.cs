using System;

namespace Enigma
{
    public class MachineSettings
    {
        public char[] Plugs { get; set; } = new char[0];
        // Reflector | Rotor1 | Rotor2 | Rotor3 | Plugboard | Input / Output
        // Reflector | Rotor1 | Rotor2 | Rotor3 | Rotor4 | Plugboard | Input / Output

        public ReflectorType Reflector { get; set; }

        public char[] RingPositions { get; set; } = new char[0];

        public RotorGroupType RotorGroupType { get; set; }

        public char[] RotorPositions { get; set; } = new char[0];

        public RotorType[] Rotors { get; set; }


        public void Validate()
        {
            if (Plugs != null && Plugs.Length % 2 != 0)
                throw new ArgumentOutOfRangeException();

            switch (RotorGroupType)
            {
                case RotorGroupType.Rotor3:

                    if (Rotors.Length != 3)
                        throw new ArgumentOutOfRangeException();

                    if (RotorPositions.Length != 3)
                        throw new ArgumentOutOfRangeException();

                    if (RingPositions.Length != 3)
                        throw new ArgumentOutOfRangeException();

                    break;
                case RotorGroupType.Rotor4:

                    if (Rotors.Length != 4)
                        throw new ArgumentOutOfRangeException();

                    if (RotorPositions.Length != 4)
                        throw new ArgumentOutOfRangeException();

                    if (RingPositions.Length != 4)
                        throw new ArgumentOutOfRangeException();

                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            Plugs = new string(Plugs).ToUpper().ToCharArray();
            RotorPositions = new string(RotorPositions).ToUpper().ToCharArray();
            RingPositions = new string(RingPositions).ToUpper().ToCharArray();
        }
    }
}
