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
    /// Interaction logic for SearchPane.xaml
    /// </summary>
    /// 
    // TODO add verification logic to postcode input, waiting for backend build
    public partial class SearchPane : UserControl
    {
        public SearchPane()
        {
            InitializeComponent();
        }

        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            //first, lets get the current selected filters

            // Main filters
            GlobalVar.selectedTypes = new List<string> { GPSelect.getCheckedString(), DentistSelect.getCheckedString(), OpticianSelect.getCheckedString(), SchoolSelect.getCheckedString(), NurserySelect.getCheckedString() };
            // Private filter
            GlobalVar.showPrivate = PrivateSelect.getChecked();

            // Now call the display routines

            // just some debugging
            MessageBox.Show("Selected: \n" + String.Join(Environment.NewLine,GlobalVar.selectedTypes.ToArray()) + "\n" + GlobalVar.showPrivate.ToString() + "\n" + "Distance: \n" + GlobalVar.distanceSelected + "\n" + "in Miles: " + GlobalVar.distanceInMiles.ToString());
            
        }
    }
}
