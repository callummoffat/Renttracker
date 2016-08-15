using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renttracker.Models
{
    /// <summary>
    /// Data model representing a house for rent
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Home : ModelBase
    {

        
        
        public override string Name
        {
            get
            {
              return $" { this.GetLocationString() }({ Price.ToString("C")})";
            }
        }

        

        /// <summary>
        /// The area of this home in square feet
        /// </summary>
        [JsonProperty("area")]
        public int Area { get; set; }

        /// <summary>
        /// The number of baths in this home
        /// </summary>
        [JsonProperty("baths")]
        public int Baths { get; set; }

        /// <summary>
        /// The number of beds in this home
        /// </summary>
        [JsonProperty("beds")]
        public int Beds { get; set; }

        /// <summary>
        /// A description of this home
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

       
        /// <summary>
        /// A list of urls pointing to images of this home
        /// </summary>
        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();

        /// <summary>
        /// The location of this home (should handle addresses and geo coordinates)
        /// </summary>
        [JsonProperty("location")]
        public HomeLocation Location { get; set; }

       

        /// <summary>
        /// The price of this home
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
