using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Models;
using TwitchUWP.Models.ModelsForView;
using TwitchUWP.ViewModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page 
    {
        private HamburgerMenuViewModel HamburgerMenuViewModel;
        private MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            InitializeComponent();   
            HamburgerMenuViewModel = new HamburgerMenuViewModel();
            mainPageViewModel = new MainPageViewModel(); 
            if (!TabletPCSupport.IsTabletMode())
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }

        }

        private async void GridViewW_Loading(FrameworkElement sender, object args)
        {
            GridViewW.Visibility = Visibility.Collapsed;
            GridViewW.ItemsSource = await StreamsGetManager.GetStreams();
        }

        private void GridViewW_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressRing.IsActive = false;
            GridViewW.Visibility = Visibility.Visible;
        }
    }
}
