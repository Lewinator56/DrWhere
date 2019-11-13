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
            MeasurementSelector.IsChecked = true;
            setDistance();
        }

        public float distanceSelected { get; set; }
        public Boolean distanceType { get; set; }

        private void DistanceSliderPart_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            setDistance();
        }

        private void MeasurementSelector_Click(object sender, RoutedEventArgs e)
        {
            setDistance();
        }

        private void setDistance()
        {
            float maxDistanceMi = 30;
            distanceSelected = (maxDistanceMi / 10) * (float)DistanceSliderPart.Value;
            if (!MeasurementSelector.IsChecked.Value)
            {
                distanceSelected *= 1.609f;
            }
            else
            {
                distanceSelected = distanceSelected;
            }
            this.DistanceLabel.Content = this.distanceSelected.ToString("N1") + (!MeasurementSelector.IsChecked.Value ? " Km" : " Mi");
        }
    }
}
