using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace WPFAutoclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isClicking = false;
        int delay = 1000;
        public MainWindow()
        {
            InitializeComponent();
            btnStartAuto.Click += ButtonStartAuto_Click;
            btnStopAuto.Click += ButtonStopAuto_Click;
            txtDelay.TextChanged += txtDelay_TextChanged;
        }
        [DllImport("user32.dll")] static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        private async void ButtonStartAuto_Click(object sender, RoutedEventArgs e)
        {
            isClicking = true; //set clicking to start
            Debug.WriteLine("Auto-clicking.");

            while (isClicking)
            {
                mouse_event(0x0002, 0, 0, 0, UIntPtr.Zero); // Left mouse button down
                mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero); // Left mouse button up
                
                Debug.WriteLine("it would be clicking now");
                
                await Task.Delay(delay); // Delay between clicks

                //if (Keyboard.IsKeyDown(Key.F6))
                //{
                //    Debug.WriteLine("F6 pressed. Stopping auto-clicking.");
                //    
                //}
            }
           
        }
        private void ButtonStopAuto_Click(object sender, RoutedEventArgs e)
        {
            isClicking = false; //disable clicking
            mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero);
            Debug.WriteLine("Auto-clicking stopped.");
        }
        private void txtDelay_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(txtDelay.Text, out delay))
            {
                // Update the delay value based on user input
                Debug.WriteLine($"Delay updated to: {delay} ms");
            }
            else
            {
                Debug.WriteLine("Invalid delay input. Please enter a valid integer.");
            }
        }
    }
}