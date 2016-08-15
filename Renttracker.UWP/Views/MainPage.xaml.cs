using System;
using Renttracker.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace Renttracker.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private async void Filter_Click(object sender, RoutedEventArgs e)
        {
            await Filter_Dialog.ShowAsync();
        }

        private void Cancel_Click(object sender, ContentDialogButtonClickEventArgs e)
        {
            Filter_Dialog.Hide();
        }
    }
}
