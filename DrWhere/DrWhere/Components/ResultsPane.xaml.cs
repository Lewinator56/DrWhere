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
    /// Interaction logic for ResultsPane.xaml
    /// </summary>
    public partial class ResultsPane : UserControl
    {
        List<ServicesData> searchResults;
        public ResultsPane()
        {
            InitializeComponent();
            this.DataContext = this;

            // basically all this does, on initialisation, sets the item source for the datagrid, we shouldn't need to touch this as WPF should handle updates for us
            ResultsGrid.ItemsSource = GlobalVar.ServicesList;
        }


    }

}
