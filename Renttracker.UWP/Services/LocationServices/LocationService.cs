using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using Windows.Devices.Geolocation;
using System.ComponentModel;
using Template10.Common;
using Windows.UI.Popups;
using Windows.System;

namespace Renttracker.Services.LocationServices
{
    /// <summary>
    /// Service providing geolocation capabilities
    /// </summary>
    public sealed class LocationService : LocationServiceBase, INotifyPropertyChanged
    {
        private LocationService()
        {
            // Prevents LocationService from be instantiated, requiring use of singleton property.
            Locator = new Geolocator();
            Locator.StatusChanged += OnLocatorStatusChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Geolocator _Locator = default(Geolocator);
        /// <summary>
        /// Represents a Geolocator object to be used in geolocation tasks.
        /// </summary>
        public Geolocator Locator
        {
            get
            {
                
                    
                
                return _Locator;
            }
            set
            {
                
                _Locator = value;
                
            }
        }

        private LocationAccessStatus _accessStatus = LocationAccessStatus.Unknown;
        public LocationAccessStatus AccessStatus
        {
            get
            {
                return _accessStatus;
            }
            private set
            {
                _accessStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AccessStatus)));
            }
        }

        private void OnLocatorStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            switch (args.Status)
            {
                case PositionStatus.Ready:
                case PositionStatus.Initializing:
                    AccessStatus = LocationAccessStatus.Available;
                    break;
                case PositionStatus.NoData:
                case PositionStatus.NotAvailable:
                case PositionStatus.NotInitialized:
                    AccessStatus = LocationAccessStatus.Unavailable;
                    break;
                default:
                    AccessStatus = LocationAccessStatus.Unknown;
                    break;

            }
        }

        public override async Task<bool> RequestLocationAccess()
        {
            try
            {
                var status = await Geolocator.RequestAccessAsync();

                switch (status)
                {
                    case GeolocationAccessStatus.Allowed:
                        
                        return true;
                    default:
                        await BootStrapper.Current.NavigationService.Dispatcher.DispatchAsync(async () =>
                        {
                            var dlg = new MessageDialog("Whoops! You haven't granted permission for " + Windows.ApplicationModel.Package.Current.DisplayName + " to access your location. Would you like to go to Settings and do that now?");
                            dlg.Commands.Add(new UICommand("Yes", async (command) =>
                            {
                                var uri = new Uri("ms-settings:privacy-location");
                                await Launcher.LaunchUriAsync(uri);
                            }));
                            dlg.Commands.Add(new UICommand("No"));
                            dlg.CancelCommandIndex = 1;
                            await dlg.ShowAsync();
                        }
                        );
                        return false;
                }
                
            }
            catch (UnauthorizedAccessException)
            {
                AccessStatus = LocationAccessStatus.Unavailable;
                return false;
            }

            
        }
       

        private static LocationService _current = new LocationService();

        

        public static LocationService Current
        {
            get
            {
                return _current;
            }
            private set
            {
                _current = value;
            }
        }

       
    }
}
