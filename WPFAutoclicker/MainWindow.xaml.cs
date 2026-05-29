using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAutoclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isClicking = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStartAuto_Click(object sender, RoutedEventArgs e)
        {
            if (!isClicking)
            {
                isClicking = true;
                Debug.WriteLine("Auto-clicking started.");
                //set clicking to start
            }
            else
            {
                isClicking = false;
                Debug.WriteLine("Auto-clicking stopped.");
                //disable clicking
            }
        }
    }
}