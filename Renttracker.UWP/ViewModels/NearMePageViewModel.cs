using Renttracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace Renttracker.ViewModels
{
    public class NearMePageViewModel : ViewModelBase
    {
        private MapControl _NearMeMapControl = default(MapControl);
        public MapControl NearMeMap
        {
            get
            {
                return _NearMeMapControl;
            }
            set
            {
                Set(ref _NearMeMapControl, value);
            }
        }

        public async void OnZoomOutButtonClicked(object sender, RoutedEventArgs e) =>
            await NearMeMap.TryZoomOutAsync();

        public async void OnZoomInButtonClicked(object sender, RoutedEventArgs e) =>
            await NearMeMap.TryZoomInAsync();


        public async void OnGeolocateButtonClicked(object sender, RoutedEventArgs e) =>
            await ZoomToCurrentLocationAsync();

        protected async Task ZoomToCurrentLocationAsync()
        {
            if (await Services.LocationServices.LocationService.Current.RequestLocationAccess())
            {
                Services.LocationServices.LocationService.Current.Locator.DesiredAccuracyInMeters = 50;
                var position = await Services.LocationServices.LocationService.Current.Locator.GetGeopositionAsync();
                await NearMeMap.TrySetViewAsync(position.Coordinate.Point, 18D);
            }
            
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            NearMeMap = (NavigationService.Content as NearMePage).FindName(nameof(NearMeMap)) as MapControl;
            await ZoomToCurrentLocationAsync();
            await Task.CompletedTask;
        }
    }
}
