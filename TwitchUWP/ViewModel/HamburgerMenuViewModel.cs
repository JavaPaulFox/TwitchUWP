using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TwitchUWP.Core.Authentication;

namespace TwitchUWP.ViewModel
{
    public class HamburgerMenuViewModel 
    {
        private string _logInAndProfileButtonContent;
        public string LogInAndProfileButtonContent
        {
            get
            {
                if (Token.access_token != String.Empty || Token.access_token != null)
                {
                    _logInAndProfileButtonContent = "Profile";
                    return _logInAndProfileButtonContent;
                }
                else
                {
                    _logInAndProfileButtonContent = "Log In";
                    return _logInAndProfileButtonContent;
                }
            }
            set { _logInAndProfileButtonContent = value; }
        }



        
    }
}
