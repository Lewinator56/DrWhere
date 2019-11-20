using System;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DrWhere {
    class DatabaseResults {
        // Updates global variable list results
        public static async void DisplayResults() { // GlobalVar.ServicesList
            // Reset list
            GlobalVar.ServiceCollection.Clear();

            // Check user's enetered postcode
            if (!await PostcodeProcess.CheckPostcode(GlobalVar.postcodeSelected))
                return;

            // Build database connection string
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder {
                Server = "51.104.231.199",
                Port = 3306,
                UserID = "DrWhere",
                Database = "Soft_DrWhere"
            };

            // Construct Sql Command Text Based on conditions
            string sqlCmdText = "SELECT * FROM `ServiceDetails`";

            sqlCmdText += " WHERE (Type='" + GlobalVar.SelectedTypes[0] + "' ";
            foreach (string myCond in GlobalVar.SelectedTypes.Skip(1)) {
                if (!myCond.Equals(""))
                    sqlCmdText += "OR Type='" + myCond + "'"; 
            }
            sqlCmdText += ")";

            if (!GlobalVar.showPrivate)
                sqlCmdText += " AND Private=0";


            // Search database
            using (MySqlConnection conn = new MySqlConnection(conn_string.ToString())) {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCmdText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // Read the database rows
                while (reader.Read()) {
                    // Check database postcode
                    if (!await PostcodeProcess.CheckPostcode("" + reader[0]))
                        continue;

                    // Calculate distance and check if it matches distance selected
                    double distance = await PostcodeProcess.PostcodeDistance(GlobalVar.postcodeSelected, "" + reader[0], GlobalVar.distanceInMiles);
                    if (distance > Math.Round(GlobalVar.distanceSelected, 1))
                        continue;

                    // Create model
                    ServiceModel model = new ServiceModel();
                    model.Postcode = "" + reader[0]; // Reader.asString() // LATER [!]
                    model.Type = "" + reader[1];
                    model.Name = "" + reader[2];
                    model.Address = "" + reader[3];
                    model.Telephone = "" + reader[4];
                    model.Private = "" + reader[5];

                    // Add distance to model
                    string milesKm = (GlobalVar.distanceInMiles) ? "Mi" : "km";
                    model.Distance = "" + Math.Round(distance, 2) + milesKm;

                    // Add row to data grid of the model
                    GlobalVar.ServiceCollection.Add(model);
                }
                // Close connection
                reader.Close();
                conn.Close();
            }
        }
    }
}
