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

namespace DigitalBankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayArea.Content = new CreateAcc_UC();
        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearAccountsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportDataButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}