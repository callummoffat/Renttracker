using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Models
{
    /// <summary>
    /// Base class of all Renttracker data models
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class ModelBase
    {
        /// <summary>
        /// Data model identifier
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Data model name
        /// </summary>
        public abstract string Name { get; }

       
        
    }
}
