using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.DataServices
{



   
    /// <summary>
    /// Provides a contract for a service that retrieves data.
    /// </summary>
    public interface IDataService
    {
        event DataSourceUpdatedEventHandler DataSourceUpdated;

        Task RefreshHomesAsync();

        Task<IEnumerable<Home>> GetHomesAsync();
    }
}
