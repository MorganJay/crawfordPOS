using System.Windows;
using System.Windows.Input;


namespace CrawfordPOS
{
    /// <summary>
    /// Interaction logic for CustomersCatalogue.xaml
    /// </summary>
    public partial class CustomersCatalogue : Window
    {
        public CustomersCatalogue()
        {
            InitializeComponent();
        }

        private void CustomersCatalogue1_Loaded(object sender, RoutedEventArgs e)
        {
            //CrawfordPOS.POSDataset pOSDataset = ((CrawfordPOS.POSDataset)(this.FindResource("pOSDataset")));
        }

        private void CustomersCatalogue1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
