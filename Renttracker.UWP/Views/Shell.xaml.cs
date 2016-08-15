using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Renttracker.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;

        public Shell()
        {
            Instance = this;
            InitializeComponent();

            #region Hide Emergency Contact when PhoneCallManager API is not available
            // Use ApiInformation to check that the type is present
            var isPhoneCallAvailable = ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");

            // If the type is not, then hide and disable the Emergency Contact button
            if (!isPhoneCallAvailable)
            {
                EmergencyContactButton.Visibility = Visibility.Collapsed;
                EmergencyContactButton.IsEnabled = false;
            }

            #endregion
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }
    }
}

