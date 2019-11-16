using System;
using System.Collections.Generic;
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
        public static List<String> selectedTypes { get; set; } // List of selected filters (Types), non selected filters are stored as ''
        public static bool showPrivate { get; set; } // Boolean, are private services being shown

        public static Uri databaseUri { get; set; } // Uri of the database to connect to
        public static string DBUser { get; set; } // The username of the user to connect to the database using

        public static List<ServicesData> ServicesList { get; set; } // The list of services to DISPLAY in the results panel, update this with ONLY the services to display based on the filter selection



    }
}
