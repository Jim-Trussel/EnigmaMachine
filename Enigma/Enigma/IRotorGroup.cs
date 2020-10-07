namespace Enigma
{
    public interface IRotorGroup
    {
        char[] RingSettings { get; set; }
        char[] RotorPositions { get; set; }
        char GetOutput(char input);
    }
}
