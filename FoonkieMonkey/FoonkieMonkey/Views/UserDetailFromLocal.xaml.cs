using FoonkieMonkey.Models;
using FoonkieMonkey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoonkieMonkey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailFromLocal : ContentPage
    {
        public UserDetailFromLocal(User user)
        {
            InitializeComponent();
            BindingContext = new UserDetailViewModel(user);
        }
    }
}