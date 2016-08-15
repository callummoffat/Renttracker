using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.DataServices
{
    public abstract class DataServiceBase : IDataService
    {
        /// <summary>
        /// Fired when the data source is updated.
        /// </summary>
        public abstract event DataSourceUpdatedEventHandler DataSourceUpdated;

        public abstract Task RefreshHomesAsync();

        /// <summary>
        /// Gets home data from the source
        /// </summary>
        /// <returns>IEnumerable (Home) - asynchronous</returns>
        public abstract Task<IEnumerable<Home>> GetHomesAsync();
    }
}
