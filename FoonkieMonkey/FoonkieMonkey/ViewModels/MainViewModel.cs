using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoonkieMonkey.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        public Command GetInTouchCommand { get; set; }
        public MainViewModel()
        {
            GetInTouchCommand = new Command(OnGetInTouchClicked);
        }

        private void OnGetInTouchClicked(object obj)
        {
            Launcher.OpenAsync(new Uri($"mailto:email@test.com?subject={Resx.AppResources.EmailSubjet}&body={Resx.AppResources.EmailBody}"));
        }
    }
}
