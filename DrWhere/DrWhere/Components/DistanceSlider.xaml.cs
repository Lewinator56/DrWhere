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

namespace DrWhere.Components
{
    /// <summary>
    /// Interaction logic for DistanceSlider.xaml
    /// </summary>
    public partial class DistanceSlider : UserControl
    {
        public DistanceSlider()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public double distanceSelected { get; set; }
        public Boolean distanceType { get; set; }

        private void DistanceSliderPart_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float maxDistanceKm = 30;
            float maxDistanceMi = maxDistanceKm / 1.609f;

            this.distanceSelected = this.DistanceSliderPart.Value;
            this.DistanceLabel.Content = this.distanceSelected.ToString() + (distanceType ? " Km" : " Mi");
        }

        
    }
}
