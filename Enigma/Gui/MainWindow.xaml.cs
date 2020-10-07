using System.Windows;
using System.Windows.Controls;
using Enigma;

namespace Gui
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Machine _machine;


        public MainWindow()
        {
            InitializeComponent();
            TbOutput.Text = "";
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

            _machine = new Machine(settings);

            DoUpdate();
        }

        private void DoUpdate()
        {
            var positions = _machine.GetRotorPosition();
            LabelRotor1.Content = positions[0];
            LabelRotor2.Content = positions[1];
            LabelRotor3.Content = positions[2];
        }

        private void key_Click(object sender, RoutedEventArgs e)
        {
            var key = ((Button) sender).Name.ToCharArray()[0];
            var c = _machine.PressKey(key);

            TbOutput.Text = TbOutput.Text + c;

            DoUpdate();
            // Show message box when button is clicked.
            //  MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
