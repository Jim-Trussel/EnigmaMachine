namespace Enigma
{
    public interface IRotor
    {
        char GetBackward(char input);
        char GetForward(char input);
        void Increment();
    }
}
