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

            searchResults = new List<ServicesData>();
            searchResults.Add(new ServicesData()
            {
                Postcode = "LL57 4LS",
                Type = "GP",
                Name = "The Doctors Surgery",
                Address = "32 Steep Hill",
                Telephone = "07756 554324",
                Private = true,

            });
            ResultsGrid.ItemsSource = searchResults;
        }

    }

    public class ServicesData
    {
        public string Postcode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public bool Private { get; set; }

    }
}
