namespace Enigma
{
    public class RotorGroup3 : RotorGroupBase, IRotorGroup
    {
        //// https://crypto.stackexchange.com/questions/71231/enigma-rotation-example
        //// https://en.wikipedia.org/wiki/Enigma_rotor_details

        public RotorGroup3(
            Rotor rotor1,
            Rotor rotor2,
            Rotor rotor3,
            Reflector reflector
        )
        {
            _rotor1 = rotor1;
            _rotor2 = rotor2;
            _rotor3 = rotor3;
            _reflector = reflector;
        }

        public char[] RingSettings
        {
            get => GetRingSettings();
            set => SetRingSettings(value);
        }

        public char[] RotorPositions
        {
            get => GetRotorPositions();
            set => SetRotorPositions(value);
        }

        public char GetOutput(char input)
        {
            Increment();

            var c = input;

            c = _rotor3.GetForward(c);

            c = _rotor2.GetForward(c);

            c = _rotor1.GetForward(c);

            c = _reflector.GetOutput(c);

            c = _rotor1.GetBackward(c);

            c = _rotor2.GetBackward(c);

            c = _rotor3.GetBackward(c);

            return c;
        }


        private char[] GetRingSettings()
        {
            return new[]
            {
                _rotor1.RingSetting,
                _rotor2.RingSetting,
                _rotor3.RingSetting
            };
        }

        private char[] GetRotorPositions()
        {
            return new[]
            {
                _rotor1.Position,
                _rotor2.Position,
                _rotor3.Position
            };
        }

        private void Increment()
        {
            // https://www.youtube.com/watch?v=5StZlF-clPc

            var r1 = false;
            var r2 = false;
            var r3 = true;

            if (_rotor3.Notch)
            {
                r3 = true;
                r2 = true;
            }

            if (_rotor2.Notch)
            {
                r1 = true;
                r2 = true;
            }

            if (_rotor1.Notch)
                r1 = true;


            if (r1)
                _rotor1.Increment();

            if (r2)
                _rotor2.Increment();

            if (r3)
                _rotor3.Increment();
        }

        private void SetRingSettings(char[] value)
        {
            _rotor1.RingSetting = value[0];
            _rotor2.RingSetting = value[1];
            _rotor3.RingSetting = value[2];
        }

        private void SetRotorPositions(char[] value)
        {
            _rotor1.Position = value[0];
            _rotor2.Position = value[1];
            _rotor3.Position = value[2];
        }
    }
}
