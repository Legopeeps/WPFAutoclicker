using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
namespace WPFAutoclicker
{
    public partial class MainWindow : Window
    {
        #region DllImports
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        #endregion
        bool isClicking = false;
        int delay = 1000;
        bool isDelayVaild = true;

        public MainWindow()
        {
            InitializeComponent();
            txtDelay.TextChanged += txtDelay_TextChanged;
            txtEquivalentTime.Text = $"Clicks per second = {1000.0 / delay:F2}";
        }
        private async void ButtonStartAuto_Click(object sender, RoutedEventArgs e)
        {
            if (isDelayVaild)
            {
                isClicking = true; //set clicking to start
                txtDelay.IsEnabled = false; //disable delay input
                btnStartAuto.IsEnabled = false; //disable start button
                btnStopAuto.IsEnabled = true; //enable stop button
                Debug.WriteLine("Auto-clicking.");

                while (isClicking)
                {
                    mouse_event(0x0002, 0, 0, 0, UIntPtr.Zero); // Left mouse button down
                    mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero); // Left mouse button up

                    await Task.Delay(delay); // Delay between clicks

                    //if (Keyboard.IsKeyDown(Key.F6))
                    //{
                    //    Debug.WriteLine("F6 pressed. Stopping auto-clicking.");
                    //    
                    //}
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid delay value.");
            }
        }
        private void ButtonStopAuto_Click(object sender, RoutedEventArgs e)
        {
            isClicking = false; //disable clicking
            mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero); //Mouse up
            Debug.WriteLine("Auto-clicking stopped.");
            btnStartAuto.IsEnabled = true; //enable start button
            btnStopAuto.IsEnabled = false; //disable stop button
            txtDelay.IsEnabled = true; //enable delay input
        }
        private void txtDelay_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(txtDelay.Text, out delay))
            {
                isDelayVaild = true;
                // Update the delay value based on user input
                txtEquivalentTime.Text = $"Clicks per second = {delay / 1000.0}";
            }
            else
            {
                isDelayVaild = false;
                txtEquivalentTime.Text = "Invalid delay input. Please enter a valid integer.";
            }
        }

        private void txtDelay_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtDelay.Text.Length < 3)
            {
                isDelayVaild = false;
                MessageBox.Show("The delay must be at least three numbers \n(example: 100)");
            } 
            else if (delay > int.MaxValue)
            {
                isDelayVaild = false;
                MessageBox.Show("The delay must be less than 2,147,483,647");
            }
        }

        private void btnSelectWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IntPtr selectedWindow = GetForegroundWindow();
            Debug.WriteLine($"Window:{selectedWindow} is selected");
        }
    }
}