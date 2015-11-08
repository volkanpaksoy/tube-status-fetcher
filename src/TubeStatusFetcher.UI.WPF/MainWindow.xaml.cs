using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TubeStatusFetcher.Core;

namespace TubeStatusFetcher.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Fetcher _fetcher;

        public MainWindow()
        {
            InitializeComponent();

            _fetcher = new Fetcher();

            DisplayStatus(_fetcher.GetTubeInfo());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayStatus(_fetcher.GetTubeInfo());
        }

        private void DisplayStatus(List<LineInfo> tubeStatus)
        {
            retrievalTimeLabel.Content = $"Data retrieved at {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";

            statusListView.Items.Clear();
           
            foreach (var lineInfo in tubeStatus)
            {
                statusListView.Items.Add(new WpfLineInfoDecorator(lineInfo));
            }
        }
    }
}
