using System;
using System.Threading.Tasks;

namespace Renttracker.Services.LocationServices
{
    public interface ILocationService
    {

        

        /// <summary>
        /// Requests access to the user's location.
        /// </summary>
        /// <returns>Task (asynchronous)</returns>
        Task<bool> RequestLocationAccess();
    }
}
