using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace TwitchUWP.Models
{
    public class TabletPCSupport
    {
        public static bool IsTabletMode()
        {
            bool bIsTabletMode = false;

            var uiMode = UIViewSettings.GetForCurrentView().UserInteractionMode;

            if (uiMode == Windows.UI.ViewManagement.UserInteractionMode.Touch)

                bIsTabletMode = true;

            else

                bIsTabletMode = false;
            return bIsTabletMode;

        }
    }
}
