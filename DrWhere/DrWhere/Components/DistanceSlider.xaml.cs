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
            float maxDistanceMi = GlobalVar.maxDistanceMiles;
            GlobalVar.distanceSelected = (maxDistanceMi / 10) * (float)DistanceSliderPart.Value;
            if (!MeasurementSelector.IsChecked.Value)
            {
                GlobalVar.distanceSelected *= 1.609f;
            }
            else
            {
                GlobalVar.distanceSelected = GlobalVar.distanceSelected;
            }
            GlobalVar.distanceInMiles = MeasurementSelector.IsChecked.Value;
            this.DistanceLabel.Content = GlobalVar.distanceSelected.ToString("N1") + (!MeasurementSelector.IsChecked.Value ? " Km" : " Mi");
        }
    }
}
