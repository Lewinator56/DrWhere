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
    /// Interaction logic for CheckBoxLabel.xaml
    /// </summary>
    public partial class CheckBoxLabel : UserControl
    {
        public CheckBoxLabel()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        //check to see if this is selected
        public bool getChecked()
        {
            return this.checkBox.IsChecked.Value;
        }
        
        //returns the returnText IF the box is checked
        public string getCheckedString()
        {
            if (getChecked())
            {
                return this.returnText;
            }
            else return null;
        }
        public string FilterText { get; set; }
        public string returnText { get; set; }
    }

}
