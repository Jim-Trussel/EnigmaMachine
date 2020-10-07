namespace Enigma
{
    public class RotorGroupBase
    {
        internal Reflector _reflector;
        internal Rotor _rotor1;
        internal Rotor _rotor2;

        internal Rotor _rotor3;
        // https://crypto.stackexchange.com/questions/71231/enigma-rotation-example
        // https://en.wikipedia.org/wiki/Enigma_rotor_details

        internal RotorGroupType _rotorGroupType;
    }
}
