using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;

namespace DrWhere {
    public class PostcodeProcess {
        private const double RADIUS_MILES = 3959;
        private const double RADIUS_KM = 6371;

        /**
         * Check if postcode string is valid
         */
        public static async Task<bool> CheckPostcode(string postcode) {
            // Check if postcode is null or empty
            if (postcode == null || postcode.Equals(""))
                return false;

            // Remove non letters or digits characters from string if it contains it
            if (!postcode.All(Char.IsLetterOrDigit)) {
                Console.WriteLine(postcode);
                Regex regex = new Regex("[^A-Za-z0-9 -]");
                postcode = regex.Replace(postcode, "");
                Console.WriteLine(postcode);
            }

            // Check if the postcode is in the api
            string url = "https://api.postcodes.io/postcodes/" + postcode + "/validate";
            using (HttpResponseMessage response = await PostcodeApiClient.ApiClient.GetAsync(url)) {
                // HttpStatusCode Success
                if (response.IsSuccessStatusCode) {
                    // Get string from http response message
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // Process the json string with json converter
                    var details = JsonConvert.DeserializeObject<dynamic>(jsonString);
                    string result = details.result;

                    // Check status message
                    if (result.Equals("True"))
                        return true;
                    else
                        return false;
                }
                // HttpStatusCode error
                else {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /**
         * Calculate distance between two postcodes
         */
        public static async Task<double> PostcodeDistance(string fromPostcode, string toPostcode, bool inMiles) {
            // Check the postcodes are valid
            if (!(await CheckPostcode(fromPostcode)) || !(await CheckPostcode(toPostcode)))
                return 0.0;

            // Grabs json data from postcodes
            string fromPostcodeJson = await PostcodeJson(fromPostcode);
            string toPostcodeJson = await PostcodeJson(toPostcode);

            // Process the json string with json converter
            string fromLat, toLat, fromLong, toLong;
            var details = JsonConvert.DeserializeObject<dynamic>(fromPostcodeJson);
            fromLat = details.result.latitude;
            fromLong = details.result.longitude;

            details = JsonConvert.DeserializeObject<dynamic>(toPostcodeJson);
            toLat = details.result.latitude;
            toLong = details.result.longitude;

            // Calculate distance using Haversine formula
            return CoordinateDistance(double.Parse(fromLat), double.Parse(fromLong), double.Parse(toLat), double.Parse(toLong), inMiles) ;
        }

        /**
         * Gets postcode information in a string of json format
         */
        private static async Task<string> PostcodeJson(string postcode) {
            string url = "https://api.postcodes.io/postcodes/" + postcode;
            using (HttpResponseMessage response = await PostcodeApiClient.ApiClient.GetAsync(url)) {
                // HttpStatusCode Success
                if (response.IsSuccessStatusCode) {
                    // Get string from http response message
                    return await response.Content.ReadAsStringAsync();
                }
                // HttpStatusCode error
                else {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /**
         * Implements haversine formula that determines
         * great circle distance between two points
         */
        private static double CoordinateDistance(double fromLat, double fromLong, double toLat, double toLong, Boolean inMiles) {
            // Haversine Formula
            double distLat = DegToRad(fromLat - toLat);
            double distLong = DegToRad(fromLong - toLong);

            double a = Math.Pow(Math.Sin(distLat / 2), 2) + Math.Pow(Math.Sin(distLong / 2), 2)
                        * Math.Cos(DegToRad(fromLat)) * Math.Cos(DegToRad(toLat));
            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Convert to miles
            double distance = 0.0;
            if (inMiles) {
                distance = c * RADIUS_MILES;
            }
            // Convert to km
            else {
                distance = c * RADIUS_KM;
            }
            return distance;
        }

        /**
         * Convert from degrees to radians
         */
        private static double DegToRad(double degrees) {
            double radians = degrees * (Math.PI / 180);
            return radians;
        }
    }
}