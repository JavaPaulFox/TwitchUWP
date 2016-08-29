using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TwitchUWP.Models.ModelsForView;
using TwitchUWP.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterPage : Page
    {
        private HamburgerMenuViewModel hamburgerMenuViewModel;
        private object parameters;
        public MasterPage()
        {
            this.InitializeComponent();
            hamburgerMenuViewModel = new HamburgerMenuViewModel();
            Frame.Navigate(typeof (MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LogInPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            parameters = e.Parameter;

            if (parameters != null && parameters.GetType() == typeof (StreamViewModel) )
            {
                this.Frame.Navigate(typeof (StreamPage), parameters);
            }
            // parameters.Name
            // parameters.Text
            // ...
        }
    }
}
