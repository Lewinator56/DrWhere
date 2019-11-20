using System.Windows;
using System.Collections.Generic;
using DrWhere.Components;

namespace DrWhere {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public ObservableCollection<ServiceModel> GridList = new ObservableCollection<ServiceModel>;
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Set max distance
            GlobalVar.maxDistanceMiles = 5f;

            // Initialize http client
            PostcodeApiClient.InitializeClient();
        }

        private void ResultsPane_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
