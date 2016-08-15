using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Renttracker.ViewModels
{
    public class EmergencyContactPageViewModel : Template10.Mvvm.ViewModelBase
    {
        public async void ContactEmergencyServices(object sender, RoutedEventArgs e)
        {
            bool hasPhoneCallManager = ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");

            if (!hasPhoneCallManager)
            {
                await Dispatcher.DispatchAsync(async () =>
                {
                    MessageDialog dlg = new MessageDialog("This feature is not supported on your device. Sorry!", "Whoops!");
                    dlg.Commands.Add(new UICommand("OK", async (command) =>
                    {
                        await NavigationService.NavigateAsync(typeof(Views.MainPage));
                    }));
                    await dlg.ShowAsync();
                });
            }
            else
            {
                PhoneCallManager.ShowPhoneCallUI("112", "Emergency Services");
            }
            
        }
    }
}
