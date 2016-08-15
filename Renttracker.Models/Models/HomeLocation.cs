using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Renttracker.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class HomeLocation : ModelBase, IFormattable, IEquatable<HomeLocation>
    {
       

        public override string Name
        {
            get
            {
                return ToString();
            }
        }

        
        /// <summary>
        /// Represents the address of a home
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; private set; }

        /// <summary>
        /// Represents the suburb in which a home is located
        /// </summary>
        [JsonProperty("suburb")]
        public string Suburb { get; private set; }

        /// <summary>
        /// Represents the city in which a home is located
        /// </summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// Represents the region in which a home is located
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; private set; }

        /// <summary>
        /// Represents the country in which a home is located
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>
        /// Represents the post code associated with a particular home
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; private set; }

        /// <summary>
        /// Latitude in which a home is located
        /// </summary>
        [JsonProperty("latitude")]
        public double? Latitude { get; private set; }

        /// <summary>
        /// Longitude in which a home is located
        /// </summary>
        [JsonProperty("longitude")]
        public double? Longitude { get; private set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Suburb))
                return $"{Address}, {Suburb}, {City} {PostCode}, {Region}, {Country}";
            else
                return $"{Address}, {City} {PostCode}, {Region}, {Country}";
        }

        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "C":
                    {
                        if (Latitude == null || Longitude == null)
                            return ToString();

                        return $"{ Latitude }, { Longitude }";
                    }
                case "A":
                default:
                    {
                        return ToString();
                        
                    }
                    
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((HomeLocation)obj);
        }

        public bool Equals(HomeLocation other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            return ToString().Equals(other.ToString());
        }

        public override int GetHashCode()
        {
            int hashCode = ToString().GetHashCode();
            return hashCode;
        }

        public static bool operator ==(HomeLocation lhs,
            HomeLocation rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(HomeLocation lhs,
            HomeLocation rhs)
        {
            return !(lhs == rhs);
        }
    }
}
