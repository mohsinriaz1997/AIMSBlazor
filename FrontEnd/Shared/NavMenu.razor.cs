using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Shared
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = true;
        public int LoginUserID = 0;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }


        protected override async Task OnInitializedAsync()
        {

            try
            {
                
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex.Message);
            }
        }
    }
}
