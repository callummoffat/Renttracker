using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace Renttracker.Services.DataServices
{
    public sealed class DataService : DataServiceBase
    {
        private DataService()
        {
            _current = this;
        }

        private static DataService _current = new DataService();
        public static DataService Current
        {
            get
            {
                if (_current == null)
                    _current = new DataService();
                return _current;
            }
        }

        public override event DataSourceUpdatedEventHandler DataSourceUpdated;


        public MobileServiceClient CloudService
        {
            get;
            private set;
        } = new MobileServiceClient("https://renttracker.azurewebsites.net");




        public override Task RefreshHomesAsync()
        {
#warning DataService.RefreshHomesAsync() has not yet been implemented.
            throw new NotImplementedException();
        }



        private List<Home> _homes = new List<Home>();
       

        public override async Task<IEnumerable<Home>> GetHomesAsync()
        {
#warning DataService.GetHomesAsync() just returns the result of ProtoDataService.GetHomesAsync().
            // TODO: Implement GetHomesAsync()
            return (await ProtoDataService.Current.GetHomesAsync());
        }
    }
}
