using System;
using TwitchUWP.Core.Authentication;

namespace TwitchUWP.ViewModel
{
    public class HamburgerMenuViewModel : NotificationBase
    {
        private string _logInAndProfileButtonContent;
        public string LogInAndProfileButtonContent
        {
            get
            {
                if (Token.access_token != String.Empty || Token.access_token != null)
                {
                    _logInAndProfileButtonContent = "  &#59259;          Profile";
                    return _logInAndProfileButtonContent;
                }
                else
                {
                    _logInAndProfileButtonContent = "  &#59259;          Log In";
                    return _logInAndProfileButtonContent;
                }
            }
            set { _logInAndProfileButtonContent = value; }
        }
    }
}
