using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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
        private Dictionary<string, Color> _tubeColourDictionary;
        Fetcher _fetcher;

        public MainWindow()
        {
            InitializeComponent();

            InitColours();

            _fetcher = new Fetcher();

            DisplayStatus(_fetcher.GetTubeInfo());
        }

        private void InitColours()
        {
            _tubeColourDictionary = new Dictionary<string, Color>();
            _tubeColourDictionary.Add("bakerloo", Color.Brown);
            _tubeColourDictionary.Add("central", Color.Red);
            _tubeColourDictionary.Add("circle", Color.Yellow);
            _tubeColourDictionary.Add("district", Color.Green);
            _tubeColourDictionary.Add("hammersmith-city", Color.Magenta);
            _tubeColourDictionary.Add("jubilee", Color.Gray);
            _tubeColourDictionary.Add("metropolitan", Color.DarkMagenta);
            _tubeColourDictionary.Add("northern", Color.Black);
            _tubeColourDictionary.Add("piccadilly", Color.DarkBlue);
            _tubeColourDictionary.Add("victoria", Color.Blue);
            _tubeColourDictionary.Add("waterloo-city", Color.DarkCyan);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var results = _fetcher.GetTubeInfo();
            foreach (var lineInfo in results)
            {
                lineInfo.Displaycolour = _tubeColourDictionary[lineInfo.Id];
            }

            DisplayStatus(results);
        }

        private void DisplayStatus(List<LineInfo> tubeStatus)
        {
            retrievalTimeLabel.Content = $"Data retrieved at {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";

            statusListView.Items.Clear();
           
            foreach (var lineInfo in tubeStatus)
            {
                statusListView.Items.Add(lineInfo);
            }
        }
    }
}
