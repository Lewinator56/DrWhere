using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrWhere
{
    class GlobalVar
    {
        public static string postcodeSelected { get; set; } // The verified postcode entered
        public static float distanceSelected { get; set; } // The distance selected, in abitary units
        public static bool distanceInMiles { get; set; } // Boolean, is the distance selected in miles (true) or Km (false)
        public static float maxDistanceMiles { get; set; } // Maximum distance in miles for the search radius

        public static List<string> SelectedTypes { get; set; } // List of selected filters (Types), non selected filters are stored as ''
        public static bool showPrivate { get; set; } // Boolean, are private services being shown

        public static ObservableCollection<ServiceModel> serviceCollection = new ObservableCollection<ServiceModel>();
        public static ObservableCollection<ServiceModel> ServiceCollection { get { return serviceCollection; } }
    }
}
