using FoonkieMonkey.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoonkieMonkey.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command GetInTouchCommand { get; set; }
        public Command GetUsersCommand { get; set; }
        public INavigation Navigation { get; set; }

        public MainViewModel(INavigation navigation)
        {
            GetInTouchCommand = new Command(OnGetInTouchClicked);
            GetUsersCommand = new Command(OnGetUsersCommandAsync);
            Navigation = navigation;
        }

        #region Commands
        private async void OnGetUsersCommandAsync(object obj)
        {
            await Navigation.PushModalAsync(new UsersView());
        }

        private void OnGetInTouchClicked(object obj)
        {
            Launcher.OpenAsync(new Uri($"mailto:email@test.com?subject={Resx.AppResources.EmailSubjet}&body={Resx.AppResources.EmailBody}"));
        } 
        #endregion
    }
}
