using System;
using Renttracker.Models;

namespace Renttracker
{
    public static class Extensions
    {
        /// <summary>
        /// Verifies whether a given Home object has valid coordinates
        /// </summary>
        /// <param name="home">Home object to verify</param>
        /// <returns>Boolean</returns>
        public static bool HasValidCoordinates(this Home home)
        {
            if (home.Location == null)
                return false;

            var location = home.Location;

            if (location.Latitude == null || location.Longitude == null)
                return false;

            return true;
        }

        /// <summary>
        /// Verifies whether a given Home object has a given address string
        /// </summary>
        /// <param name="home">Home object</param>
        /// <returns>Boolean</returns>
        public static bool HasValidAddress(this Home home)
        {
            if (home.Location == null)
                return false;

            var location = home.Location;

            if (string.IsNullOrEmpty(location.Address))
                return false;

            if (string.IsNullOrEmpty(location.City))
                return false;

            if (string.IsNullOrEmpty(location.PostCode))
                return false;

            if (string.IsNullOrEmpty(location.Region))
                return false;

            if (string.IsNullOrEmpty(location.Country))
                return false;

            return true;
        }

        public static string GetLocationString(this Home home)
        {
            if (home.Location == null)
                throw new ArgumentNullException(nameof(home.Location), "Location cannot be null");

            return home.Location.ToString();
        }

        public static double[] GetLocationCoordinates(this Home home)
        {
            if (home.Location == null)
                throw new ArgumentNullException(nameof(home.Location), "Location cannot be null");      //In the event that this actually happens, might it be better to just return null and let the calling method handle it? -RnC

            var location = home.Location;

            if (location.Latitude != null && location.Longitude != null)
                return new double[] { (double)location.Latitude, (double)location.Longitude };
            else
                throw new ArgumentNullException(nameof(location), "Location data was incomplete!");     //Ditto my comment above. -RnC
        }
    }
}
